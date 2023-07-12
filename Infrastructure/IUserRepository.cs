using System;
using WebAPI.Domain;
using System.Collections.Generic;
using WebAPI.Application.Models;

namespace WebAPI.Infrastructure
{
    public interface IUserRepository    
    {

        List<User> getAll();
        User getByID(int ID);
        User add(User User);
        User update(User User);
        void delete(int ID);
        User getUserByEmailAndPassword(LoginModel user);
        
    }
}