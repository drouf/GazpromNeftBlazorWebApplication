using AutoMapper;
using GazpromNeftBlazorWebApplication.DTO;
using GazpromNeftBlazorWebApplication.Errors;
using GazpromNeftBlazorWebApplication.Extensions;
using GazpromNeftBlazorWebApplication.Models;

namespace GazpromNeftBlazorWebApplication.Services
{
    public class GazpromNeftApiBroker : ApiBroker
    {
        private readonly IMapper _mapper;
        public GazpromNeftApiBroker(IMapper mapper)
        {
            _mapper = mapper;
        }

        public override async Task<TResponse> Get<TResponse>(string url, object? content = null)
        {
            using (var client = new HttpClient())
            {
                var response = (content == null) ? await client.GetAsync(url) : await client.GetAsJsonAsync(url, content);
                await DoSuccessValidation(response);
                var usersDto = await response.Content.ReadFromJsonAsync<IEnumerable<UserDto>>();
                return _mapper.Map<IEnumerable<UserDto>, TResponse>(usersDto ?? new List<UserDto>());
            }
        }

        public override async Task<TResponse> Post<TResponse>(string url, object content)
        {
            using (var client = new HttpClient())
            {
                var response = await client.PostAsJsonAsync(url, content);
                await DoSuccessValidation(response);
                var usersDto = await response.Content.ReadFromJsonAsync<UserDto>();
                return _mapper.Map<UserDto, TResponse>(usersDto ?? new());
            }
        }

        public override async Task<TResponse> Put<TResponse>(string url, object content)
        {
            using (var client = new HttpClient())
            {
                var response = await client.PutAsJsonAsync(url, content);
                await DoSuccessValidation(response);
                var usersDto = await response.Content.ReadFromJsonAsync<UserDto>();
                return _mapper.Map<UserDto, TResponse>(usersDto ?? new());
            }
        }

        public override async Task<TResponse> Patch<TResponse>(string url, object content)
        {
            using (var client = new HttpClient())
            {
                var response = await client.PatchAsJsonAsync(url, content);
                await DoSuccessValidation(response);
                var usersDto = await response.Content.ReadFromJsonAsync<UserDto>();
                return _mapper.Map<UserDto, TResponse>(usersDto ?? new());
            }
        }

        public override async Task Delete<TResponse>(string url, object content)
        {
            using (var client = new HttpClient())
            {
                var response = await client.DeleteAsJsonAsync(url, content);
                await DoSuccessValidation(response);
            }
        }
        private async Task DoSuccessValidation(HttpResponseMessage response)
        {
            if (!response.IsSuccessStatusCode)
            {
                var validationErrors = _mapper
                    .Map<IEnumerable<ValidationErrorDto>, List<ValidationErrorModel>>
                    (await response.Content.ReadFromJsonAsync<IEnumerable<ValidationErrorDto>>()
                        ?? new List<ValidationErrorDto>());
                throw new ApiBrokerException() { Errors = validationErrors };
            }
        }
    }
}
