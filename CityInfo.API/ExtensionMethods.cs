using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CityInfo.API
{
    public static class ExtensionMethods
    {
        public static IEnumerable<ModelError> GetAllErrors(this ModelStateDictionary modelState)
        {
            return modelState.Values.SelectMany(v => v.Errors);
        }
    }
}
