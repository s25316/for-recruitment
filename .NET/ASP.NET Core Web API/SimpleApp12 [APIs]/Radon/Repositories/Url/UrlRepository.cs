namespace Radon.Repositories.Url
{
    public class UrlRepository : IUrlRepository
    {
        private readonly string _url = "https://radon.nauka.gov.pl/opendata/";
        private readonly string _coursesSegment = "polon/courses";
        private readonly string _institutionsSegment = "polon/institutions";
        private readonly string _branchesSegment = "polon/branches";

        private readonly string _resultNumbersQuery = "resultNumbers=";
        private readonly string _tokenQuery = "token=";

        private readonly string _mainInstitutionUuidQuery = "mainInstitutionUuid=";
        private readonly string _leadingInstitutionUuidQuery = "leadingInstitutionUuid=";
        private readonly string _institutionUuidQuery = "institutionUuid=";
        private readonly int _maxValue = 100;

        //https://radon.nauka.gov.pl/api/katalog-udostepniania-danych/dane-polon/polon/reports_course
        public string GenerateUrlForGettingCoursesList(Guid universityId)
        {
            var urlPart1 = $"{_url}{_coursesSegment}?{_resultNumbersQuery}{_maxValue}";
            var institutionQuery = $"{_leadingInstitutionUuidQuery}{universityId.ToString().ToLower()}";
            return $"{urlPart1}&{institutionQuery}";
        }

        public string GenerateUrlForGettingCoursesListWithToken(Guid universityId, string? token)
        {
            var urlPart1 = $"{_url}{_coursesSegment}?{_resultNumbersQuery}{_maxValue}";
            var institutionQuery = $"{_leadingInstitutionUuidQuery}{universityId.ToString().ToLower()}";
            return $"{urlPart1}&{_tokenQuery}{token}&{institutionQuery}";
        }


        //https://radon.nauka.gov.pl/api/katalog-udostepniania-danych/dane-polon/polon/reports_institution
        public string GenerateUrlForGettingUniversity(Guid universityId)
        {
            var urlPart1 = $"{_url}{_institutionsSegment}?{_resultNumbersQuery}{_maxValue}";
            var institutionQuery = $"{_institutionUuidQuery}{universityId.ToString().ToLower()}";
            return $"{urlPart1}&{institutionQuery}";
        }

        //https://radon.nauka.gov.pl/api/katalog-udostepniania-danych/dane-polon/polon/reports_branch
        public string GenerateUrlForGettingBranchesList(Guid universityId)
        {
            var urlPart1 = $"{_url}{_branchesSegment}?{_resultNumbersQuery}{_maxValue}";
            var institutionQuery = $"{_mainInstitutionUuidQuery}{universityId.ToString().ToLower()}";
            return $"{urlPart1}&{institutionQuery}";
        }

        public string GenerateUrlForGettingBranchesListWithToken(Guid universityId, string? token)
        {
            var urlPart1 = $"{_url}{_branchesSegment}?{_resultNumbersQuery}{_maxValue}";
            var institutionQuery = $"{_mainInstitutionUuidQuery}{universityId.ToString().ToLower()}";
            return $"{urlPart1}&{_tokenQuery}{token}&{institutionQuery}";
        }
    }
}
