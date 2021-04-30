using Base.Interfaces;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;

namespace Structure.Data
{
    public class Uom : IUom
    {
        private readonly SchoolContext _context;
        private readonly ILoggerFactory _logger;

        public Uom(SchoolContext context, ILoggerFactory logger)
        {
            _context = context;
            _logger = logger;
        }

        public IStudentRepository studentRepository => new StudentRepository(_context);

        public ISchoolRepository schoolRepository => new SchoolRepository(_context);
        public IClassRepository classRepository => new ClassRepository(_context, _logger);
    }
}
