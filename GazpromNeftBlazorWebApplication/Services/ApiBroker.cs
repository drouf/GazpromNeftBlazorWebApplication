namespace GazpromNeftBlazorWebApplication.Services
{
    public abstract class ApiBroker
    {
        public abstract Task<TResponse> Get<TResponse, TData>(string url, TData content) where TData : class;

        public abstract Task<TResponse> Post<TResponse, TData>(string url, TData content) where TData : class;

        public abstract Task<TResponse> Put<TResponse,TData>(string url, TData content) where TData : class;

        public abstract Task<TResponse> Patch<TResponse, TData>(string url, TData content) where TData : class;

        public abstract Task Delete<TResponse, TData>(string url, TData content) where TData : class;
    }
}
