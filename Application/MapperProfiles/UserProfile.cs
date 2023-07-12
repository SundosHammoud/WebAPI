using AutoMapper;
using WebAPI.Application.Models;
using WebAPI.Domain;
using System;

namespace WebAPI.Application.MapperProfiles
{
    public class UserProfile: Profile
    {
        public UserProfile(){

            CreateMap<User, UserModel>()
                .ReverseMap();
            
        }
    }
}