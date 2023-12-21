namespace GazpromNeftBlazorWebApplication.Services
{
    public class ApiEndpointManagerService
    {
        public IEnumerable<ApiEndpoint> ApiEndpoints { get; set; } = new List<ApiEndpoint>();
        public string GetEndpointUrl(string name)
        {
            var endpoint = ApiEndpoints.FirstOrDefault(e => e.EndpointName == name);
            if (endpoint == null)
                return string.Empty;
            else
                return endpoint.EndpointUrl;
        }
    }

    public class ApiEndpoint
    {
        public string EndpointName { get; set; } = string.Empty;
        public string EndpointUrl { get; set; } = string.Empty;
    }
}
