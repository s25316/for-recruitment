using Regon.AggregatesAndEntities.DanePobierzPelnyRaport.CoreResponse.Level5DaneClasses;
using Regon.AggregatesAndEntities.DaneSzukaj.CoreResponse.Level5;
using Regon.CustomExceptions;
using Regon.ValueObjectsAndTheirExceptions.NazwaRaportuValue;
using Regon.ValueObjectsAndTheirExceptions.SessionIdValue;
using Regon.ValueObjectsAndTheirExceptions.UserKeyValue;

namespace Regon.Repositories.EnvelopesDeserialization
{
    public interface IDeserializationRepository
    {
        /// <summary>
        /// Zaloguj sie i pobierz SessionId
        /// </summary>
        /// <param name="envelope">SOAP Envelpe</param>
        /// <returns></returns>
        /// <exception cref="AppException"></exception>
        /// <exception cref="UserKeyException"></exception>
        SesionId DeserializeResponseFromZalogujRequestAndReturnSid(string envelope);

        /// <summary>
        /// Wyloguj sie i pobierz status wylogowania
        /// </summary>
        /// <param name="envelope">SOAP Envelpe</param>
        /// <returns></returns>
        /// <exception cref="AppException"></exception>        
        bool DeserializeResponseFromWylogujRequestAndReturnStatus(string envelope);

        /// <summary>
        /// Pobierz Dane podstawowe Działnosci gospodarczej
        /// </summary>
        /// <param name="envelope">SOAP Envelope</param>
        /// <param name="exception">Any Exeption</param>
        /// <returns></returns>
        /// <exception cref="AppException"></exception>        
        DanePodstawowe DeserializeResponseFromDaneSzukajToDanePodstawowe
            (
            string envelope,
            Exception exception
            );

        /// <summary>
        /// Pobierz Pelny Raport diałanosci gospodarczej, Dane zwracjace nalezą do klass dziedziczacych po DanePelne
        /// </summary>
        /// <param name="envelope">SOAP Envelope</param>
        /// <param name="nazwaRaportu"></param>
        /// <returns></returns>
        /// <exception cref="AppException"></exception>
        DanePelne DeserializeResponseFromDanePobierzPelnyRaport
            (
            string envelope,
            NazwaRaportu nazwaRaportu
            );
    }
}
