using System;
using WebAPI.Domain;
using System.Collections.Generic;
using WebAPI.Application.Models;

namespace WebAPI.Service
{
    public interface IUserService    
    {
        string login(LoginModel user);
        List<UserModel> getAll();
        UserModel getByID(int ID);
        UserModel add(UserModel user);
        UserModel update(UserModel user);
        void delete(int ID);
    }
}