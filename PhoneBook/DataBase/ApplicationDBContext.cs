using Microsoft.EntityFrameworkCore;
using PhoneBook.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneBook.DataBase
{
    class ApplicationDBContext : DbContext
    {
        public DbSet<User> Users { get; set; }

        //public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options) : base(options)
        //{
        //}

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=users.db");
            optionsBuilder.UseLazyLoadingProxies();
            base.OnConfiguring(optionsBuilder);
        }
    }
}
