using BusinessLayer.Contacts;
using Microsoft.AspNetCore.Mvc;
using SharedModel;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CarFleet.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ModelController : ControllerBase
    {
        private readonly IModelService ModelService;
        public ModelController(IModelService modelService)
        {
            ModelService = modelService;
        }
        [HttpGet]
        [Route("GetAll")]
        public async Task<IActionResult> Get()
        {
            var response = await ModelService.GetAllAsync();
            if (response != null)
                return Ok(response);
            else
                return BadRequest("Record Not Found");
        }
        [HttpGet]
        [Route("Details/{int}")]
        public async Task<IActionResult> Get(int Id)
        {
            var response = await ModelService.GetByIdAsync(Id);
            if (response != null)
                return Ok(response);
            else
                return BadRequest("Record Not Found");
        }
        [HttpPost]
        [Route("addCarModel")]
        public async Task<IActionResult> Post([FromBody] CarModel model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            await ModelService.InsertAsync(model);
            return Ok("Added Successfully");
        }
        [HttpPut]
        [Route("Update")]
        public async Task<IActionResult> Put([FromBody] CarModel model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            await ModelService.UpdateAsync(model);
            return Ok("Updated Successfully");
        }
        [HttpDelete]
        [Route("Delete/{int}")]
        public async Task<IActionResult> Delete(int Id)
        {
            await ModelService.DeleteAsync(Id);
            return Ok("Deleted Successfully");
        }
    }
}
