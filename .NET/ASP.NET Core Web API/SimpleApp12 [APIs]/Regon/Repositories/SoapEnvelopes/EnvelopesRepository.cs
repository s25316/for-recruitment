using Regon.ValueObjectsAndTheirExceptions.NipValue;
using Regon.ValueObjectsAndTheirExceptions.SessionIdValue;
using Regon.ValueObjectsAndTheirExceptions.UserKeyValue;

namespace Regon.Repositories.SoapEnvelopes
{
    /// <summary>
    /// Klasa zwracjąca SOAP Envelopes dla zapytań API 
    /// </summary>
    public class EnvelopesRepository : IEnvelopesRepository
    {
        public readonly string soapProductionEndpoint = "https://wyszukiwarkaregon.stat.gov.pl/wsBIR/UslugaBIRzewnPubl.svc";
        public readonly string soapTestingEndpoint = "https://wyszukiwarkaregontest.stat.gov.pl/wsBIR/UslugaBIRzewnPubl.svc";

        /// <summary>
        /// Pobierz URL
        /// </summary>
        /// <param name="askProductionEndpoint"></param>
        /// <returns></returns>
        public string GetSoapEndpoint(bool askProductionEndpoint = true)
        {
            if (askProductionEndpoint)
            {
                return soapProductionEndpoint;
            }
            return soapTestingEndpoint;

        }

        /// <summary>
        /// Pobierz Zaloguj Envelope
        /// </summary>
        /// <param name="userKey"></param>
        /// <param name="askProductionEndpoint"></param>
        /// <returns></returns>
        public string ZalogujEnvelope(UserKey userKey, bool askProductionEndpoint = true)
        {
            var soapAction = "http://CIS/BIR/PUBL/2014/07/IUslugaBIRzewnPubl/Zaloguj";
            var soapEndpoint = GetSoapEndpoint(askProductionEndpoint);

            return $@"<soap:Envelope xmlns:soap=""http://www.w3.org/2003/05/soap-envelope"" xmlns:ns=""http://CIS/BIR/PUBL/2014/07"">
                                    <soap:Header xmlns:wsa=""http://www.w3.org/2005/08/addressing"">
                                        <wsa:Action>{soapAction}</wsa:Action>
                                        <wsa:To>{soapEndpoint}</wsa:To>
                                    </soap:Header>
                                    <soap:Body>
                                        <ns:Zaloguj>
                                            <ns:pKluczUzytkownika>{userKey.Key}</ns:pKluczUzytkownika>
                                        </ns:Zaloguj>
                                    </soap:Body>
                                    </soap:Envelope>";
        }

        /// <summary>
        /// Pobierz Wyloguj Envelope
        /// </summary>
        /// <param name="sessionId"></param>
        /// <param name="askProductionEndpoint"></param>
        /// <returns></returns>
        public string WylogujEnvelope(SesionId sessionId, bool askProductionEndpoint = true)
        {
            var soapAction = "http://CIS/BIR/PUBL/2014/07/IUslugaBIRzewnPubl/Wyloguj";
            var soapEndpoint = GetSoapEndpoint(askProductionEndpoint);

            return $@"<soap:Envelope xmlns:soap=""http://www.w3.org/2003/05/soap-envelope"" xmlns:ns=""http://CIS/BIR/PUBL/2014/07"">
                                    <soap:Header xmlns:wsa=""http://www.w3.org/2005/08/addressing"">
                                        <wsa:To>{soapEndpoint}</wsa:To>
                                        <wsa:Action>{soapAction}</wsa:Action>
                                    </soap:Header>
                                    <soap:Body>
                                        <ns:Wyloguj>
                                            <ns:pIdentyfikatorSesji>{sessionId.Id}</ns:pIdentyfikatorSesji>
                                        </ns:Wyloguj>
                                    </soap:Body>
                                    </soap:Envelope>";
        }

        /// <summary>
        /// Pobierz DaneSzukaj Envelope z parametrem NIP
        /// </summary>
        /// <param name="nip"></param>
        /// <param name="askProductionEndpoint"></param>
        /// <returns></returns>
        public string DaneSzukajByNipEnvelope(Nip nip, bool askProductionEndpoint = true)
        {
            var soapAction = "http://CIS/BIR/PUBL/2014/07/IUslugaBIRzewnPubl/DaneSzukaj";
            var soapEndpoint = GetSoapEndpoint(askProductionEndpoint);

            return $@"<soap:Envelope xmlns:soap=""http://www.w3.org/2003/05/soap-envelope"" xmlns:ns=""http://CIS/BIR/PUBL/2014/07"" xmlns:dat=""http://CIS/BIR/PUBL/2014/07/DataContract"">
                                    <soap:Header xmlns:wsa=""http://www.w3.org/2005/08/addressing"">
                                        <wsa:To>{soapEndpoint}</wsa:To>
                                        <wsa:Action>{soapAction}</wsa:Action>
                                    </soap:Header>
                                    <soap:Body>
                                        <ns:DaneSzukaj>
                                            <ns:pParametryWyszukiwania>
                                                <dat:Nip>{nip.Number}</dat:Nip>
                                            </ns:pParametryWyszukiwania>
                                        </ns:DaneSzukaj>
                                    </soap:Body>
                                    </soap:Envelope>";
        }

        /// <summary>
        /// Pobierz DaneSzukaj Envelope z parametrem REGON 
        /// </summary>
        /// <param name="regon"></param>
        /// <param name="askProductionEndpoint"></param>
        /// <returns></returns>
        public string DaneSzukajByRegonEnvelope
            (
            ValueObjectsAndTheirExceptions.RegonValue.Regon regon,
            bool askProductionEndpoint = true
            )
        {
            var soapAction = "http://CIS/BIR/PUBL/2014/07/IUslugaBIRzewnPubl/DaneSzukaj";
            var soapEndpoint = GetSoapEndpoint(askProductionEndpoint);

            return $@"<soap:Envelope xmlns:soap=""http://www.w3.org/2003/05/soap-envelope"" xmlns:ns=""http://CIS/BIR/PUBL/2014/07"" xmlns:dat=""http://CIS/BIR/PUBL/2014/07/DataContract"">
                                    <soap:Header xmlns:wsa=""http://www.w3.org/2005/08/addressing"">
                                        <wsa:To>{soapEndpoint}</wsa:To>
                                        <wsa:Action>{soapAction}</wsa:Action>
                                    </soap:Header>
                                    <soap:Body>
                                        <ns:DaneSzukaj>
                                            <ns:pParametryWyszukiwania>
                                                <dat:Regon>{regon.Number}</dat:Regon>
                                            </ns:pParametryWyszukiwania>
                                        </ns:DaneSzukaj>
                                    </soap:Body>
                                    </soap:Envelope>";
        }

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
            )
        {
            var soapAction = "http://CIS/BIR/PUBL/2014/07/IUslugaBIRzewnPubl/DanePobierzPelnyRaport";
            var soapEndpoint = GetSoapEndpoint(askProductionEndpoint);

            return $@"<soap:Envelope xmlns:soap='http://www.w3.org/2003/05/soap-envelope' xmlns:ns='http://CIS/BIR/PUBL/2014/07'>
                                        <soap:Header xmlns:wsa='http://www.w3.org/2005/08/addressing'>
                                            <wsa:To>{soapEndpoint}</wsa:To>
                                            <wsa:Action>{soapAction}</wsa:Action>
                                        </soap:Header>
                                        <soap:Body>
                                            <ns:DanePobierzPelnyRaport>
                                                <ns:pRegon>{regon.Number}</ns:pRegon>
                                                <ns:pNazwaRaportu>{nazwaRaportu}</ns:pNazwaRaportu>
                                            </ns:DanePobierzPelnyRaport>
                                        </soap:Body>
                                    </soap:Envelope>";
        }
    }
}
