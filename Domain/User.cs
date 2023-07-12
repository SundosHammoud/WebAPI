using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using WebAPI.Application.Models;

namespace WebAPI.Domain
{
    public class User
    {
        [Key]
        public int ID {get; set;}

        [StringLength(50)]
        public string Name {get; set;}
        public string LastName {get; set;}
        public string Email {get; set;}     
        public string Password {get; set;}       
        [ForeignKey("Role")] 
        public int RoleID {get; set;}

        public Role Role {get; set;}
        
    }
}