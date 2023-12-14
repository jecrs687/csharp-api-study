using dot_net_api_study.Business.Dto.Responses;

namespace dot_net_api_study.Business.Interfaces.Clients
{
        public interface IGiuseppinBeeceptorClient
        {
                Task<GetGiuseppinResponseClient> GetGiuseppin(int id);
        }
}

