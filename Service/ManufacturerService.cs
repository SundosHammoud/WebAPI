using System;
using ceconsoftAPI.Domain;
using System.Collections.Generic;
using ceconsoftAPI.Infrastructure;
using AutoMapper;
using ceconsoftAPI.Application.Models;


namespace ceconsoftAPI.Service
{
    public class ManufacturerService : IManufacturerService
    {
        private readonly IManufacturerRepository _manufacturerRepository;
        private readonly IMapper _mapper;

        public ManufacturerService(IManufacturerRepository manufacturerRepository, IMapper mapper)
        {
            _manufacturerRepository = manufacturerRepository;
            _mapper = mapper;
        }

        public List<ManufacturerModel> getAll()
        {
            List<Manufacturer> allManufacturers = _manufacturerRepository.getAll();
            List<ManufacturerModel> all = _mapper.Map<List<ManufacturerModel>>(allManufacturers);
            return all;
        }

        public ManufacturerModel getByID(int ID)
        {
            Manufacturer manufacturer = _manufacturerRepository.getByID(ID);
            return _mapper.Map<ManufacturerModel>(manufacturer);
        }

        public ManufacturerModel add(ManufacturerModel manufacturerModel)
        {
            validateModel(manufacturerModel);
            Manufacturer manufacturer = _mapper.Map<Manufacturer>(manufacturerModel);
            Manufacturer addedEntity = _manufacturerRepository.add(manufacturer);
            ManufacturerModel returnedModel =  _mapper.Map<ManufacturerModel>(addedEntity);
            return returnedModel;
        }

        public void validateModel(ManufacturerModel manufacturerModel)
        {
            if(String.IsNullOrEmpty(manufacturerModel.Name))
                throw new Exception();                        
        }

        public ManufacturerModel update(ManufacturerModel manufacturerModel)
        {
            validateModel(manufacturerModel);
            Manufacturer manufacturer = _mapper.Map<Manufacturer>(manufacturerModel);
            Manufacturer addedEntity = _manufacturerRepository.update(manufacturer);
            ManufacturerModel returnedModel =  _mapper.Map<ManufacturerModel>(addedEntity);
            return returnedModel;
        }

        public void delete(int ID)
        {
            _manufacturerRepository.delete(ID);
        }


    }
}