using System;
using System.Buffers.Text;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CustomModelBinder.Controllers;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace CustomModelBinder.Infrastructure
{
    public class PersonModelBinder : IModelBinder
    {
        public Task BindModelAsync(ModelBindingContext bindingContext)
        {
            if (bindingContext == null)
            {
                throw new ArgumentNullException(nameof(bindingContext));
            }

            var base64Value = bindingContext.ValueProvider.GetValue("base64str");

            if (base64Value == ValueProviderResult.None)
            {
                bindingContext.Result = ModelBindingResult.Failed();
                return Task.CompletedTask;
            }

            var base64Str = base64Value.FirstValue;

            base64Str += "==";
            
            var bytesSpan = new Span<byte>(new byte[16]);
            
            if (!System.Convert.TryFromBase64String(base64Str, bytesSpan, out var bytesWritten))
            {
                bindingContext.Result = ModelBindingResult.Failed();
                return Task.CompletedTask;
            }
            
            var guid=new Guid(bytesSpan);
            
            var res = new Person()
            {
                Id = guid,
            };
            bindingContext.Result = ModelBindingResult.Success(res);

            return Task.CompletedTask;
        }
    }
}
