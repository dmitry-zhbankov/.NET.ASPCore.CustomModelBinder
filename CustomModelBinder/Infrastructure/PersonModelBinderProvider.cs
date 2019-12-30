using System;
using System.Buffers.Text;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CustomModelBinder.Controllers;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.ModelBinding.Binders;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace CustomModelBinder.Infrastructure
{
    public class PersonModelBinderProvider:IModelBinderProvider
    {
        public IModelBinder GetBinder(ModelBinderProviderContext context)
        {
            var binder=new PersonModelBinder();
            return context.Metadata.ModelType == typeof(Person) ? binder : null;
        }
    }
}
