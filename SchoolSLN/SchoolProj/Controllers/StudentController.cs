using Base.DTOs;
using Base.Entities;
using Base.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolProj.Controllers
{
    public class StudentController : BaseController
    {
        private readonly IUom _uom;
        public StudentController(IUom uom)
        {
            _uom = uom;
        }

        [HttpGet]
        public async Task<ActionResult<IReadOnlyList<StudentDto>>> GetAllStudents()
        {
            var students = await _uom.studentRepository.GetAsync();
            return Ok(students.Select(student=>new StudentDto
            {
                Name = student.Name,
                Roll = student.Roll,
                Phone = student.Phone,
                Email = student.Email,
                Classes = student.Classes.Name,
                School = student.School.Name
            }));
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<StudentDto>> GetStudentById(int id)
        {
            var students = await _uom.studentRepository.GetAsync(id);
            //var studentDto = new StudentDto
            //{
            //    Name = students.Name,
            //    Roll = students.Roll,
            //    Phone = students.Phone,
            //    Email = students.Email,
            //    School = students.School.Name,
            //    Classes = students.Classes.Name
            //};
            //return Ok(students);
            return Ok(new StudentDto
            {
                Name = students.Name,
                Roll = students.Roll,
                Phone = students.Phone,
                Email = students.Email,
                Classes = students.Classes.Name,
                School = students.School.Name
            });
        }

        [HttpPost]
        public async Task<ActionResult<Student>> CreateStudent(NewStudentDto student)
        {
            var students = new Student
            {
                Name = student.Name,
                Roll = student.Roll,
                Phone = student.Phone,
                Email = student.Email,
                ClassesId = student.ClassesId,
                SchoolId = student.SchoolId
            };
                
            var createdData = await _uom.studentRepository.CreateAsync(students);
            return Ok(createdData);
        }

        [HttpPut]
        public async Task<ActionResult<Student>> UpdateStudent(NewStudentDto studentDto)
        {
            var student = new Student
            {
                Name = studentDto.Name,
                Roll = studentDto.Roll,
                Phone = studentDto.Phone,
                Email = studentDto.Email,
                ClassesId = studentDto.ClassesId,
                SchoolId = studentDto.SchoolId
            };
            var students = await _uom.studentRepository.UpdateAsync(student);

            return Ok(students);
        }
        [HttpDelete]
        public async Task<ActionResult> DeleteStudent(Student student)
        {
            await _uom.studentRepository.DeleteAsync(student);
            return Ok();
        }
    }
}
