﻿using AutoMapper;
using GazpromNeftBlazorWebApplication.DTO;
using GazpromNeftBlazorWebApplication.Exceptions;
using GazpromNeftBlazorWebApplication.Extensions;

namespace GazpromNeftBlazorWebApplication.Services
{
    public class GazpromNeftApiService : ApiService
    {
        private readonly IMapper _mapper;
        public GazpromNeftApiService(IMapper mapper)
        {
            _mapper = mapper;
        }

        public override async Task<TResponse> Get<TResponse, TData>(string url, TData content) where TData:class
        {
            using (var client = new HttpClient())
            {
                var response = await client.GetAsJsonAsync<TData>(url, content);
                await DoSuccessValidation(response);
                var usersDto = await response.Content.ReadFromJsonAsync<IEnumerable<UserDto>>();
                return _mapper.Map<IEnumerable<UserDto>, TResponse>(usersDto ?? new List<UserDto>());
            }
        }

        public override async Task<TResponse> Post<TResponse, TData>(string url, TData content) where TData : class
        {
            using (var client = new HttpClient())
            {
                var response = await client.PostAsJsonAsync<TData>(url, content);
                await DoSuccessValidation(response);
                var usersDto = await response.Content.ReadFromJsonAsync<UserDto>();
                return _mapper.Map<UserDto, TResponse>(usersDto ?? new());
            }
        }

        public override async Task<TResponse> Put<TResponse, TData>(string url, TData content) where TData : class
        {
            using (var client = new HttpClient())
            {
                var response = await client.PutAsJsonAsync<TData>(url, content);
                await DoSuccessValidation(response);
                var usersDto = await response.Content.ReadFromJsonAsync<UserDto>();
                return _mapper.Map<UserDto, TResponse>(usersDto ?? new());
            }
        }

        public override async Task<TResponse> Patch<TResponse, TData>(string url, TData content) where TData : class
        {
            using (var client = new HttpClient())
            {
                var response = await client.PatchAsJsonAsync<TData>(url, content);
                await DoSuccessValidation(response);
                var usersDto = await response.Content.ReadFromJsonAsync<UserDto>();
                return _mapper.Map<UserDto, TResponse>(usersDto ?? new());
            }
        }

        public override async Task Delete<TData>(string url, TData content) where TData : class
        {
            using (var client = new HttpClient())
            {
                var response = await client.DeleteAsJsonAsync<TData>(url, content);
                await DoSuccessValidation(response);
            }
        }
        private async Task DoSuccessValidation(HttpResponseMessage response)
        {
            if (response.IsSuccessStatusCode) return;
            if (response.StatusCode == System.Net.HttpStatusCode.BadRequest)
            {
                throw new ApiServiceException() { Errors = await response.Content.ReadFromJsonAsync<IEnumerable<ValidationErrorDto>>() ?? new List<ValidationErrorDto>() };
            }
            if(response.StatusCode == System.Net.HttpStatusCode.InternalServerError)
            {
                var msg = await response.Content.ReadAsStringAsync();
                throw new InternalServerErrorException(msg);
            }
        }
    }
}
