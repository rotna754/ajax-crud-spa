using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication26.DataModels
{
    public class StudentDb:DbContext
    {
        public StudentDb()
        {

        }
        public StudentDb(DbContextOptions<StudentDb> options):base(options)
        {

        }
        public DbSet<Student> Students { get; set; }
        public DbSet<Department> Departments { get; set; }
    }
}
