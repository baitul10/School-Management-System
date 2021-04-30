using Base.Entities;
using Base.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Structure.Data
{
    internal class ClassRepository : IClassRepository
    {
        private readonly SchoolContext _context;
        private readonly ILoggerFactory _logger;

        public ClassRepository(SchoolContext context, ILoggerFactory logger)
        {
            _context = context;
            _logger = logger;
        }

        public async Task<Classes> CreateAsync(Classes classes)
        {
            try
            {
                var clss = await _context.Classes.AddAsync(classes);
                await _context.SaveChangesAsync();
                return clss.Entity;
            }
            catch (Exception ex)
            {
                var logger = _logger.CreateLogger<ClassRepository>();
                logger.LogError(ex.Message);
                return null;
            }

        }

        public async Task DeleteAsync(Classes classes)
        {
            _context.Classes.Remove(classes);
            await _context.SaveChangesAsync();
        }

        public async Task<IReadOnlyList<Classes>> GetAsync()
        {
            var clss = await _context.Classes.ToListAsync();
            return clss;
        }

        public async Task<Classes> GetAsync(int id)
        {
            var clss = await _context.Classes.FirstOrDefaultAsync(x => x.id == id);
            return clss;
        }

        public async Task<Classes> UpdateAsync(Classes classes)
        {
            var clss = _context.Classes.Update(classes);
            await _context.SaveChangesAsync();
            return clss.Entity;
        }
    }
}