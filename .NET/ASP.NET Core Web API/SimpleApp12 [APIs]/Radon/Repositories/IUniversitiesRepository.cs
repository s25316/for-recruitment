using Radon.Models.Courses;
using Radon.Models.Institutions;
using Radon.Models.Institutions.MyResponse;

namespace Radon.Repositories
{
    public interface IUniversitiesRepository
    {
       Task<Models.Courses.MyResponse.ResponseDTO> GetCoursesListAsync
             (
             Guid universityId,
             CancellationToken cancellation
             );
       Task<ResponseDTO> GetUniversityDataAsync
            (
            Guid universityId,
            CancellationToken cancellation
            );
    }
}
