using BialaListaVat.CustomExceptions;
using BialaListaVat.Models.SingleById.CorrectResponse;
using BialaListaVat.Models.SingleById.UncorrectResponse;
using System.Text.Json;

namespace BialaListaVat.Repositories.Deserialization
{
    public class DeserializationRepository : IDeserializationRepository
    {

        /// <summary>
        /// 
        /// </summary>
        /// <param name="body"></param>
        /// <returns></returns>
        /// <exception cref="BialaListaVatException"></exception>
        public SingleCompany DeserializationSingleCompany(string body)
        {
            var result = JsonSerializer.Deserialize<EntityResponse>(body);
            if (
                result == null ||
                result.Result == null ||
                result.Result.Subject == null
                )
            {
                throw new BialaListaVatException(CreateMessageForExeption<EntityResponse>(body));
            }
            return result.Result.Subject;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="body"></param>
        /// <returns></returns>
        /// <exception cref="BialaListaVatException"></exception>
        public IncorrectResponse DeserializationIncorrectResponse(string body)
        {
            var result = JsonSerializer.Deserialize<IncorrectResponse>(body);
            if (result == null)
            {
                throw new BialaListaVatException(CreateMessageForExeption<IncorrectResponse>(body));
            }
            return result;
        }
        //===========================================================================================================================================
        //===========================================================================================================================================
        //Private Methods
        //===========================================================================================================================================
        private string GetClassFullName<T>() where T : class
        {
            var type = typeof(T).FullName;
            return string.IsNullOrEmpty(type) ? "Unknown Type" : type.Replace("+", ".");
        }

        private string CreateMessageForExeption<T>(string body) where T : class
        {
            return $"{Messages.DeserializationProblem}; Class: {GetClassFullName<T>()}; {body};";

        }
    }
}
