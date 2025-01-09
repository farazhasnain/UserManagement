
using AutoMapper;
using System;
using UserManagement.Domain.Identity;
using UserManagement.Service.ViewModel.Account;
using UserManagement.Service.ViewModel.Identity.AppRole;
using UserManagement.Service.ViewModel.Identity.AppUsers;

namespace UserManagement.Service.AutoMappper
{
    public class AppAutoMapper:Profile
    {
        //Configure All AutoMapper Object
        public AppAutoMapper()
        {
            //AppRole AutoMapper
            CreateMap<CreateRoleViewModel, AppRole>().ReverseMap();

            CreateMap<UpdateRoleViewModel, AppRole>().ReverseMap();
            CreateMap<RoleResponseViewModel, AppRole>().ReverseMap();

            //AppUser AutoMapper
            CreateMap<CreateUserViewModel, AppUser>().
                ForMember(src => src.UserName, x => x.MapFrom(des => des.Email))
                .ReverseMap();

            CreateMap<UpdateUserViewModel, AppUser>().ReverseMap();
            CreateMap<UserResponseViewModel, AppUser>().ReverseMap();


            //Account AutoMapper
            CreateMap<RegisterViewModel, AppUser>().ForMember(src => src.UserName, x => x.MapFrom(des => des.Email))
            .ReverseMap();

            CreateMap<LoginViewModel, AppUser>().ForMember(src => src.UserName, x => x.MapFrom(des => des.Email)).ReverseMap();
            
        }
    }
}
