using System;
using dot_net_api_study.Business.Configurations;
using dot_net_api_study.Business.Dto.Requests;
using dot_net_api_study.Business.Dto.Responses;
using dot_net_api_study.Business.Interfaces.Clients;
using dot_net_api_study.Business.Interfaces.Services;
using dot_net_api_study.Business.Models;
using Microsoft.Extensions.Configuration;

namespace dot_net_api_study.Business.Services
{
	public class CarService:ICarService
	{
		private readonly CarConfig _carConfig;
		private readonly IConfiguration _configuration;
		private readonly IGiuseppinBeeceptorClient _responseClient;

		private List<Car> cars;
		public CarService(
			CarConfig carConfig, 
			IConfiguration configuration,
			 IGiuseppinBeeceptorClient responseClient
			)
		{
			_carConfig = carConfig;
			_configuration = configuration;
			_responseClient = responseClient;

			cars = new()
		{
			new Car() {
				id = 2,
				cor = _configuration.GetSection("CarConfig").GetSection("Color").Value,
			}
		};
		}
		public async Task<GetGiuseppinResponseClient> GetGiuseppin(int id)
		{
			return await _responseClient.GetGiuseppin(id);
		}
		public PostCarResponse PostCar(
			PostCarRequest car
			)
		{
			if (string.IsNullOrEmpty(car.cor))
				return null;
			Car carDto = new Car()
			{
				cor = car.cor,
				id = new Random().Next()
			};
			cars.Add(carDto);
			return new PostCarResponse()
			{
				id = carDto.id
			};

		}
	}
}

