using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace CustomModelBinder.Infrastructure
{
    public class LocationModelBinder : IModelBinder
    {
        public Task BindModelAsync(ModelBindingContext bindingContext)
        {
            if (bindingContext == null)
            {
                throw new ArgumentNullException(nameof(bindingContext));
            }

            var coord = bindingContext.ValueProvider.GetValue("coord");

            if (coord == ValueProviderResult.None)
            {
                bindingContext.Result = ModelBindingResult.Failed();
                return Task.CompletedTask;
            }

            var coordStr = coord.FirstValue;
            var coords = coordStr.Split(',');

            if (coords.Length < 3)
            {
                bindingContext.Result = ModelBindingResult.Failed();
                return Task.CompletedTask;
            }


            if (!(double.TryParse(coords[0], out var x) & double.TryParse(coords[1], out var y) & double.TryParse(coords[2], out var z)))
            {
                bindingContext.Result = ModelBindingResult.Failed();
                return Task.CompletedTask;
            }
            
            var res = new Point()
            {
                X = x,
                Y = y,
                Z = z
            };
            bindingContext.Result = ModelBindingResult.Success(res);

            return Task.CompletedTask;
        }
    }
}
