using Radon.AggregatesAndEntities.Shared.Responses;

namespace Radon.Repositories
{
    public interface IUniversitiesRepository
    {
        Task<ResponseList<AggregatesAndEntities.Courses.CoreResponse.Level1.Course>> GetCoursesSourceDataAsync
              (
              Guid universityId,
              CancellationToken cancellation
              );
        Task<ResponseList<AggregatesAndEntities.Courses.CustomResponse.Course>> GetCoursesCustomDataAsync
              (
              Guid universityId,
              CancellationToken cancellation
              );


        Task<Response<AggregatesAndEntities.Institutions.CoreResponse.Level1.University>> GetUniversitySourceDataAsync
             (
             Guid universityId,
             CancellationToken cancellation
             );
        Task<Response<AggregatesAndEntities.Institutions.CustomResponse.Aggregates.University>> GetUniversityCustomDataAsync
           (
           Guid universityId,
           CancellationToken cancellation
           );


        Task<ResponseList<AggregatesAndEntities.Branches.CoreResponse.Level1.Branch>> GetBranchesSourceDataAsync
            (
           Guid universityId,
           CancellationToken cancellation
           );
        Task<ResponseList<AggregatesAndEntities.Branches.CustomResponse.Aggregates.Branch>> GetBranchesCustomDataAsync
           (
           Guid universityId,
           CancellationToken cancellation
           );
    }
}
