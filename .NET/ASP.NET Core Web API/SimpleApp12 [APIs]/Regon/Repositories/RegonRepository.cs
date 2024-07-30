using Regon.Repositories.SoapEnvelopes;
using Regon.ValueObjectsAndTheirExceptions.UserKeyValue;
using System.Text;
using System.Xml.Serialization;
using Regon.CustomExceptions;
using Regon.ValueObjectsAndTheirExceptions.NipValue;
using Regon.ValueObjectsAndTheirExceptions.SessionIdValue;
using Regon.Models.ResponseDaneSzukaj.Level4;

namespace Regon.Repositories
{
    public class RegonRepository : IRegonRepository
    {
        private readonly IRegonEnvelopesRepository _envelopes;

        public RegonRepository ( IRegonEnvelopesRepository envelopes ) 
        { 
            _envelopes = envelopes;
        }

        public async Task<Regon.Models.ResponseDaneSzukaj.Envelope> GetCompanyBYNIP
            (
            string nip, 
            string userKey,
            bool askTestApi,
            CancellationToken cancellation
            )
        {
            var nipValue = new Nip(nip);

            using (HttpClient client = new HttpClient())
            {
                var sid = await ZalogujRequestAndReturnSidAsync(userKey, askTestApi, client, cancellation);
                var body = await DaneSzukajByNipRequestAsync(nipValue, sid, askTestApi, client, cancellation);
                await WylogujRequestAsync(sid, askTestApi, client,cancellation);
                return body;
            }
        }

       
        private async Task<Sid> ZalogujRequestAndReturnSidAsync
            (
            string userKey,
            bool askTestApi,
            HttpClient client,
            CancellationToken cancellation
            ) 
        {
            var soapEndpoint = _envelopes.GetSoapEndpoint(askTestApi);
            var soapRequest = _envelopes.ZalogujEnvelope(new UserKey(userKey), askTestApi);

            HttpRequestMessage request = new HttpRequestMessage()
            {
                Method = HttpMethod.Post,
                RequestUri = new Uri(soapEndpoint),
                Content = new StringContent(soapRequest, Encoding.UTF8, "application/soap+xml")
            };

            var response = await client.SendAsync(request, cancellation);
            var body = await response.Content.ReadAsStringAsync(cancellation);
            var xml = GetSoapEnvelopeFromBody(body);
            
            request.Dispose();  
            response.Dispose();

            var envelope = XmlSerializerToClass<Regon.Models.ResponseZaloguj.Envelope>(xml, typeof(Regon.Models.ResponseZaloguj.Envelope));

            if (string.IsNullOrEmpty(envelope.Body.ZalogujResponse.ZalogujResult))
            {
                throw new UserKeyException($"Check your User Key probability is invalid");
            }
            return new Sid(envelope.Body.ZalogujResponse.ZalogujResult);
        }
        
        private async Task<bool> WylogujRequestAsync
           (
           Sid sid,
           bool askTestApi,
           HttpClient client,
           CancellationToken cancellation
           )
        {
            var soapEndpoint = _envelopes.GetSoapEndpoint(askTestApi);
            var soapRequest = _envelopes.WylogujEnvelope(sid, askTestApi);

            var xml = await MakeRequestAsync(sid, soapEndpoint, soapRequest, client, cancellation);

            var envelope = XmlSerializerToClass<Regon.Models.ResponseWyloguj.Envelope>
                (
                xml,
                typeof(Regon.Models.ResponseWyloguj.Envelope)
                );

            return envelope.Body.WylogujResponse.WylogujResult;
        }

        private async Task<Regon.Models.ResponseDaneSzukaj.Envelope> DaneSzukajByNipRequestAsync
            (
            Nip nip,
            Sid sid,
            bool askTestApi,
            HttpClient client,
            CancellationToken cancellation
            ) 
        {
            var soapEndpoint = _envelopes.GetSoapEndpoint(askTestApi);
            var soapRequest = _envelopes.DaneSzukajByNipEnvelope(nip, askTestApi);

            var xml = await MakeRequestAsync(sid, soapEndpoint, soapRequest, client, cancellation);

            xml = xml.Replace("&lt;", "<")
                    .Replace("&gt;", ">")
                    .Replace("&#xD;", "")//"\r"
                    .Replace("&amp;", "&");
            //>&lt;a href='javascript:danePobierzPelnyRaport("01077887800000","DaneRaportPrawnaPubl", 0);'&gt;010778878&lt;/a&gt;

            Console.WriteLine(xml);
            Console.WriteLine();

            var envelope = XmlSerializerToClass<Regon.Models.ResponseDaneSzukaj.Envelope>
                (
                xml,
                typeof(Regon.Models.ResponseDaneSzukaj.Envelope)
                );
            //Console.WriteLine( envelope.Body.DaneSzukajResponse.DaneSzukajResult.ToString() + envelope.Body.DaneSzukajResponse.DaneSzukajResult.Length.ToString());
            return envelope;
            
        }


        

        //=============================
        private async Task<string> MakeRequestAsync
         (
         Sid sid,
         string soapEndpoint,
         string soapRequest,
         HttpClient client,
         CancellationToken cancellation
         )
        {
            HttpRequestMessage request = new HttpRequestMessage()
            {
                Method = HttpMethod.Post,
                RequestUri = new Uri(soapEndpoint),
                Content = new StringContent(soapRequest, Encoding.UTF8, "application/soap+xml")
            };

            request.Headers.Add("sid", sid.Id);

            var response = await client.SendAsync(request, cancellation);
            string body = await response.Content.ReadAsStringAsync(cancellation);

            request.Dispose();
            response.Dispose();

            return GetSoapEnvelopeFromBody(body);
        }

        private string GetSoapEnvelopeFromBody (string body) 
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
              "6 <s:Envelope xmlns:s=\"http://www.w3.org/2003/05/soap-envelope\" xmlns:a=\"http://www.w3.org/2005/08/addressing\"><s:Header><a:Action s:mustUnderstand=\"1\">http://CIS/BIR/PUBL/2014/07/IUslugaBIRzewnPubl/DaneSzukajResponse</a:Action></s:Header><s:Body><DaneSzukajResponse xmlns=\"http://CIS/BIR/PUBL/2014/07\"><DaneSzukajResult>&lt;root&gt;&#xD;",
              "7 &lt;dane&gt;&#xD;",
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
              "19 &lt;/dane&gt;&#xD;",
              "20 &lt;/root&gt;</DaneSzukajResult></DaneSzukajResponse></s:Body></s:Envelope>",
              "21 --uuid:1afb972f-320c-4279-80f5-480b11f0dff7+id=42262--",
              "22 "
            ]             
             */
            var list = body.Split("\n").ToList();
            if (list.Count() < 9)
            {
                throw new RegonAppException("Convention of response has changed");
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

        private T XmlSerializerToClass<T>(string xml, System.Type type) where T : class 
        {
            XmlSerializer serializer = new XmlSerializer(typeof(T));
            using (StringReader reader = new StringReader(xml))
            {
                var envelope = serializer.Deserialize(reader) as T;
                if (envelope == null)
                {
                    throw new RegonAppException($"Problem With Deserialization");
                }
                return envelope;
            }
        }
    }
}
