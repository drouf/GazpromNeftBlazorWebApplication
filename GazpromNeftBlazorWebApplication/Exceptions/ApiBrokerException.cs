using GazpromNeftBlazorWebApplication.Models;

namespace GazpromNeftBlazorWebApplication.Exceptions
{
    public class ApiBrokerException : Exception
    {
        public IEnumerable<ValidationErrorModel> Errors { get; set; } = new List<ValidationErrorModel>();
    }
}
