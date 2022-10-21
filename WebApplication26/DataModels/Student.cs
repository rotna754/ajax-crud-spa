﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication26.DataModels
{
    [Table("Student")]
    public class Student
    {
        [Key]
        public int StudentId { get; set; }
        public string StudentName { get; set; }
        public string Email  { get; set; }
        public string Shift { get; set; }
        public string Dob { get; set; }
        [ForeignKey("DepartmentId")]
        public int DepartmentId { get; set; }
        public string Photo { get; set; }
        public Department Department { get; set; }
    }
}
