using Radon.AggregatesAndEntities.Branches.CoreResponse.Level1;
using Radon.AggregatesAndEntities.Courses.CoreResponse.Level1;
using Radon.AggregatesAndEntities.Institutions.CoreResponse.Level1;

namespace Radon.Repositories.Deserialization
{
    public interface IDeserializationRepository
    {
        University DeserializationUniversityData(string body);
        (IEnumerable<Course>, string?) DeserializationCoursesListAndToken(string body);
        (IEnumerable<Branch>, string?) DeserializationBranchesListAndToken(string body);
    }
}
