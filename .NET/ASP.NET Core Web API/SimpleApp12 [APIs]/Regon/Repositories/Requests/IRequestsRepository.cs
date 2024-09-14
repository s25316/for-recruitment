using Regon.AggregatesAndEntities.DanePobierzPelnyRaport.CoreResponse.Level5DaneClasses;
using Regon.AggregatesAndEntities.DaneSzukaj.CoreResponse.Level5;
using Regon.CustomExceptions;
using Regon.ValueObjectsAndTheirExceptions.CustomDateOnlyXmlElement;
using Regon.ValueObjectsAndTheirExceptions.NipValue;
using Regon.ValueObjectsAndTheirExceptions.RegonValue;
using Regon.ValueObjectsAndTheirExceptions.SessionIdValue;
using Regon.ValueObjectsAndTheirExceptions.UserKeyValue;

namespace Regon.Repositories.Requests
{
    public interface IRequestsRepository
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="userKey"></param>
        /// <param name="cancellation"></param>
        /// <param name="askProductionEndpoint"></param>
        /// <returns></returns>
        /// <exception cref="AppException"></exception>
        /// <exception cref="UserKeyException"></exception>
        Task<SesionId> ZalogujRequestAndReturnSidAsync
                   (
                   UserKey userKey,
                   CancellationToken cancellation,
                   bool askProductionEndpoint = true
                   );

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sid"></param>
        /// <param name="cancellation"></param>
        /// <param name="askProductionEndpoint"></param>
        /// <returns></returns>    
        /// <exception cref="AppException"></exception> 
        Task<bool> WylogujRequestAsync
          (
          SesionId sid,
          CancellationToken cancellation,
          bool askProductionEndpoint = true
          );

        /// <summary>
        /// 
        /// </summary>
        /// <param name="nip"></param>
        /// <param name="sid"></param>
        /// <param name="cancellation"></param>
        /// <param name="askProductionEndpoint"></param>
        /// <returns></returns>  
        /// <exception cref="AppException"></exception> 
        /// <exception cref="NipException"></exception> 
        Task<DanePodstawowe> DaneSzukajByNipRequestAsync
            (
            Nip nip,
            SesionId sid,
            CancellationToken cancellation,
            bool askProductionEndpoint = true
            );

        /// <summary>
        /// 
        /// </summary>
        /// <param name="regon"></param>
        /// <param name="sid"></param>
        /// <param name="cancellation"></param>
        /// <param name="askProductionEndpoint"></param>
        /// <returns></returns>
        /// <exception cref="AppException"></exception> 
        /// <exception cref="RegonException"></exception> 
        Task<DanePodstawowe> DaneSzukajByRegonRequestAsync
            (
            Regon.ValueObjectsAndTheirExceptions.RegonValue.Regon regon,
            SesionId sid,
            CancellationToken cancellation,
            bool askProductionEndpoint = true
            );

        /// <summary>
        /// 
        /// </summary>
        /// <param name="dane"></param>
        /// <param name="sid"></param>
        /// <param name="cancellation"></param>
        /// <param name="askProductionEndpoint"></param>
        /// <returns></returns>
        /// <exception cref="AppException"></exception>
        /// <exception cref="CustomDateOnlyException"></exception> 
        Task<DanePelne> DanePobierzPelnyRaportRequestAsync
            (
            DanePodstawowe dane,
            SesionId sid,
            CancellationToken cancellation,
            bool askProductionEndpoint = true
            );
    }
}
