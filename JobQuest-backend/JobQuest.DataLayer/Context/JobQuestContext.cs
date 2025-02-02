using JobQuest.DataLayer.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobQuest.DataLayer.Context
{
    public class JobQuestContext : DbContext
    {
        public JobQuestContext(DbContextOptions<JobQuestContext> options) : base(options)
        {

        }

        public DbSet<Advertisement> Advertisements { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<City> Cities { get; set; }
        public DbSet<Company> Companies { get; set; }
        public DbSet<Degree> Degrees { get; set; }
        public DbSet<Exprience> Expriences { get; set; }
        public DbSet<MilitaryPosition> MilitaryPositions { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Salary> Salaries { get; set; }
        public DbSet<Sex> Sexes { get; set; }
        public DbSet<Workinghours> Workinghours { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            
        }
    }
}
