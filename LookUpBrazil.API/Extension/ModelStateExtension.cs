using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace LookUpBrazil.API.Extension
{
    public static class ModelStateExtension
    {
        public static List<string> GetErrors(this ModelStateDictionary modelStateDictionary)
        {
            var result = new List<string>();
            foreach (var item in modelStateDictionary.Values)
            {
                foreach (var error in item.Errors)
                {
                    result.Add(error.ErrorMessage);
                }
            }
            return result;
        }
    }
}
