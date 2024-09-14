using Regon.AggregatesAndEntities.DanePobierzPelnyRaport.CoreResponse.Level5DaneClasses;
using Regon.AggregatesAndEntities.DaneSzukaj.CoreResponse.Level5;
using Regon.CustomExceptions;
using Regon.Factories;
using Regon.Repositories.EnvelopesDeserialization;
using Regon.Repositories.SoapEnvelopes;
using Regon.ValueObjectsAndTheirExceptions.CustomDateOnlyXmlElement;
using Regon.ValueObjectsAndTheirExceptions.NazwaRaportuValue;
using Regon.ValueObjectsAndTheirExceptions.NipValue;
using Regon.ValueObjectsAndTheirExceptions.RegonValue;
using Regon.ValueObjectsAndTheirExceptions.SessionIdValue;
using Regon.ValueObjectsAndTheirExceptions.UserKeyValue;
using System.Reflection;
using System.Text;

namespace Regon.Repositories.Requests
{
    public class RequestsRepository : IRequestsRepository
    {
        private readonly IEnvelopesRepository _envelopes;
        private readonly IDeserializationRepository _deserializer;

        public RequestsRepository
            (
            IEnvelopesRepository envelopes,
            IDeserializationRepository deserializationRepository
            )
        {
            _envelopes = envelopes;
            _deserializer = deserializationRepository;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="userKey"></param>
        /// <param name="cancellation"></param>
        /// <param name="askProductionEndpoint"></param>
        /// <returns></returns>
        /// <exception cref="AppException"></exception>
        /// <exception cref="UserKeyException"></exception>
        public async Task<SesionId> ZalogujRequestAndReturnSidAsync
           (
           UserKey userKey,
           CancellationToken cancellation,
           bool askProductionEndpoint = true
           )
        {
            var soapEndpoint = _envelopes.GetSoapEndpoint(askProductionEndpoint);
            var soapRequest = _envelopes.ZalogujEnvelope(userKey, askProductionEndpoint);

            var xml = await MakeRequestAsync(null, soapEndpoint, soapRequest, cancellation);
            return _deserializer.DeserializeResponseFromZalogujRequestAndReturnSid(xml);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sid"></param>
        /// <param name="cancellation"></param>
        /// <param name="askProductionEndpoint"></param>
        /// <returns></returns>    
        /// <exception cref="AppException"></exception> 
        public async Task<bool> WylogujRequestAsync
          (
          SesionId sid,
          CancellationToken cancellation,
          bool askProductionEndpoint = true
          )
        {
            var soapEndpoint = _envelopes.GetSoapEndpoint(askProductionEndpoint);
            var soapRequest = _envelopes.WylogujEnvelope(sid, askProductionEndpoint);

            var xml = await MakeRequestAsync(sid, soapEndpoint, soapRequest, cancellation);

            return _deserializer.DeserializeResponseFromWylogujRequestAndReturnStatus(xml);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="nip"></param>
        /// <param name="sid"></param>
        /// <param name="cancellation"></param>
        /// <param name="askProductionEndpoint"></param>
        /// <returns></returns>  
        /// <exception cref="AppException"></exception> 
        /// <exception cref="NipException"></exception> 
        public async Task<DanePodstawowe> DaneSzukajByNipRequestAsync
            (
            Nip nip,
            SesionId sid,
            CancellationToken cancellation,
            bool askProductionEndpoint = true
            )
        {
            var soapEndpoint = _envelopes.GetSoapEndpoint(askProductionEndpoint);
            var soapRequest = _envelopes.DaneSzukajByNipEnvelope(nip, askProductionEndpoint);

            var xml = await MakeRequestAsync(sid, soapEndpoint, soapRequest, cancellation);

            return _deserializer.DeserializeResponseFromDaneSzukajToDanePodstawowe
                (
                xml,
                new NipException(MessagesFactory.GenerateExeptionMessageNipCompanyNotExist(nip))
                );
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="regon"></param>
        /// <param name="sid"></param>
        /// <param name="cancellation"></param>
        /// <param name="askProductionEndpoint"></param>
        /// <returns></returns>
        /// <exception cref="AppException"></exception> 
        /// <exception cref="RegonException"></exception> 
        public async Task<DanePodstawowe> DaneSzukajByRegonRequestAsync
            (
            ValueObjectsAndTheirExceptions.RegonValue.Regon regon,
            SesionId sid,
            CancellationToken cancellation,
            bool askProductionEndpoint = true
            )
        {
            var soapEndpoint = _envelopes.GetSoapEndpoint(askProductionEndpoint);
            var soapRequest = _envelopes.DaneSzukajByRegonEnvelope(regon, askProductionEndpoint);

            var xml = await MakeRequestAsync(sid, soapEndpoint, soapRequest, cancellation);

            return _deserializer.DeserializeResponseFromDaneSzukajToDanePodstawowe
                (
                xml,
                new RegonException(MessagesFactory.GenerateExeptionMessageRegonCompanyNotExist(regon))
                );
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="dane"></param>
        /// <param name="sid"></param>
        /// <param name="cancellation"></param>
        /// <param name="askProductionEndpoint"></param>
        /// <returns></returns>
        /// <exception cref="AppException"></exception> 
        /// <exception cref="CustomDateOnlyException"></exception> 
        public async Task<DanePelne> DanePobierzPelnyRaportRequestAsync
            (
            DanePodstawowe dane,
            SesionId sid,
            CancellationToken cancellation,
            bool askProductionEndpoint = true
            )
        {
            var nazwaRaportu = new NazwaRaportu(dane.Typ, dane.SilosID);

            var soapEndpoint = _envelopes.GetSoapEndpoint(askProductionEndpoint);
            var soapRequest = _envelopes.DanePobierzPelnyRaportEnvelope
                (
                dane.Regon,
                nazwaRaportu.Name.ToString(),
                askProductionEndpoint
                );

            var xml = await MakeRequestAsync(sid, soapEndpoint, soapRequest, cancellation);

            return _deserializer.DeserializeResponseFromDanePobierzPelnyRaport(xml, nazwaRaportu);
        }


        //==============================================================================================================
        //==============================================================================================================
        //Private Methods
        //==============================================================================================================
        private async Task<string> MakeRequestAsync
            (
            SesionId? sid,
            string soapEndpoint,
            string soapRequest,
            CancellationToken cancellation
            )
        {
            using (var client = new HttpClient())
            {
                HttpRequestMessage request = new HttpRequestMessage()
                {
                    Method = HttpMethod.Post,
                    RequestUri = new Uri(soapEndpoint),
                    Content = new StringContent(soapRequest, Encoding.UTF8, "application/soap+xml")
                };

                if (sid != null)
                {
                    request.Headers.Add("sid", sid.Id);
                }

                var response = await client.SendAsync(request, cancellation);
                string body = await response.Content.ReadAsStringAsync(cancellation);

                request.Dispose();
                response.Dispose();

                return ExtractSoapEnvelopeFromBody(body);
            }
        }

        private string ExtractSoapEnvelopeFromBody(string body)
        {
            /* Body Response looks like for Zaloguj
            [
                  "0 ",
                  "1 --uuid:d7df59b9-21aa-45e0-97c3-54d9a4e79d76+id=42489",
                  "2 Content-ID: <http://tempuri.org/0>",
                  "3 Content-Transfer-Encoding: 8bit",
                  "4 Content-Type: application/xop+xml;charset=utf-8;type=\"application/soap+xml\"",
                  "5 ",
                  "6 <s:Envelope xmlns:s=\"http://www.w3.org/2003/05/soap-envelope\" xmlns:a=\"http://www.w3.org/2005/08/addressing\"><s:Header><a:Action s:mustUnderstand=\"1\">http://CIS/BIR/PUBL/2014/07/IUslugaBIRzewnPubl/ZalogujResponse</a:Action></s:Header><s:Body><ZalogujResponse xmlns=\"http://CIS/BIR/PUBL/2014/07\"><ZalogujResult>37sh7z5e54nc7f4f8fvx</ZalogujResult></ZalogujResponse></s:Body></s:Envelope>",
                  "7 --uuid:d7df59b9-21aa-45e0-97c3-54d9a4e79d76+id=42489--",
                  "8 "
            ]   
             */
            /* Body Response looks like for DaneSzukajByNip
             [
              "0 ",
              "1 --uuid:1afb972f-320c-4279-80f5-480b11f0dff7+id=42262",
              "2 Content-ID: <http://tempuri.org/0>",
              "3 Content-Transfer-Encoding: 8bit",
              "4 Content-Type: application/xop+xml;charset=utf-8;type=\"application/soap+xml\"",
              "5 ",
              "6 <s:Envelope xmlns:s=\"http://www.w3.org/2003/05/soap-envelope\" xmlns:a=\"http://www.w3.org/2005/08/addressing\"><s:Header><a:Action s:mustUnderstand=\"1\">http://CIS/BIR/PUBL/2014/07/IUslugaBIRzewnPubl/DaneSzukajResponse</a:Action></s:Header><s:Body><DaneSzukajResponse xmlns=\"http://CIS/BIR/PUBL/2014/07\"><DaneSzukajResult>&lt;Root&gt;&#xD;",
              "7 &lt;Dane&gt;&#xD;",
              "8 &lt;Regon&gt;01081624800000&lt;/Regon&gt;&#xD;",
              "9 &lt;RegonLink&gt;&amp;lt;a href='javascript:danePobierzPelnyRaport(\"01081624800000\",\"DaneRaportPrawnaPubl\", 0);'&amp;gt;010816248&amp;lt;/a&amp;gt;&lt;/RegonLink&gt;&#xD;",
              "10 &lt;Nazwa&gt;POLSKO-JAPOŃSKA AKADEMIA TECHNIK KOMPUTEROWYCH&lt;/Nazwa&gt;&#xD;",
              "11 &lt;Wojewodztwo&gt;MAZOWIECKIE&lt;/Wojewodztwo&gt;&#xD;",
              "12 &lt;Powiat&gt;m. st. Warszawa&lt;/Powiat&gt;&#xD;",
              "13 &lt;Gmina&gt;Śródmieście&lt;/Gmina&gt;&#xD;",
              "14 &lt;Miejscowosc&gt;Warszawa&lt;/Miejscowosc&gt;&#xD;",
              "15 &lt;KodPocztowy&gt;02-008&lt;/KodPocztowy&gt;&#xD;",
              "16 &lt;Ulica&gt;ul. Test-Krucza&lt;/Ulica&gt;&#xD;",
              "17 &lt;Typ&gt;P&lt;/Typ&gt;&#xD;",
              "18 &lt;SilosID&gt;6&lt;/SilosID&gt;&#xD;",
              "19 &lt;/Dane&gt;&#xD;",
              "20 &lt;/Root&gt;</DaneSzukajResult></DaneSzukajResponse></s:Body></s:Envelope>",
              "21 --uuid:1afb972f-320c-4279-80f5-480b11f0dff7+id=42262--",
              "22 "
            ]             
             */
            var list = body.Split("\n").ToList();
            if (list.Count() < 9)
            {
                throw new AppException(MessagesFactory.GenerateExeptionMessageStructureOfResponseHasChanged
                    (
                    this.GetType(),
                    MethodBase.GetCurrentMethod(),
                    body
                    ));
            }

            for (int i = 0; i < 6; i++)
            {
                list.RemoveAt(0);
            }
            for (int i = 0; i < 2; i++)
            {
                list.RemoveAt(list.Count() - 1);
            }
            var envelope = string.Join("", list.Select(x => x.Trim()).ToList());
            return envelope;
        }
    }
}
