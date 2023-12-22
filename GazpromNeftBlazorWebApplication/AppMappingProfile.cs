using AutoMapper;
using GazpromNeftBlazorWebApplication.DTO;
using GazpromNeftBlazorWebApplication.ViewModels;

namespace GazpromNeftBlazorWebApplication
{
    public class AppMappingProfile : Profile
    {
        public AppMappingProfile()
        {
            CreateMap<UserDto, IndexUserModel> ();
            CreateMap<IndexUserModel, EditUserModel>();
            CreateMap<IndexUserModel, DeleteUserModel>();
            CreateMap<AddUserModel, AddUserCommand>();
            CreateMap<EditUserModel, EditUserCommand>();
            CreateMap<DeleteUserModel, DeleteUserCommand>();
        }
    }
}
