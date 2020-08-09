using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASP_ValidationModel.Models
{
    public class ValidationContext : DbContext
    {
        public ValidationContext(DbContextOptions<ValidationContext> options) : base(options)
        {
            Database.EnsureCreated();
        }
    }
}
