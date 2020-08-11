using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ASP_ValidationModel.Models
{
    public class Person
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public int Age { get; set; }
        public string AvatarName { get; set; }
        public string AvatarPath { get; set; }
    }
}
