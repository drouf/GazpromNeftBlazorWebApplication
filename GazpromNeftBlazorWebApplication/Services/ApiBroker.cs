using AutoMapper;
using GazpromNeftBlazorWebApplication.DTO;
using GazpromNeftBlazorWebApplication.Errors;
using GazpromNeftBlazorWebApplication.Extensions;
using GazpromNeftBlazorWebApplication.Models;
using GazpromNeftBlazorWebApplication.ViewModels;
using Microsoft.AspNetCore.Authentication.OAuth;
using Microsoft.AspNetCore.SignalR;

namespace GazpromNeftBlazorWebApplication.Services
{
    public abstract class ApiBroker
    {
        public abstract Task<TResponse> Get<TResponse>(string url, object? content = null);

        public abstract Task<TResponse> Post<TResponse>(string url, object content);

        public abstract Task<TResponse> Put<TResponse>(string url, object content);

        public abstract Task<TResponse> Patch<TResponse>(string url, object content);

        public abstract Task Delete<TResponse>(string url, object content);
    }
}
