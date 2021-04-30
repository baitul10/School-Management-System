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
            var result = await _context.Students.AddAsync(student);
            await  _context.SaveChangesAsync();
            return result.Entity;
        }

        public async Task DeleteAsync(Student student)
        {
             _context.Students.Remove(student);
            await _context.SaveChangesAsync();
        }


        public async Task<IReadOnlyList<Student>> GetAsync()
        {
            var students = await _context.Students.ToListAsync();
            await _context.SaveChangesAsync();
            return students;
        }

        public async Task<Student> GetAsync(int id)
        {
            var students = await _context.Students.FirstOrDefaultAsync(x => x.id == id);
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
