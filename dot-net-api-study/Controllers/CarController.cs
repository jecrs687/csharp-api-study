using System;
using dot_net_api_study.Business.Dto.Requests;
using dot_net_api_study.Business.Dto.Responses;
using dot_net_api_study.Business.Interfaces.Producers;
using dot_net_api_study.Business.Interfaces.Services;
using dot_net_api_study.Business.Models;
using dot_net_api_study.Business.Services;
using Microsoft.AspNetCore.Mvc;

namespace dot_net_api_study.Api.Controllers
{
	[ApiController]
	[Route("api/v1/[controller]")]
	public class CarController: ControllerBase
	{
		private readonly ICarService _carService;
		private readonly IKafkaProducer _producer;
        public CarController(ICarService carService, IKafkaProducer producer)
        {
            _carService = carService;
			_producer = producer;
        }

        [HttpGet]
		[Route("{id}")]
		public async Task<IActionResult> Test([FromRoute] int id, [FromServices] ICarService carService)
		{
			//var car = await carService.GetGiuseppin(id);
			Car carProduced = new Car
			{
				cor = "black",
				id = 123,
			};
			await _producer.producer(carProduced);
			return Ok(carProduced);
			//if (car is null)
			//	return NotFound();
		
			//return Ok(car);
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

