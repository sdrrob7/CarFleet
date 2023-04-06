using BusinessLayer.Contacts;
using BusinessLayer.Services;
using Microsoft.AspNetCore.Mvc;
using SharedModel;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CarFleet.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ColorController : ControllerBase
    {
        private readonly IColorService _colorService;
        public ColorController(IColorService colorService)
        {
            _colorService = colorService;
        }
        [Route("GetAll")]
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var response = await _colorService.GetAllAsync();
            if (response != null)
                return Ok(response);
            else
                return BadRequest("Record Not Found");
        }
        [Route("Details/{id}")]
        [HttpGet]
        public async Task<IActionResult> Get(int id)
        {
            var response = await _colorService.GetByIdAsync(id);
            if (response != null)
                return Ok(response);
            else
                return BadRequest("Record Not Found");
        }
        [Route("Add")]
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CarColor model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            await _colorService.InsertAsync(model);
            return Ok("Added Successfully");
        }
        [Route("Update")]
        [HttpPut]
        public async Task<IActionResult> Put([FromBody] CarColor model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            await _colorService.UpdateAsync(model);
            return Ok("Updated Successfully");
        }
        [HttpDelete]
        [Route("Delete/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _colorService.DeleteAsync(id);
            return Ok("Deleted Successfully");
        }
    }
}
