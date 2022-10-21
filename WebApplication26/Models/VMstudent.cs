using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication26.Models
{
    public class VMstudent
    {
        public int StudentId { get; set; }
        public string StudentName { get; set; }
        public string Email { get; set; }
        public string Shift { get; set; }
        public string Dob { get; set; }
        public int DepartmentId { get; set; }
        public IFormFile picpath { get; set; }
    }
}
