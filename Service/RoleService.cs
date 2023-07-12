using System;
using WebAPI.Domain;
using System.Collections.Generic;
using WebAPI.Infrastructure;
using AutoMapper;
using WebAPI.Application.Models;


namespace WebAPI.Service
{
    public class RoleService : IRoleService
    {
        private readonly IRoleRepository _roleRepository;
        private readonly IMapper _mapper;

        public RoleService(IRoleRepository roleRepository, IMapper mapper)
        {
            _roleRepository = roleRepository;
            _mapper = mapper;
        }

        public List<RoleModel> getAll()
        {
            List<Role> all = _roleRepository.getAll();
            List<RoleModel> allMapped = _mapper.Map<List<RoleModel>>(all);
            return allMapped;
        }

        public RoleModel getByID(int ID)
        {
            Role role = _roleRepository.getByID(ID);
            return _mapper.Map<RoleModel>(role);
        }

        public RoleModel add(RoleModel roleModel)
        {
            validateModel(roleModel);
            Role role = _mapper.Map<Role>(roleModel);
            Role addedEntity = _roleRepository.add(role);
            RoleModel returnedModel =  _mapper.Map<RoleModel>(addedEntity);
            return returnedModel;
        }

        public void validateModel(RoleModel roleModel)
        {
            if(String.IsNullOrEmpty(roleModel.Name))
                throw new Exception("Insert a valid name please");                        
        }

        public RoleModel update(RoleModel roleModel)
        {
            validateModel(roleModel);
            Role role = _mapper.Map<Role>(roleModel);
            Role addedEntity = _roleRepository.update(role);
            RoleModel returnedModel =  _mapper.Map<RoleModel>(addedEntity);
            return returnedModel;
        }

        public void delete(int ID)
        {   
            _roleRepository.delete(ID);
        }


    }
}