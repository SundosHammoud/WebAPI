using AutoMapper;
using WebAPI.Application.Models;
using WebAPI.Domain;
using System;

namespace WebAPI.Application.MapperProfiles
{
    public class RoleProfile: Profile
    {
        public RoleProfile(){

            CreateMap<Role, RoleModel>()
                .ReverseMap();
            
        }
    }
}