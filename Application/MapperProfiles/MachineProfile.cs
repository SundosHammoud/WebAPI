using AutoMapper;
using WebAPI.Application.Models;
using WebAPI.Domain;

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