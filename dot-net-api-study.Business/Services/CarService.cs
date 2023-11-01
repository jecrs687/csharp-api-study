using System;
using dot_net_api_study.Business.Dto.Requests;
using dot_net_api_study.Business.Dto.Responses;
using dot_net_api_study.Business.Models;

namespace dot_net_api_study.Business.Services
{
	public class CarService
	{
        private List<Car> cars = new()
		{
			new Car() {
				id = 2,
				cor = "teste"
			}
		}; 
		public CarService()
        {
        }
        public GetCarResponse GetCar(int id)
		{
            Car car = cars.Where(x => x.id == id).FirstOrDefault();
			if (car is null) return null;

			GetCarResponse carResponse = new()
			{
				id = car.id,
				cor = car.cor
			};

			return carResponse;
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

