using System.Collections.Generic;
using System.Threading.Tasks;
using Base.Entities;
using Base.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace SchoolProj.Controllers
{
    public class ClassesController : BaseController
    {
        private readonly IUom _uom;

        public object JsonSerilizer { get; private set; }

        public ClassesController(IUom uom)
        {
            _uom = uom;
        }
        [HttpGet]
        public async Task<ActionResult<IReadOnlyList<Classes>>> GetAllSchool()
        {
            var clss = await _uom.classRepository.GetAsync();
            if(clss!=null)
            return Ok(clss);

            return NotFound("data Not Found");
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<Classes>> GetClassById(int id)
        {
            var clss = await _uom.classRepository.GetAsync(id);
            return Ok(clss);
        }
        [HttpPost]
        public async Task<ActionResult<Classes>> CreateClass([FromBody] Classes classes)
        {
            //var json = JsonSerializer.Serialize(classes);
            var clss = await _uom.classRepository.CreateAsync(classes);
            return Ok(clss);
        }
        [HttpPut]
        public async Task<ActionResult<Classes>> UpdateClass(Classes classes)
        {
            var clss = await _uom.classRepository.UpdateAsync(classes);
            return Ok(clss);
        }
        [HttpDelete]
        public async Task<ActionResult> DeleteClass(Classes classes)
        {
            await _uom.classRepository.DeleteAsync(classes);
            return Ok();
        }
    }
}
