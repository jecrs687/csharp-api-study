using System;
using dot_net_api_study.Business.Dto.Requests;
using dot_net_api_study.Business.Dto.Responses;

namespace dot_net_api_study.Business.Interfaces.Services
{
	public interface ICarService
	{
        GetCarResponse GetCar(int id);
        PostCarResponse PostCar(
           PostCarRequest car
           );


    }
}

