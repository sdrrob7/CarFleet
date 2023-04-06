using BusinessLayer.Contacts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SharedModel;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CarFleet.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarController : ControllerBase
    {
        private readonly ICarService CarService;
        public CarController(ICarService carService)
        {
            CarService = carService;
        }
        [HttpGet]
        [Route("getCars")]
        public async Task<IActionResult> GetAll(string? make)
        {
            var response = new List<CarViewModel>();
            int MakeId;
            if (!string.IsNullOrEmpty(make))
            {
                if (int.TryParse(make, out MakeId) && MakeId > 0)
                    response = (List<CarViewModel>)await CarService.GetAllCarsByMakeId(MakeId);
                else
                    response = (List<CarViewModel>)await CarService.GetAllCarsByMakeName(make);
            }
            else
                response = (List<CarViewModel>)await CarService.GetAllAsync();
            if (response != null && response.Count() > 0)
                return Ok(response);
            else
                return BadRequest("Record Not Found");
        }
        [HttpGet]
        [Route("Details/{Id}")]
        public async Task<IActionResult> Get(int Id)
        {
            var response = await CarService.GetByIdAsync(Id);
            if (response != null)
                return Ok(response);
            else
                return BadRequest("Record Not Found");
        }
        [HttpPost]
        [Route("updateInsertCar")]
        public async Task<IActionResult> Post(CarModelBind model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var data = await CarService.GetByIdAsync(model.Id);
            if (data != null)
            {
                await CarService.UpdateAsync(model);
                return Ok("Updated Successfully");
            }
            else
            {
                await CarService.InsertAsync(model);
                return Ok("Added Successfully");
            }
        }
        //[HttpPut]
        //[Route("Update")]
        //public async Task<IActionResult> Put(Car model)
        //{
        //    if (!ModelState.IsValid)
        //        return BadRequest(ModelState);
        //    await CarService.UpdateAsync(model);
        //    return Ok("Updated Successfully");
        //}
        [HttpDelete]
        [Route("Delete/{Id}")]
        public async Task<IActionResult> Delete(int Id)
        {
            await CarService.DeleteAsync(Id);
            return Ok("Deleted Successfully");
        }
    }
}
