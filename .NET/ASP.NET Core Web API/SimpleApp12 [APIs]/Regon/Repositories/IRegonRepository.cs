using Regon.AggregatesAndEntities.Responses;

namespace Regon.Repositories
{
    public interface IRegonRepository
    {
        Task<Response<AggregatesAndEntities.DanePobierzPelnyRaport.CoreResponse.Level5DaneClasses.DanePelne>> GetCompanyByNipSourceDataAsync
           (
           string nip,
           string userKey,
           CancellationToken cancellation,
           bool askProductionEndpoint = true
           );
        Task<Response<AggregatesAndEntities.DanePobierzPelnyRaport.CustomResponse.Aggregates.Company>> GetCompanyByNipCustomDataAsync
            (
            string nip,
            string userKey,
            CancellationToken cancellation,
            bool askProductionEndpoint = true
            );

        Task<Response<AggregatesAndEntities.DanePobierzPelnyRaport.CoreResponse.Level5DaneClasses.DanePelne>> GetCompanyByRegonSourceDataAsync
           (
           string regon,
           string userKey,
           CancellationToken cancellation,
           bool askProductionEndpoint = true
           );
        Task<Response<AggregatesAndEntities.DanePobierzPelnyRaport.CustomResponse.Aggregates.Company>> GetCompanyByRegonCustomDataAsync
            (
            string regon,
            string userKey,
            CancellationToken cancellation,
            bool askProductionEndpoint = true
            );
    }
}
