using Base.Entities;
using Base.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Structure.Data
{
    public class StudentRepository : IStudentRepository
    {
        private readonly SchoolContext _context;
        public StudentRepository(SchoolContext context)
        {
            _context = context;
        }

        public async Task<Student> CreateAsync(Student student)
        {
            var result = new Student
            {
                Name = student.Name,
                Roll = student.Roll,
                Phone = student.Phone,
                Email = student.Email,
                ClassesId = student.ClassesId,
                SchoolId = student.SchoolId
            };
                
                
                
            await _context.Students.AddAsync(result);
            await  _context.SaveChangesAsync();
            return result;
        }

        public async Task DeleteAsync(Student student)
        {
             _context.Students.Remove(student);
            await _context.SaveChangesAsync();
        }


        public async Task<IReadOnlyList<Student>> GetAsync()
        {
            var students = await _context.Students
                .Include(p=>p.Classes)
                .Include(p=>p.School)
                .ToListAsync();
            await _context.SaveChangesAsync();
            return students;
        }

        public async Task<Student> GetAsync(int id)
        {
            var students = await _context.Students
                .Include(p=>p.Classes)
                .Include(p=>p.School)
                .FirstOrDefaultAsync(x => x.id == id);
            return students;
        }

        public async Task<Student> UpdateAsync(Student student)
        {
             _context.Students.Update(student);

            await _context.SaveChangesAsync();
            return student;
        }
    }
}
