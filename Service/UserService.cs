using System;
using WebAPI.Domain;
using System.Collections.Generic;
using WebAPI.Infrastructure;
using AutoMapper;
using WebAPI.Application.Models;
using System.Security.Claims;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Text.RegularExpressions;

namespace WebAPI.Service
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public UserService(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public string login(LoginModel user)
        {
            string jwt = "";
            var existedUser = _userRepository.getUserByEmailAndPassword(user);
            if(existedUser == null)
                throw new Exception("wrong credentials!");
            
            jwt = createToken(existedUser);
            return jwt;
        }

        private string createToken(User user)
        {
            List<Claim> claims = new List<Claim>{
                new Claim(ClaimTypes.Email, user.Email),
                new Claim(ClaimTypes.Role, user.Role.Name),
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJzdWIiOiIxMjM0NTY3ODkwIiwibmFtZSI6IkpvaG4gRG9lIiwiYWRtaW4iOnRydWV9.TJVA95OrM7E2cBab30RMHrHDcEfxjoYZgeFONFh7HgQ"));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256Signature);
            var token = new JwtSecurityToken(claims: claims, expires: DateTime.Now.AddDays(1), signingCredentials: creds);
            var jwt = new JwtSecurityTokenHandler().WriteToken(token);
            return jwt;
        }

        public List<UserModel> getAll()
        {
            List<User> all = _userRepository.getAll();
            List<UserModel> allMapped = _mapper.Map<List<UserModel>>(all);
            return allMapped;
        }

        public UserModel getByID(int ID)
        {
            User user = _userRepository.getByID(ID);
            return _mapper.Map<UserModel>(user);
        }

        public UserModel add(UserModel userModel)
        {
            validateModel(userModel);
            User user = _mapper.Map<User>(userModel);
            User addedEntity = _userRepository.add(user);
            UserModel returnedModel =  _mapper.Map<UserModel>(addedEntity);
            return returnedModel;
        }

        public void validateModel(UserModel userModel)
        {
            if(String.IsNullOrEmpty(userModel.Name))
                throw new Exception("Insert a valid name please");
                 
            Regex regex = new Regex(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$");
            Match match = regex.Match(userModel.Email);
            if (!match.Success)
                throw new Exception("Email format is wrong");
                          
        }

        public UserModel update(UserModel userModel)
        {
            validateModel(userModel);
            User user = _mapper.Map<User>(userModel);
            User addedEntity = _userRepository.update(user);
            UserModel returnedModel =  _mapper.Map<UserModel>(addedEntity);
            return returnedModel;
        }

        public void delete(int ID)
        {   
            _userRepository.delete(ID);
        }


    }
}