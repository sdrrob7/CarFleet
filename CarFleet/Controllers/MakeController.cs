using BusinessLayer.Contacts;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SharedModel;

namespace CarFleet.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MakeController : ControllerBase
    {
        private readonly IMakeService MakeService;
        public MakeController(IMakeService makeService)
        {
            MakeService = makeService;
        }
        [HttpGet]
        [Route("GetAll")]
        public async Task<IActionResult> Get()
        {
            var response = await MakeService.GetAllAsync();
            if (response != null)
                return Ok(response);
            else
                return BadRequest("Record Not Found");
        }
        [HttpGet]
        [Route("Details/{Id}")]
        public async Task<IActionResult> Get(int Id)
        {
            var response = await MakeService.GetByIdAsync(Id);
            if (response != null)
                return Ok(response);
            else
                return BadRequest("Record Not Found");
        }
        [HttpPost]
        [Route("Add")]
        public async Task<IActionResult> Post(CarMake model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            await MakeService.InsertAsync(model);
            return Ok("Added Successfully");
        }
        [HttpPut]
        [Route("Update")]
        public async Task<IActionResult> Put(CarMake model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            await MakeService.UpdateAsync(model);
            return Ok("Updated Successfully");
        }
        [HttpDelete]
        [Route("Delete/{Id}")]
        public async Task<IActionResult> Delete(int Id)
        {
            await MakeService.DeleteAsync(Id);
            return Ok("Deleted Successfully");
        }
    }
}
