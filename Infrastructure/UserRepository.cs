using System;
using WebAPI.Domain;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using WebAPI.Application.Models;

namespace WebAPI.Infrastructure
{
    public class UserRepository: IUserRepository    
    {
        private readonly MyContext _context;

        public UserRepository(MyContext context)
        {
            _context = context;
        }

        public List<User> getAll()
        {
            return _context.User.Include(x => x.Role).ToList();
        }

        public User getByID(int ID)
        {
            var user = _context.User
                                    .Include(x => x.Role)
                                    .FirstOrDefault(x => x.ID == ID);

            if(user == null)
                throw new Exception("User not found");
            
            return user;
        }

        public User add(User user)
        {
            User duplicatedUser = _context.User.FirstOrDefault(x => x.Email == user.Email);
            if(duplicatedUser != null)
                throw new Exception("duplicated email");
            _context.User.Add(user);
            _context.SaveChanges();
            return user;
        }

        public User update(User user)
        {
            User duplicatedUser = _context.User.FirstOrDefault(x => x.ID != user.ID && x.Email == user.Email);
            if(duplicatedUser != null)
                throw new Exception("duplicated email");
            
            var oldEntity = getByID(user.ID);    
            _context.Entry(oldEntity).CurrentValues.SetValues(user);
            _context.SaveChanges();
            return oldEntity;

        }

        public void delete(int ID)
        {
            var oldEntity = getByID(ID);             
            _context.Remove(oldEntity);
            _context.SaveChanges();
        }

        public User getUserByEmailAndPassword(LoginModel user)
        {
            var existedUser = _context.User.Include(x => x.Role).FirstOrDefault(x => x.Email == user.Email && x.Password == user.Password);
            if(existedUser == null)
                throw new Exception("wroing credentials!");
            return existedUser;
        }
    }
}