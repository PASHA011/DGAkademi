﻿using HW_2.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace HW_2.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
        IStudentService _studentService = new IStudentService();
      
    
        [HttpGet("getAll-students")]
        public List<Student> GetAllStudents()
        {
            using (HW_2Context context = new HW_2Context())
            {
                return context.Set<Student>().ToList();
            };
        }

        [HttpGet("Get-Students-By-{id}")]
        public Student Get(int id)
        {
            using (HW_2Context context = new HW_2Context())
            {
               return context.Set<Student>().Where(s=>s.Id==id).SingleOrDefault();
            };
        }

        [HttpPost("Add-Student")]
        public void Add(Student student)
        {
            using (HW_2Context context = new HW_2Context())
            {
                var addedEntity = context.Entry(student);
                addedEntity.State = EntityState.Added;
                context.SaveChanges();
            }
        }

        [HttpPut("Update-Student-{id}")]
        public IActionResult Update([FromBody]Student student,int id)
        {
            using (HW_2Context context = new HW_2Context())
            {
                var updateStudent = _studentService.UpdateStudents(id, student);
                return Ok(updateStudent);
            }
        }

        [HttpDelete("Delete-Student{id}")]
        public void Delete(Student student)
        {
            using (HW_2Context context = new HW_2Context())
            {
                var DelEntity = context.Entry(student);
                DelEntity.State = EntityState.Deleted;
                context.SaveChanges();
            }
        }
    }
}
