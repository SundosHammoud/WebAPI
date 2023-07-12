using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebAPI.Domain
{
    public class Role
    {
        [Key]
        public int ID {get; set;}
        [StringLength(50)]
        public string Name {get; set;}
        [StringLength(200)]

        public List<User> Users {get; set;}
    }
}