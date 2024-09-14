using Regon.AggregatesAndEntities.Responses;
using Regon.Repositories.Requests;
using Regon.ValueObjectsAndTheirExceptions.NipValue;
using Regon.ValueObjectsAndTheirExceptions.RegonValue;
using Regon.ValueObjectsAndTheirExceptions.UserKeyValue;

namespace Regon.Repositories
{
    public class RegonRepository : IRegonRepository
    {
        private readonly IRequestsRepository _requests;

        public RegonRepository
            (
            IRequestsRepository requests
            )
        {
            _requests = requests;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="nip"></param>
        /// <param name="userKey"></param>
        /// <param name="cancellation"></param>
        /// <param name="askProductionEndpoint"></param>
        /// <returns></returns>
        public async Task<Response<AggregatesAndEntities.DanePobierzPelnyRaport.CoreResponse.Level5DaneClasses.DanePelne>> GetCompanyByNipSourceDataAsync
            (
            string nip,
            string userKey,
            CancellationToken cancellation,
            bool askProductionEndpoint = true
            )
        {
            try
            {
                var nipValue = new Nip(nip);
                var key = new UserKey(userKey);

                var sid = await _requests.ZalogujRequestAndReturnSidAsync(key, cancellation, askProductionEndpoint);
                var danePodstawowe = await _requests.DaneSzukajByNipRequestAsync(nipValue, sid, cancellation, askProductionEndpoint);
                var danePelne = await _requests.DanePobierzPelnyRaportRequestAsync(danePodstawowe, sid, cancellation, askProductionEndpoint);
                await _requests.WylogujRequestAsync(sid, cancellation, askProductionEndpoint);

                return new Response<AggregatesAndEntities.DanePobierzPelnyRaport.CoreResponse.Level5DaneClasses.DanePelne>
                {
                    IsSuccess = true,
                    Problem = EnumProblemTypes.None,
                    MessageForAdmin = Messages.ResponseMessageForAdminSuccess,
                    MessageForUser = Messages.ResponseMessageForUserSuccess,
                    Item = danePelne,
                };
            }
            catch (Exception ex)
            {
                return HandleExeptions<AggregatesAndEntities.DanePobierzPelnyRaport.CoreResponse.Level5DaneClasses.DanePelne>(ex);
            }
        }

        public async Task<Response<AggregatesAndEntities.DanePobierzPelnyRaport.CustomResponse.Aggregates.Company>> GetCompanyByNipCustomDataAsync
            (
            string nip,
            string userKey,
            CancellationToken cancellation,
            bool askProductionEndpoint = true
            )
        {
            var result = await GetCompanyByNipSourceDataAsync(nip, userKey, cancellation, askProductionEndpoint);
            var response = new Response<AggregatesAndEntities.DanePobierzPelnyRaport.CustomResponse.Aggregates.Company>
            {
                IsSuccess = result.IsSuccess,
                Problem = result.Problem,
                MessageForAdmin = result.MessageForAdmin,
                MessageForUser = result.MessageForUser,
            };

            if (!result.IsSuccess || result.Problem != EnumProblemTypes.None || result.Item == null)
            {
                return response;
            }
            response.Item = new AggregatesAndEntities.DanePobierzPelnyRaport.CustomResponse.Aggregates.Company(result.Item);
            return response;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="regon"></param>
        /// <param name="userKey"></param>
        /// <param name="cancellation"></param>
        /// <param name="askProductionEndpoint"></param>
        /// <returns></returns>
        public async Task<Response<AggregatesAndEntities.DanePobierzPelnyRaport.CoreResponse.Level5DaneClasses.DanePelne>> GetCompanyByRegonSourceDataAsync
            (
            string regon,
            string userKey,
            CancellationToken cancellation,
            bool askProductionEndpoint = true
            )
        {
            try
            {
                var regonValue = new Regon.ValueObjectsAndTheirExceptions.RegonValue.Regon { Number = regon, };
                var key = new UserKey(userKey);

                var sid = await _requests.ZalogujRequestAndReturnSidAsync(key, cancellation, askProductionEndpoint);
                var danePodstawowe = await _requests.DaneSzukajByRegonRequestAsync(regonValue, sid, cancellation, askProductionEndpoint);
                var danePelne = await _requests.DanePobierzPelnyRaportRequestAsync(danePodstawowe, sid, cancellation, askProductionEndpoint);
                await _requests.WylogujRequestAsync(sid, cancellation, askProductionEndpoint);

                return new Response<AggregatesAndEntities.DanePobierzPelnyRaport.CoreResponse.Level5DaneClasses.DanePelne>
                {
                    IsSuccess = true,
                    Problem = EnumProblemTypes.None,
                    MessageForAdmin = Messages.ResponseMessageForAdminSuccess,
                    MessageForUser = Messages.ResponseMessageForUserSuccess,
                    Item = danePelne,
                };
            }
            catch (Exception ex)
            {
                return HandleExeptions<AggregatesAndEntities.DanePobierzPelnyRaport.CoreResponse.Level5DaneClasses.DanePelne>(ex);
            }
        }


        public async Task<Response<AggregatesAndEntities.DanePobierzPelnyRaport.CustomResponse.Aggregates.Company>> GetCompanyByRegonCustomDataAsync
            (
            string regon,
            string userKey,
            CancellationToken cancellation,
            bool askProductionEndpoint = true
            )
        {
            var result = await GetCompanyByRegonSourceDataAsync(regon, userKey, cancellation, askProductionEndpoint);
            var response = new Response<AggregatesAndEntities.DanePobierzPelnyRaport.CustomResponse.Aggregates.Company>
            {
                IsSuccess = result.IsSuccess,
                Problem = result.Problem,
                MessageForAdmin = result.MessageForAdmin,
                MessageForUser = result.MessageForUser,
            };

            if (!result.IsSuccess || result.Problem != EnumProblemTypes.None || result.Item == null)
            {
                return response;
            }
            response.Item = new AggregatesAndEntities.DanePobierzPelnyRaport.CustomResponse.Aggregates.Company(result.Item);
            return response;
        }

        //===================================================================================================================================================
        //===================================================================================================================================================
        //Private Methods
        //===================================================================================================================================================
        private Response<T> HandleExeptions<T>(Exception ex) where T : class
        {
            if (ex is NipException)
            {
                return CreateResponseForClient<T>(ex);
            }
            if (ex is RegonException)
            {
                return CreateResponseForClient<T>(ex);
            }
            if (ex is UserKeyException)
            {
                return CreateResponseForClient<T>(ex);
            }
            return CreateResponseForClientAndAdmin<T>(ex);
        }

        private Response<T> CreateResponseForClient<T>(Exception ex) where T : class
        {
            return new Response<T>
            {
                IsSuccess = false,
                Problem = EnumProblemTypes.UserProblem,
                MessageForAdmin = Messages.ResponseMessageForAdminUserProblem,
                MessageForUser = ex.Message,
                Item = null,
            };
        }

        private Response<T> CreateResponseForClientAndAdmin<T>(Exception ex) where T : class
        {
            return new Response<T>
            {
                IsSuccess = false,
                Problem = EnumProblemTypes.AppProblem,
                MessageForAdmin = ex.Message,
                MessageForUser = Messages.ResponseMessageForUserAppProblem,
                Item = null,
            };
        }
    }
}
