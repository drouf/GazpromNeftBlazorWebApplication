namespace GazpromNeftBlazorWebApplication.Services
{
    public abstract class ApiService
    {
        public abstract Task<TResponse> Get<TResponse, TData>(string url, TData content) where TData : class;

        public abstract Task<TResponse> Post<TResponse, TData>(string url, TData content) where TData : class;

        public abstract Task<TResponse> Put<TResponse,TData>(string url, TData content) where TData : class;

        public abstract Task<TResponse> Patch<TResponse, TData>(string url, TData content) where TData : class;

        public abstract Task Delete<TData>(string url, TData content) where TData : class;
    }
}
