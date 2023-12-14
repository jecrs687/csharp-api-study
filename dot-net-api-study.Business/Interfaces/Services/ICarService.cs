using System;
using dot_net_api_study.Business.Dto.Requests;
using dot_net_api_study.Business.Dto.Responses;
using dot_net_api_study.Business.Models;

namespace dot_net_api_study.Business.Interfaces.Services
{
	public interface ICarService
	{
        Task<GetGiuseppinResponseClient> GetGiuseppin(int id);
        PostCarResponse PostCar(
           PostCarRequest car
           );


    }
}

