using Radon.Models.Courses.MyResponse;
using System.Text.Json;

namespace Radon.Repositories
{
    public class UniversitiesRepository : IUniversitiesRepository
    {
        private readonly string _url = "https://radon.nauka.gov.pl/opendata/";
        private readonly string _coursesSegment = "polon/courses";
        private readonly string _institutionsSegment = "polon/institutions";
        private readonly string _resultNumbersQuery = "resultNumbers=";
        private readonly string _tokenQuery = "token=";

        private readonly string _leadingInstitutionUuidQuery = "leadingInstitutionUuid=";
        private readonly string _institutionUuidQuery = "institutionUuid=";
        private readonly int _maxValue = 100;

        //https://radon.nauka.gov.pl/api/katalog-udostepniania-danych/dane-polon/polon/reports_course
        public async Task<Models.Courses.MyResponse.ResponseDTO> GetCoursesListAsync
            (
            Guid universityId, 
            CancellationToken cancellation
            ) 
        {
            var urlPart1 = $"{_url}{_coursesSegment}?{_resultNumbersQuery}{_maxValue}";
            var institutionQuery = $"{_leadingInstitutionUuidQuery}{universityId.ToString().ToLower()}";

            var url = $"{urlPart1}&{institutionQuery}";

            using (var client = new HttpClient()) 
            { 
                var result = await GetTokenAndResponseAsync(client, url, cancellation);
                var token = result.Item1;
                var response = result.Item2;

                while ( !string.IsNullOrEmpty(token) ) 
                {
                    url = $"{urlPart1}&{_tokenQuery}{token}&{institutionQuery}"; 
                    var result2 = await GetTokenAndResponseAsync(client, url, cancellation);
                    token = result2.Item1;

                    //.Any() Weryfikuje czy Kolekcja ma jakiekolwiek elementy 
                    if (result2.Item2.Courses.Any())
                    {
                        response.Courses = response.Courses.Concat(result2.Item2.Courses);
                    }
                }

                response.Count = response.Courses.Count();
                return response;
            }
        }

        private async Task<(string?, Models.Courses.MyResponse.ResponseDTO)> GetTokenAndResponseAsync
            (
            HttpClient client,
            string url, 
            CancellationToken cancellation
            ) 
        {
            using (var response = await client.GetAsync(url, cancellation)) 
            {
                var body = await response.Content.ReadAsStringAsync(cancellation);
                var result = JsonSerializer.Deserialize<Models.Courses.ApiResponse.EntityResponse>(body);

                if (result == null)
                {
                    return (null, new Models.Courses.MyResponse.ResponseDTO
                    {
                        IsSuccess = false,
                        Message = "Problem with serialization",
                    });
                }

                return (result.Pagination.Token, new Models.Courses.MyResponse.ResponseDTO
                {
                    IsSuccess = true,
                    Message = "Success",
                    Courses = result.Results.Select(x => (CourseDTO)x).ToList(),
                });
            }
        }

        //https://radon.nauka.gov.pl/api/katalog-udostepniania-danych/dane-polon/polon/reports_institution
        public async Task<Models.Institutions.MyResponse.ResponseDTO> GetUniversityDataAsync
            (
            Guid universityId,
            CancellationToken cancellation
            ) 
        {
            var urlPart1 = $"{_url}{_institutionsSegment}?{_resultNumbersQuery}{_maxValue}";
            var institutionQuery = $"{_institutionUuidQuery}{universityId.ToString().ToLower()}";

            var url = $"{urlPart1}&{institutionQuery}";

            using (var client = new HttpClient())
            using (var response = await client.GetAsync(url, cancellation)) 
            {
                var body = await response.Content.ReadAsStringAsync(cancellation);
                var result = JsonSerializer.Deserialize<Models.Institutions.ApiResponse.EntityResponse>(body);
                if (result == null)
                {
                    return new Models.Institutions.MyResponse.ResponseDTO 
                    { 
                        IsSuccess = false,
                        Message = "Problem with serialization",
                    };
                }

                return new Models.Institutions.MyResponse.ResponseDTO 
                { 
                    IsSuccess = true ,
                    Message = "Success",
                    Response = result,
                };
            }
        }
    }
}
