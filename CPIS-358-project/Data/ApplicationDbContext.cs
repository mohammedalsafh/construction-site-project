using CPIS_358_project.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace CPIS_358_project.Data
{

    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }


        public DbSet<User> Users { get; set; }
    }
}