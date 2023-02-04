using AutoMapper;
using ceconsoftAPI.Application.Models;
using ceconsoftAPI.Domain;

namespace ceconsoftAPI.Application.MapperProfiles
{
    public class ManufacturerProfile: Profile
    {
        public ManufacturerProfile(){

            CreateMap<Manufacturer, ManufacturerModel>()
                .ReverseMap();
        }
    }
}