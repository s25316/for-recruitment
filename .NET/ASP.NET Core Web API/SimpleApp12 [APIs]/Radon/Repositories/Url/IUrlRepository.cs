namespace Radon.Repositories.Url
{
    public interface IUrlRepository
    {
        string GenerateUrlForGettingCoursesList(Guid universityId);

        string GenerateUrlForGettingCoursesListWithToken(Guid universityId, string? token);
        string GenerateUrlForGettingUniversity(Guid universityId);

        string GenerateUrlForGettingBranchesList(Guid universityId);
        string GenerateUrlForGettingBranchesListWithToken(Guid universityId, string? token);
    }
}
