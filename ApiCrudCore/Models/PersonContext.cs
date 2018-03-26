using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiCrudCore.Models
{
    public class PersonContext:DbContext
    {
        public PersonContext():base()
        {

        }
        public PersonContext(DbContextOptions opts) : base(opts)
        {
        }

        public DbSet<Person> People { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
        }
    }
}
