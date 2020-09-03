using System;
using AutoMapper;
using ComputerShop.API.Models;
using ComputerShop.Core.Entities;

namespace ComputerShop.API.Mapping
{
    public class AutoMapping : Profile
    {
        public AutoMapping()
        {
            MappingRegisterToApplicationUser();
        }

        private void MappingRegisterToApplicationUser()
        {
            CreateMap<Register, ApplicationUser>()
                .ForMember(x => x.NormalizedEmail, 
                    q => 
                        q.MapFrom(x => x.Email.ToUpper()))
                
                .ForMember(x => x.NormalizedUserName,
                    q =>
                        q.MapFrom(x => x.UserName.ToUpper()))
                
                .ForMember(x => x.PhoneNumber,
                    q => 
                        q.MapFrom(x => x.Phone))
                
                .ForMember(x => x.EmailConfirmed,
                    q => 
                        q.MapFrom(x => false))
                
                .ForMember(x => x.PhoneNumberConfirmed,
                    q => 
                        q.MapFrom(x => false))
                
                .ForMember(x => x.SecurityStamp,
                    q => 
                        q.MapFrom(x => Guid.NewGuid().ToString("D")))
                
                .ForMember(x => x.ProfileImage,
                    q => 
                        q.MapFrom(x => ""));
        }
    }
}