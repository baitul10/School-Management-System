using System.Collections.Generic;
using System.Threading.Tasks;
using Base.Entities;
using Base.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace SchoolProj.Controllers
{
    public class SchoolController : BaseController
    {
        private readonly IUom _uom;
        public SchoolController(IUom uom)
        {
            _uom = uom;
        }

        [HttpGet]
        public async Task<ActionResult<IReadOnlyList<School>>> GetAllSchool()
        {
            var schools = await _uom.schoolRepository.GetAsync();
            return Ok(schools);
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<School>> GetSchoolById(int id)
        {
            var schools = await _uom.schoolRepository.GetAsync(id);
            return Ok(schools);
        }
        [HttpPost]
        public async Task<ActionResult<School>> CreateSchool(School school)
        {
            var schools = await _uom.schoolRepository.CreateAsync(school);
            return Ok(schools);
        }
        [HttpPut]
        public async Task<ActionResult<School>> UpdateSchool(School school)
        {
            var schools = await _uom.schoolRepository.UpdateAsync(school);
            return Ok(schools);
        }
        [HttpDelete]
        public async Task<ActionResult<School>> DeleteSchool(School school)
        {
            await _uom.schoolRepository.DeleteAsync(school);
            return Ok();
        }
    }
}
