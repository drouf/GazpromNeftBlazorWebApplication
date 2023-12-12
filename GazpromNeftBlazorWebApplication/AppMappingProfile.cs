using AutoMapper;
using GazpromNeftBlazorWebApplication.DTO;
using GazpromNeftBlazorWebApplication.Models;
using GazpromNeftBlazorWebApplication.ViewModels;

namespace GazpromNeftBlazorWebApplication
{
    public class AppMappingProfile : Profile
    {
        public AppMappingProfile()
        {
            CreateMap<UserDto, IndexUserModel> ();
            CreateMap<ValidationErrorDto, ValidationErrorModel> ();
        }
    }
}
