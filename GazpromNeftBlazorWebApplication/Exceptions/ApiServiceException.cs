using GazpromNeftBlazorWebApplication.Models;

namespace GazpromNeftBlazorWebApplication.Exceptions
{
    public class ApiServiceException : Exception
    {
        public IEnumerable<ValidationErrorModel> Errors { get; set; } = new List<ValidationErrorModel>();
    }
}
