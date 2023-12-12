using System.Text.Json;
using System.Text;

namespace GazpromNeftBlazorWebApplication.Extensions
{
    public static class HttpClientExtensions
    {
        public static Task<HttpResponseMessage> GetAsJsonAsync(this HttpClient httpClient, string requestUri, object data)
            => httpClient.SendAsync(new HttpRequestMessage(HttpMethod.Get, requestUri) { Content = Serialize(data) });
        public static Task<HttpResponseMessage> GetAsJsonAsync<T>(this HttpClient httpClient, string requestUri, T data)
            => httpClient.SendAsync(new HttpRequestMessage(HttpMethod.Get, requestUri) { Content = Serialize(data) });
        public static Task<HttpResponseMessage> DeleteAsJsonAsync(this HttpClient httpClient, string requestUri, object data)
            => httpClient.SendAsync(new HttpRequestMessage(HttpMethod.Delete, requestUri) { Content = Serialize(data) });
        public static Task<HttpResponseMessage> DeleteAsJsonAsync<T>(this HttpClient httpClient, string requestUri, T data)
            => httpClient.SendAsync(new HttpRequestMessage(HttpMethod.Delete, requestUri) { Content = Serialize(data) });

        private static HttpContent Serialize(object data) => new StringContent(JsonSerializer.Serialize(data), Encoding.UTF8, "application/json");
        private static HttpContent Serialize<T>(T data) => new StringContent(JsonSerializer.Serialize(data), Encoding.UTF8, "application/json");
    }
}
