using AutoMapper;
using WebAPI.Application.Models;
using WebAPI.Domain;
using System;

namespace WebAPI.Application.MapperProfiles
{
    public class MachineProfile: Profile
    {
        public MachineProfile(){

            CreateMap<Machine, MachineModel>()
                .ReverseMap();
            
        }
    }
}