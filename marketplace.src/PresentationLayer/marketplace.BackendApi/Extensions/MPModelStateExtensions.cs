using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.Linq;

namespace marketplace.BackendApi.Extensions
{
    public static class MPModelStateExtensions
    {
        public static List<string> GetMessageList(this ModelStateDictionary modelState) {
            return (from state in modelState.Values
                    from error in state.Errors
                    select error.ErrorMessage).ToList<string>();
        }
    }
}