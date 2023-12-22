using GazpromNeftBlazorWebApplication.DTO;

namespace GazpromNeftBlazorWebApplication.Exceptions
{
    public class ApiServiceException : Exception
    {
        public IEnumerable<ValidationErrorDto> Errors { get; set; } = new List<ValidationErrorDto>();
    }
}
