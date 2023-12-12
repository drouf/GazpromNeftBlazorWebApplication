using GazpromNeftBlazorWebApplication.Models;

namespace GazpromNeftBlazorWebApplication.Errors
{
    public class ApiBrokerException : Exception
    {
        public IEnumerable<ValidationErrorModel> Errors { get; set; } = new List<ValidationErrorModel>();
    }
}
