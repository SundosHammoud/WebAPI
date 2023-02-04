using AutoMapper;
using WebAPI.Application.Models;
using WebAPI.Domain;

namespace WebAPI.Application.MapperProfiles
{
    public class ManufacturerProfile: Profile
    {
        public ManufacturerProfile(){

            CreateMap<Manufacturer, ManufacturerModel>()
                .ReverseMap();
        }
    }
}