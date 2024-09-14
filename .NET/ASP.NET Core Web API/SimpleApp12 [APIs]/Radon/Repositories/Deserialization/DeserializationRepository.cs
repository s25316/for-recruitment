using Radon.AggregatesAndEntities.Branches.CoreResponse.Level1;
using Radon.AggregatesAndEntities.Courses.CoreResponse.Level1;
using Radon.AggregatesAndEntities.Institutions.CoreResponse.Level1;
using Radon.CustomExceptions;
using System.Reflection;
using System.Text.Json;

namespace Radon.Repositories.Deserialization
{
    public class DeserializationRepository : IDeserializationRepository
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="body"></param>
        /// <returns></returns>
        /// <exception cref="AppException">Exeption For Admin/Proggramer</exception>
        /// <exception cref="UserException">Exeption For User</exception>
        public University DeserializationUniversityData(string body)
        {
            var result = JsonSerializer.Deserialize<Radon.AggregatesAndEntities.Institutions.CoreResponse.EntityResponse>(body);
            if (result == null)
            {
                throw new AppException(
                    GenerateDeserializationMessageException(
                        this.GetType(),
                        MethodBase.GetCurrentMethod(),
                        body)
                    );
            }
            else if (!result.Results.Any())
            {
                throw new UserException(Messages.ExceptionMessageIncorrectIdUniversity);
            }
            return result.Results.First();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="body"></param>
        /// <returns></returns>
        /// <exception cref="AppException">Exeption For Admin/Proggramer</exception>
        public (IEnumerable<Course>, string?) DeserializationCoursesListAndToken(string body)
        {
            var result = JsonSerializer.Deserialize<AggregatesAndEntities.Courses.CoreResponse.EntityResponse>(body);

            if (
                result == null ||
                result.Pagination == null
                )
            {
                throw new AppException(
                     GenerateDeserializationMessageException(
                        this.GetType(),
                        MethodBase.GetCurrentMethod(),
                        body)
                    );
            }
            return (result.Results, result.Pagination.Token);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="body"></param>
        /// <returns></returns>
        /// <exception cref="AppException">Exeption For Admin/Proggramer</exception>
        public (IEnumerable<Branch>, string?) DeserializationBranchesListAndToken(string body)
        {
            var result = JsonSerializer.Deserialize<AggregatesAndEntities.Branches.CoreResponse.EntityResponse>(body);

            if (
                result == null ||
                result.Pagination == null
                )
            {
                throw new AppException(
                    GenerateDeserializationMessageException(
                        this.GetType(),
                        MethodBase.GetCurrentMethod(),
                        body)
                    );
            }
            return (result.Branches, result.Pagination.Token);
        }

        //========================================================================================================================================
        //========================================================================================================================================
        private string GenerateDeserializationMessageException(Type classType, MethodBase? method, string data)
        {
            return string.Format(
                "{0}: {1}; {2}: {3}; {4}: {5}; {6}: {7}",
                "Description",
                Messages.ExceptionMessageDeserializationProblem,
                "ClassForChange",
                classType.FullName,
                "MethodForChange",
                (method == null ? "None" : method.Name),
                "InputData",
                data
                );
        }
    }
}
