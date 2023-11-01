using System;
using dot_net_api_study.Business.Dto.Requests;
using dot_net_api_study.Business.Dto.Responses;
using dot_net_api_study.Business.Interfaces.Services;
using dot_net_api_study.Business.Services;
using Microsoft.AspNetCore.Mvc;

namespace dot_net_api_study.Api.Controllers
{
	[ApiController]
	[Route("api/v1/[controller]")]
	public class CarController: ControllerBase
	{
		private readonly ICarService _carService;

        public CarController(ICarService carService)
        {
            _carService = carService;
        }

        [HttpGet]
		[Route("{id}")]
		public IActionResult Test([FromRoute] int id, [FromServices] ICarService carService)
		{
			GetCarResponse car = carService.GetCar(id);

			if (car is null)
				return NotFound();

			return Ok(car);
		}

        [HttpPost]
        public IActionResult Test2([FromBody] PostCarRequest car)
        {
			PostCarResponse response = _carService.PostCar(car);

			if(response is not null)
				return Created("", response.id);

			return BadRequest("Cor vazia");
        }

    }
}

