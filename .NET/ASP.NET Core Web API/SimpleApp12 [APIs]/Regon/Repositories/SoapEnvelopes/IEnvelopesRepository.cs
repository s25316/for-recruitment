using Regon.ValueObjectsAndTheirExceptions.NipValue;
using Regon.ValueObjectsAndTheirExceptions.SessionIdValue;
using Regon.ValueObjectsAndTheirExceptions.UserKeyValue;

namespace Regon.Repositories.SoapEnvelopes
{
    public interface IEnvelopesRepository
    {
        /// <summary>
        /// Pobierz URL
        /// </summary>
        /// <param name="askProductionEndpoint"></param>
        /// <returns></returns>
        string GetSoapEndpoint(bool askProductionEndpoint = true);

        /// <summary>
        /// Pobierz Zaloguj Envelope
        /// </summary>
        /// <param name="userKey"></param>
        /// <param name="askProductionEndpoint"></param>
        /// <returns></returns>
        string ZalogujEnvelope(UserKey userKey, bool askProductionEndpoint = true);

        /// <summary>
        /// Pobierz Wyloguj Envelope
        /// </summary>
        /// <param name="sessionId"></param>
        /// <param name="askProductionEndpoint"></param>
        /// <returns></returns>
        string WylogujEnvelope(SesionId sessionId, bool askProductionEndpoint = true);

        /// <summary>
        /// Pobierz DaneSzukaj Envelope z parametrem NIP
        /// </summary>
        /// <param name="nip"></param>
        /// <param name="askProductionEndpoint"></param>
        /// <returns></returns>
        string DaneSzukajByNipEnvelope(Nip nip, bool askProductionEndpoint = true);

        /// <summary>
        /// Pobierz DaneSzukaj Envelope z parametrem REGON 
        /// </summary>
        /// <param name="regon"></param>
        /// <param name="askProductionEndpoint"></param>
        /// <returns></returns>
        string DaneSzukajByRegonEnvelope
            (
            ValueObjectsAndTheirExceptions.RegonValue.Regon regon,
            bool askProductionEndpoint = true
            );

        /// <summary>
        /// Pobierz DanePobierzPelnyRaport Envelope
        /// </summary>
        /// <param name="regon"></param>
        /// <param name="nazwaRaportu"></param>
        /// <param name="askProductionEndpoint"></param>
        /// <returns></returns>
        public string DanePobierzPelnyRaportEnvelope
            (
            ValueObjectsAndTheirExceptions.RegonValue.Regon regon,
            string nazwaRaportu,
            bool askProductionEndpoint = true
            );
    }
}
