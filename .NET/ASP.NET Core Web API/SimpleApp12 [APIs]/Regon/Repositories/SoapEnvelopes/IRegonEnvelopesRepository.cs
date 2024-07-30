using Regon.ValueObjectsAndTheirExceptions.NipValue;
using Regon.ValueObjectsAndTheirExceptions.SessionIdValue;
using Regon.ValueObjectsAndTheirExceptions.UserKeyValue;

namespace Regon.Repositories.SoapEnvelopes
{
    public interface IRegonEnvelopesRepository
    {
        string GetSoapEndpoint(bool isTesting);
        string ZalogujEnvelope(UserKey userKey, bool isTesting = false);
        string WylogujEnvelope(Sid sessionId, bool isTesting = false);
        string DaneSzukajByNipEnvelope(Nip nip, bool isTesting = false);
        string DaneSzukajByRegonEnvelope
            (
            ValueObjectsAndTheirExceptions.RegonValue.Regon regon, 
            bool isTesting = false
            );
        public string DanePobierzPelnyRaportEnvelope
            (
            ValueObjectsAndTheirExceptions.RegonValue.Regon regon,
            string nazwaRaportu,
            bool isTesting = false
            );
    }
}
