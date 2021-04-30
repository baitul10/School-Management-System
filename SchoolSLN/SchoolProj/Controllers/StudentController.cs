using Base.Entities;
using Base.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
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
        public async Task<ActionResult<IReadOnlyList<Student>>> GetAllStudents()
        {
            var students = await _uom.studentRepository.GetAsync();
            return Ok(students);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Student>> GetStudentById(int id)
        {
            var students = await _uom.studentRepository.GetAsync(id);
            return Ok(students);
        }

        [HttpPost]
        public async Task<ActionResult<Student>> CreateStudent(Student student)
        {
            var students = await _uom.studentRepository.CreateAsync(student);
            return Ok(students);
        }

        [HttpPut]
        public async Task<ActionResult<Student>> UpdateStudent(Student student)
        {
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
