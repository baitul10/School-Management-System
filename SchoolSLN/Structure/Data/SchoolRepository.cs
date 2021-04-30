using Base.Entities;
using Base.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Structure.Data
{
    public class SchoolRepository : ISchoolRepository
    {
        private readonly SchoolContext _context;

        public SchoolRepository(SchoolContext context)
        {
            _context = context;
        }

        public async Task<School> CreateAsync(School school)
        {
            var schools = await _context.Schools.AddAsync(school);
            await _context.SaveChangesAsync();
            return schools.Entity;
        }

        public async Task DeleteAsync(School school)
        {
            _context.Schools.Remove(school);
            await _context.SaveChangesAsync();
        }

        public async Task<IReadOnlyList<School>> GetAsync()
        {
            var schools = await _context.Schools.ToListAsync();
            return schools;
        }

        public Task<School> GetAsync(int id)
        {
            var schools = _context.Schools.FirstOrDefaultAsync(x => x.id == id);
            return schools;
        }

        public async Task<School> UpdateAsync(School school)
        {
            var schools = _context.Schools.Update(school);
            await _context.SaveChangesAsync();
            return schools.Entity;
        }
    }
}
