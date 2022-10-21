using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using WebApplication26.DataModels;
using WebApplication26.Models;

namespace WebApplication26.Controllers
{
    public class HomeController : Controller
    {
        public readonly StudentDb ctx = null;
        public HomeController(StudentDb context)
        {
            ctx = context;
        }
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public IActionResult Department()
        {
            return Json(ctx.Departments.ToList());
        }
        [HttpGet]
        public IActionResult Students()
        {
            return Json(ctx.Students.ToList());
        }
        [HttpGet]
        public IActionResult Student(int id)
        {
           
            var student = ctx.Students.Where(x => x.StudentId == id).FirstOrDefault();
            return Json(student);
        }

        [HttpPost]
        public IActionResult Studentadd(VMstudent model)
        {
         
            object res = null;
            var student = ctx.Students.Where(x => x.StudentId == model.StudentId).FirstOrDefault();
            if (student == null)
            {
                string filename = "";
                if (model.picpath != null)
                {
                    string path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/pics");
                    FileInfo dr = new FileInfo(model.picpath.FileName);
                    string newfilename = DateTime.Now.ToString("yyyymmddmmss");
                    filename = newfilename + dr.Extension;
                    string filewithpath = Path.Combine(path, filename);
                    using (var stream = new FileStream(filewithpath, FileMode.Create))
                    {
                        model.picpath.CopyTo(stream);
                    }
                }

                student = new Student();
                student.StudentId = model.StudentId;
                student.StudentName = model.StudentName;
                student.DepartmentId = model.DepartmentId;
                student.Email = model.Email;
                student.Shift = model.Shift;
                student.Dob = model.Dob;
                student.Photo = filename;
                ctx.Students.Add(student);
                ctx.SaveChanges();
                res = new
                {
                    resstate = true
                };

            }
            
            return Json(res);
        }

        [HttpPut]
        public IActionResult Studentedit(VMstudent model)
        {
            
            object res = null;
            var student = ctx.Students.Where(x => x.StudentId == model.StudentId).FirstOrDefault();
            if (student!=null)
            {
                string filename = "";
                if (model.picpath != null)
                {
                    string path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/pics");
                    FileInfo dr = new FileInfo(model.picpath.FileName);
                    string newfilename = DateTime.Now.ToString("yyyymmddmmss");
                    filename = newfilename + dr.Extension;
                    string filewithpath = Path.Combine(path, filename);
                    using (var stream = new FileStream(filewithpath, FileMode.Create))
                    {
                        model.picpath.CopyTo(stream);
                    }
                }
                student.StudentName = model.StudentName;
                student.DepartmentId = model.DepartmentId;
                student.Email = model.Email;
                student.Dob = model.Dob;
                student.Shift = model.Shift;
                student.Photo = filename;
                ctx.SaveChanges();
                res = new
                {
                    resstate = true
                };

            }

            return Json(res);
        }

        [HttpDelete]
        public IActionResult Studentdelete(int id)
        {
            
            object res = null;
            var student = ctx.Students.Where(x => x.StudentId == id).FirstOrDefault();
            if (student!= null)
            {
                ctx.Students.Remove(student);
                ctx.SaveChanges();
                res = new
                {
                    resstate = true
                };

            }

            return Json(res);
        }
    }
}
