using System;
using System.Collections.Generic;

namespace WebAPI.Application.Models
{
    public class RoleModel
    {      
        public int ID {get; set;}

        public string Name {get; set;}
           
        public int UserID {get; set;}

        public List<UserModel> Users {get; set;}
    }
}