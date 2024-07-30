using Regon.ValueObjectsAndTheirExceptions.NipValue;
using Regon.ValueObjectsAndTheirExceptions.SessionIdValue;
using Regon.ValueObjectsAndTheirExceptions.UserKeyValue;

namespace Regon.Repositories.SoapEnvelopes
{
    public class RegonEnvelopesRepository : IRegonEnvelopesRepository
    {
        public readonly string soapEndpointProduction = "https://wyszukiwarkaregon.stat.gov.pl/wsBIR/UslugaBIRzewnPubl.svc";
        public readonly string soapEndpointTesting = "https://wyszukiwarkaregontest.stat.gov.pl/wsBIR/UslugaBIRzewnPubl.svc";

        public string GetSoapEndpoint(bool isTesting)
        {
            if (isTesting)
            {
                return soapEndpointTesting;
            }
            return soapEndpointProduction;
        }

        public string ZalogujEnvelope(UserKey userKey, bool isTesting = false)
        {
            var soapAction = "http://CIS/BIR/PUBL/2014/07/IUslugaBIRzewnPubl/Zaloguj";
            var soapEndpoint = GetSoapEndpoint(isTesting);

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

        public string WylogujEnvelope(Sid sessionId, bool isTesting = false)
        {
            var soapAction = "http://CIS/BIR/PUBL/2014/07/IUslugaBIRzewnPubl/Wyloguj";
            var soapEndpoint = GetSoapEndpoint(isTesting);

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

        public string DaneSzukajByNipEnvelope(Nip nip, bool isTesting = false)
        {
            var soapAction = "http://CIS/BIR/PUBL/2014/07/IUslugaBIRzewnPubl/DaneSzukaj";
            var soapEndpoint = GetSoapEndpoint(isTesting);

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

        public string DaneSzukajByRegonEnvelope
            (
            ValueObjectsAndTheirExceptions.RegonValue.Regon regon, 
            bool isTesting = false
            )
        {
            var soapAction = "http://CIS/BIR/PUBL/2014/07/IUslugaBIRzewnPubl/DaneSzukaj";
            var soapEndpoint = GetSoapEndpoint(isTesting);

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

        public string DanePobierzPelnyRaportEnvelope
            (
            ValueObjectsAndTheirExceptions.RegonValue.Regon regon, 
            string nazwaRaportu,
            bool isTesting = false
            )
        {
            var soapAction = "http://CIS/BIR/PUBL/2014/07/IUslugaBIRzewnPubl/DanePobierzPelnyRaport";
            var soapEndpoint = GetSoapEndpoint(isTesting);

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
