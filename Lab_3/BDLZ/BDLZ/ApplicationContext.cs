using BDLZ.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace BDLZ
{
    public class ApplicationContext : DbContext
    {
        public DbSet<Faculty> faculties { get; set; }
        public DbSet<Group> groups { get; set; }
        public DbSet<LecturesPlan> lectures_plan { get; set; }
        public DbSet<Student> students { get; set; }
        public DbSet<Subject> subjects { get; set; }
        public DbSet<Teacher> teachers { get; set; }

        public ApplicationContext()
        {
            Database.EnsureCreated();
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql("Host=localhost;Username=postgres;Password=p;Database=bdlz3");
        }
    }
}
