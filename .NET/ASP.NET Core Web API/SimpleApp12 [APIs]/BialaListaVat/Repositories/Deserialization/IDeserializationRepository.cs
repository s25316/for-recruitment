using BialaListaVat.CustomExceptions;
using BialaListaVat.Models.SingleById.CorrectResponse;
using BialaListaVat.Models.SingleById.UncorrectResponse;

namespace BialaListaVat.Repositories.Deserialization
{
    public interface IDeserializationRepository
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="body"></param>
        /// <returns></returns>
        /// <exception cref="BialaListaVatException"></exception>
        SingleCompany DeserializationSingleCompany(string body);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="body"></param>
        /// <returns></returns>
        /// <exception cref="BialaListaVatException"></exception>
        IncorrectResponse DeserializationIncorrectResponse(string body);
    }
}
