using System;
using WebAPI.Domain;
using System.Collections.Generic;
using WebAPI.Infrastructure;
using AutoMapper;
using WebAPI.Application.Models;


namespace WebAPI.Service
{
    public class MachineService : IMachineService
    {
        private readonly IMachineRepository _machineRepository;
        private readonly IManufacturerRepository _manufacturerRepository;
        private readonly IMapper _mapper;

        public MachineService(IMachineRepository machineRepository, IManufacturerRepository manufacturerRepository, IMapper mapper)
        {
            _machineRepository = machineRepository;
            _manufacturerRepository = manufacturerRepository;
            _mapper = mapper;
        }

        public List<MachineModel> getAll()
        {
            List<Machine> allMachines = _machineRepository.getAll();
            List<MachineModel> all = _mapper.Map<List<MachineModel>>(allMachines);
            return all;
        }

        public MachineModel getByID(int ID)
        {
            Machine machine = _machineRepository.getByID(ID);
            return _mapper.Map<MachineModel>(machine);
        }

        public MachineModel add(MachineModel machineModel)
        {
            validateModel(machineModel);
            Machine machine = _mapper.Map<Machine>(machineModel);
            Machine addedEntity = _machineRepository.add(machine);
            MachineModel returnedModel =  _mapper.Map<MachineModel>(addedEntity);
            return returnedModel;
        }

        public void validateModel(MachineModel machineModel)
        {
            if(String.IsNullOrEmpty(machineModel.Name))
                throw new Exception("Insert a valid name please");                      

            if(machineModel.Price < 0)                      
                throw new Exception("Insert a positive value please");  

            if(machineModel.LastMaintenance != null)  
                if(DateTime.Compare(machineModel.LastMaintenance.Value, DateTime.Now) > 0)
                    throw new Exception("Last Maintenance date can't be in the future"); 

            //Check that the inserted manufacturer ID exists in the system
            List<int> allIDs = _manufacturerRepository.getAllIDs();
            if(!allIDs.Contains(machineModel.ManufacturerID))
                throw new Exception("Insert a valid manufacturer ID please");                   
                
        }

        public MachineModel update(MachineModel machineModel)
        {
            validateModel(machineModel);
            Machine machine = _mapper.Map<Machine>(machineModel);
            Machine addedEntity = _machineRepository.update(machine);
            MachineModel returnedModel =  _mapper.Map<MachineModel>(addedEntity);
            return returnedModel;
        }

        public void delete(int ID)
        {
            _machineRepository.delete(ID);
        }
    }
}