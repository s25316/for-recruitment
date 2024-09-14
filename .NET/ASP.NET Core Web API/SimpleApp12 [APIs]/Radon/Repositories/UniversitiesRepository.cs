using Radon.AggregatesAndEntities.Institutions.CustomResponse.Aggregates;
using Radon.AggregatesAndEntities.Shared.Responses;
using Radon.CustomExceptions;
using Radon.Repositories.Deserialization;
using Radon.Repositories.Url;

namespace Radon.Repositories
{
    public class UniversitiesRepository : IUniversitiesRepository
    {
        public readonly IUrlRepository _urlRepository;
        public readonly IDeserializationRepository _deserialization;
        public UniversitiesRepository
            (
            IUrlRepository urlRepository,
            IDeserializationRepository deserialization
            )
        {
            _urlRepository = urlRepository;
            _deserialization = deserialization;
        }

        //=====================================================================================================================================
        //=====================================================================================================================================
        //https://radon.nauka.gov.pl/api/katalog-udostepniania-danych/dane-polon/polon/reports_course
        /// <summary>
        /// Pobierz dane żrodłowe
        /// </summary>
        /// <param name="universityId"></param>
        /// <param name="cancellation"></param>
        /// <returns></returns>        
        public async Task<ResponseList<AggregatesAndEntities.Courses.CoreResponse.Level1.Course>> GetCoursesSourceDataAsync
            (
            Guid universityId,
            CancellationToken cancellation
            )
        {
            try
            {
                var url = _urlRepository.GenerateUrlForGettingCoursesList(universityId);
                var body = await MakeRequestAndReturnBody(url, cancellation);
                var result = _deserialization.DeserializationCoursesListAndToken(body);

                var courses = result.Item1;
                var token = result.Item2;

                while (!string.IsNullOrEmpty(token))
                {
                    url = _urlRepository.GenerateUrlForGettingCoursesListWithToken(universityId, token);
                    body = await MakeRequestAndReturnBody(url, cancellation);
                    result = _deserialization.DeserializationCoursesListAndToken(body);

                    var coursesNext = result.Item1;
                    token = result.Item2;

                    if (coursesNext.Any())
                    {
                        courses = courses.Concat(coursesNext);
                    }
                }

                return new ResponseList<AggregatesAndEntities.Courses.CoreResponse.Level1.Course>
                {
                    IsSuccess = true,
                    Problem = EnumProblemTypes.None,
                    MessageForUser = Messages.ResponseMessageForUserSuccess,
                    MessageForAdmin = Messages.ResponseMessageForAdminSuccess,
                    Items = courses,
                    Count = courses.Count()
                };
            }
            catch (Exception ex)
            {
                return ResponseList<AggregatesAndEntities.Courses.CoreResponse.Level1.Course>
                    .FromTemplate(HandleExceptionAndReturnResponse(ex));
            }
        }


        /// <summary>
        /// Pobierz dane odseparowane 
        /// </summary>
        /// <param name="universityId"></param>
        /// <param name="cancellation"></param>
        /// <returns></returns>
        public async Task<ResponseList<AggregatesAndEntities.Courses.CustomResponse.Course>> GetCoursesCustomDataAsync
            (
            Guid universityId,
            CancellationToken cancellation
            )
        {
            var coreResponse = await GetCoursesSourceDataAsync(universityId, cancellation);
            var courses = coreResponse.Items
                .Select(courseMain => courseMain.CourseInstances
                .Select(courseInstance => new AggregatesAndEntities.Courses.CustomResponse.Course(courseInstance, courseMain))
                .ToList()
                ).SelectMany(list => list)
                .ToList();

            return new ResponseList<AggregatesAndEntities.Courses.CustomResponse.Course>
            {
                IsSuccess = coreResponse.IsSuccess,
                Problem = coreResponse.Problem,
                MessageForUser = coreResponse.MessageForUser,
                MessageForAdmin = coreResponse.MessageForAdmin,
                Items = courses,
                Count = courses.Count()
            };
        }

        //=====================================================================================================================================
        //=====================================================================================================================================
        //https://radon.nauka.gov.pl/api/katalog-udostepniania-danych/dane-polon/polon/reports_institution
        /// <summary>
        /// Pobierz dane żrodłowe
        /// </summary>
        /// <param name="universityId"></param>
        /// <param name="cancellation"></param>
        /// <returns></returns>
        public async Task<Response<AggregatesAndEntities.Institutions.CoreResponse.Level1.University>> GetUniversitySourceDataAsync
            (
            Guid universityId,
            CancellationToken cancellation
            )
        {
            try
            {
                var url = _urlRepository.GenerateUrlForGettingUniversity(universityId);

                var body = await MakeRequestAndReturnBody(url, cancellation);
                var university = _deserialization.DeserializationUniversityData(body);

                return new Response<AggregatesAndEntities.Institutions.CoreResponse.Level1.University>
                {
                    IsSuccess = true,
                    Problem = EnumProblemTypes.None,
                    MessageForUser = Messages.ResponseMessageForUserSuccess,
                    MessageForAdmin = Messages.ResponseMessageForAdminSuccess,
                    Item = university,
                };
            }
            catch (Exception ex)
            {
                return Response<AggregatesAndEntities.Institutions.CoreResponse.Level1.University>
                    .FromTemplate(HandleExceptionAndReturnResponse(ex));
            }
        }


        /// <summary>
        /// Pobierz dane odseparowane 
        /// </summary>
        /// <param name="universityId"></param>
        /// <param name="cancellation"></param>
        /// <returns></returns>
        public async Task<Response<AggregatesAndEntities.Institutions.CustomResponse.Aggregates.University>> GetUniversityCustomDataAsync
           (
           Guid universityId,
           CancellationToken cancellation
           )
        {
            var coreResponse = await GetUniversitySourceDataAsync(universityId, cancellation);
            var customResponse = new Response<AggregatesAndEntities.Institutions.CustomResponse.Aggregates.University>
            {
                IsSuccess = coreResponse.IsSuccess,
                Problem = coreResponse.Problem,
                MessageForUser = coreResponse.MessageForUser,
                MessageForAdmin = coreResponse.MessageForAdmin,
            };

            if (coreResponse.Item == null || !coreResponse.IsSuccess)
            {
                return customResponse;
            }

            customResponse.Item = (University)coreResponse.Item;
            return customResponse;
        }

        //=====================================================================================================================================
        //=====================================================================================================================================
        //https://radon.nauka.gov.pl/api/katalog-udostepniania-danych/dane-polon/polon/reports_institution
        /// <summary>
        /// Pobierz dane żrodłowe
        /// </summary>
        /// <param name="universityId"></param>
        /// <param name="cancellation"></param>
        /// <returns></returns>
        public async Task<ResponseList<AggregatesAndEntities.Branches.CoreResponse.Level1.Branch>> GetBranchesSourceDataAsync
            (
            Guid universityId,
            CancellationToken cancellation
            )
        {
            try
            {
                var url = _urlRepository.GenerateUrlForGettingBranchesList(universityId);
                var body = await MakeRequestAndReturnBody(url, cancellation);
                var result = _deserialization.DeserializationBranchesListAndToken(body);

                var branches = result.Item1;
                var token = result.Item2;

                while (!string.IsNullOrEmpty(token))
                {
                    url = _urlRepository.GenerateUrlForGettingBranchesListWithToken(universityId, token);
                    body = await MakeRequestAndReturnBody(url, cancellation);
                    result = _deserialization.DeserializationBranchesListAndToken(body);

                    var branchesNext = result.Item1;
                    token = result.Item2;

                    if (branchesNext.Any())
                    {
                        branches = branches.Concat(branchesNext);
                    }
                }

                return new ResponseList<AggregatesAndEntities.Branches.CoreResponse.Level1.Branch>
                {
                    IsSuccess = true,
                    Problem = EnumProblemTypes.None,
                    MessageForUser = Messages.ResponseMessageForUserSuccess,
                    MessageForAdmin = Messages.ResponseMessageForAdminSuccess,
                    Items = branches,
                    Count = branches.Count()
                };
            }
            catch (Exception ex)
            {
                return ResponseList<AggregatesAndEntities.Branches.CoreResponse.Level1.Branch>
                    .FromTemplate(HandleExceptionAndReturnResponse(ex));
            }
        }

        /// <summary>
        /// Pobierz dane odseparowane 
        /// </summary>
        /// <param name="universityId"></param>
        /// <param name="cancellation"></param>
        /// <returns></returns>
        public async Task<ResponseList<AggregatesAndEntities.Branches.CustomResponse.Aggregates.Branch>> GetBranchesCustomDataAsync
           (
           Guid universityId,
           CancellationToken cancellation
           )
        {
            var coreResponse = await GetBranchesSourceDataAsync(universityId, cancellation);
            var branches = coreResponse.Items
                .Select(branch => new AggregatesAndEntities.Branches.CustomResponse.Aggregates.Branch(branch))
                .ToList();

            return new ResponseList<AggregatesAndEntities.Branches.CustomResponse.Aggregates.Branch>
            {
                IsSuccess = coreResponse.IsSuccess,
                Problem = coreResponse.Problem,
                MessageForUser = coreResponse.MessageForUser,
                MessageForAdmin = coreResponse.MessageForAdmin,
                Items = branches,
                Count = branches.Count()
            };
        }

        //=======================================================================================================================================
        //=======================================================================================================================================
        //Private Methods
        //=======================================================================================================================================
        private async Task<string> MakeRequestAndReturnBody
            (
            string url,
            CancellationToken cancellation
            )
        {
            using (var client = new HttpClient())
            using (var response = await client.GetAsync(url, cancellation))
            {
                return await response.Content.ReadAsStringAsync(cancellation);
            }
        }

        private ResponseTemplate HandleExceptionAndReturnResponse(Exception exception)
        {
            if (exception is UserException ex)
            {
                return new ResponseTemplate
                {
                    IsSuccess = false,
                    Problem = EnumProblemTypes.UserProblem,
                    MessageForUser = ex.Message,
                    MessageForAdmin = Messages.ResponseMessageForAdminUserProblem,
                };
            }
            else
            {
                return new ResponseTemplate
                {
                    IsSuccess = false,
                    Problem = EnumProblemTypes.AppProblem,
                    MessageForUser = Messages.ResponseMessageForUserAppProblem,
                    MessageForAdmin = $"Exception: {exception.GetType().FullName}; {exception.Message}",
                };
            }
        }

    }
}
