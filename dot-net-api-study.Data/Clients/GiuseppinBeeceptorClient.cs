using dot_net_api_study.Business.Dto.Responses;
using dot_net_api_study.Business.Interfaces.Clients;
using Flurl.Http;
using System;

public class GiuseppinBeeceptorClient: IGiuseppinBeeceptorClient
{
	private readonly IFlurlClient _flurlClient;
	public GiuseppinBeeceptorClient(HttpClient httpClient)
	{
		if (httpClient is null)
			throw new ArgumentNullException(nameof(httpClient));
		_flurlClient = new FlurlClient(httpClient);
	}

	public async Task<GetGiuseppinResponseClient> GetGiuseppin(int id)
	{
		var result = await "https://giuseppin.free.beeceptor.com/andre"
			.WithClient(_flurlClient)
			.AllowAnyHttpStatus()
			.GetJsonAsync<GetGiuseppinResponseClient>();
		return result;
	}
}
