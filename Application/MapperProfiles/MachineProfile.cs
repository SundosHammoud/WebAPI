using AutoMapper;
using ceconsoftAPI.Application.Models;
using ceconsoftAPI.Domain;

namespace ceconsoftAPI.Application.MapperProfiles
{
    public class MachineProfile: Profile
    {
        public MachineProfile(){

            CreateMap<Machine, MachineModel>()
                .ReverseMap();
        }
    }
}