using Regon.AggregatesAndEntities.DanePobierzPelnyRaport.CoreResponse.Level5DaneClasses;
using Regon.AggregatesAndEntities.DaneSzukaj.CoreResponse.Level5;
using Regon.CustomExceptions;
using Regon.Factories;
using Regon.ValueObjectsAndTheirExceptions.CustomDateOnlyXmlElement;
using Regon.ValueObjectsAndTheirExceptions.NazwaRaportuValue;
using Regon.ValueObjectsAndTheirExceptions.SessionIdValue;
using Regon.ValueObjectsAndTheirExceptions.UserKeyValue;
using System.Reflection;
using System.Xml.Serialization;

namespace Regon.Repositories.EnvelopesDeserialization
{
    /// <summary>
    /// Klasa dla deserializacji 
    /// </summary>
    /// <exception cref="UserKeyException"></exception>
    /// <exception cref="AppException"></exception>
    /// <exception cref="CustomDateOnlyException"></exception>
    public class DeserializationRepository : IDeserializationRepository
    {
        /// <summary>
        /// Zaloguj sie i pobierz SessionId
        /// </summary>
        /// <param name="envelope">SOAP Envelpe</param>
        /// <returns></returns>
        /// <exception cref="AppException"></exception>
        /// <exception cref="UserKeyException"></exception>
        public SesionId DeserializeResponseFromZalogujRequestAndReturnSid(string envelope)
        {
            var envelopeClass = MakeDeserializationToClass<AggregatesAndEntities.Zaloguj.CoreResponse.Envelope>(envelope);

            if (
                envelopeClass.Header == null ||
                envelopeClass.Body == null ||
                envelopeClass.Body.ZalogujResponse == null
                )
            {
                throw new AppException(MessagesFactory.GenerateExeptionMessageDeserializationProblem
                    (
                    this.GetType(),
                    MethodBase.GetCurrentMethod(),
                    envelope
                    ));
            }
            return new SesionId(envelopeClass.Body.ZalogujResponse.ZalogujResult);
        }

        /// <summary>
        /// Wyloguj sie i pobierz status wylogowania
        /// </summary>
        /// <param name="envelope">SOAP Envelpe</param>
        /// <returns></returns>
        /// <exception cref="AppException"></exception>
        public bool DeserializeResponseFromWylogujRequestAndReturnStatus(string envelope)
        {
            var envelopeClass = MakeDeserializationToClass<AggregatesAndEntities.Wyloguj.CoreResponse.Envelope>(envelope);

            if (
                envelopeClass.Header == null ||
                envelopeClass.Body == null ||
                envelopeClass.Body.WylogujResponse == null
                )
            {
                throw new AppException(MessagesFactory.GenerateExeptionMessageDeserializationProblem
                    (
                    this.GetType(),
                    MethodBase.GetCurrentMethod(),
                    envelope
                    ));
            }
            return envelopeClass.Body.WylogujResponse.WylogujResult;
        }

        /// <summary>
        /// Pobierz Dane podstawowe Działnosci gospodarczej
        /// </summary>
        /// <param name="envelope">SOAP Envelope</param>
        /// <param name="exception">Any Exeption</param>
        /// <returns></returns>
        /// <exception cref="AppException"></exception>
        public DanePodstawowe DeserializeResponseFromDaneSzukajToDanePodstawowe
            (
            string envelope,
            Exception exception
            )
        {
            envelope = ReplaceSpecifySignsToXml(envelope);

            var envelopeClass = MakeDeserializationToClass<AggregatesAndEntities.DaneSzukaj.CoreResponse.Envelope>(envelope);

            if (
                envelopeClass.Header == null ||
                envelopeClass.Body == null ||
                envelopeClass.Body.DaneSzukajResponse == null ||
                envelopeClass.Body.DaneSzukajResponse.DaneSzukajResult == null
                )
            {
                throw new AppException(MessagesFactory.GenerateExeptionMessageDeserializationProblem
                    (
                    this.GetType(),
                    MethodBase.GetCurrentMethod(),
                    envelope
                    ));
            }
            if (envelopeClass.Body.DaneSzukajResponse.DaneSzukajResult.Root == null)
            {
                //If this is null rase exeption about uncorrect data
                throw exception;
            }
            if (envelopeClass.Body.DaneSzukajResponse.DaneSzukajResult.Root.Dane == null)
            {
                throw new AppException(MessagesFactory.GenerateExeptionMessageDeserializationProblem
                    (
                    this.GetType(),
                    MethodBase.GetCurrentMethod(),
                    envelope
                    ));
            }
            return envelopeClass.Body.DaneSzukajResponse.DaneSzukajResult.Root.Dane;
        }

        /// <summary>
        /// Pobierz Pelny Raport diałanosci gospodarczej, Dane zwracjace nalezą do klass dziedziczacych po DanePelne
        /// </summary>
        /// <param name="envelope">SOAP Envelope</param>
        /// <param name="nazwaRaportu"></param>
        /// <returns></returns>
        /// <exception cref="AppException"></exception>
        /// <exception cref="CustomDateOnlyException"></exception>
        public DanePelne DeserializeResponseFromDanePobierzPelnyRaport
            (
            string envelope,
            NazwaRaportu nazwaRaportu
            )
        {
            envelope = ReplaceSpecifySignsToXml(envelope);
            var dane = ExtractDaneFromEnvelopePobierzPelnyRaport(envelope);
            return DeserializeToDanePelne(dane, nazwaRaportu);
        }

        //========================================================================================================
        //========================================================================================================
        //Private Methods
        //========================================================================================================

        private string ExtractDaneFromEnvelopePobierzPelnyRaport(string envelope)
        {
            var envelopeClass = MakeDeserializationToClass<AggregatesAndEntities.DanePobierzPelnyRaport.CoreResponse.Envelope>(envelope);
            if (
                envelopeClass.Header == null ||
                envelopeClass.Body == null ||
                envelopeClass.Body.DanePobierzPelnyRaportResponse == null ||
                envelopeClass.Body.DanePobierzPelnyRaportResponse.DanePobierzPelnyRaportResult == null
                )
            {
                throw new AppException(MessagesFactory.GenerateExeptionMessageDeserializationProblem
                    (
                    this.GetType(),
                    MethodBase.GetCurrentMethod(),
                    envelope
                    ));
            }
            if (envelopeClass.Body.DanePobierzPelnyRaportResponse.DanePobierzPelnyRaportResult.Root == null)
            {
                throw new AppException(MessagesFactory.GenerateExeptionMessageDeserializationProblemOrHaveNoAcess
                    (
                    this.GetType(),
                    MethodBase.GetCurrentMethod(),
                    envelope
                    ));
            }
            if (envelopeClass.Body.DanePobierzPelnyRaportResponse.DanePobierzPelnyRaportResult.Root.Dane == null)
            {
                throw new AppException(MessagesFactory.GenerateExeptionMessageDeserializationProblem
                    (
                    this.GetType(),
                    MethodBase.GetCurrentMethod(),
                    envelope
                    ));
            }
            return envelopeClass.Body.DanePobierzPelnyRaportResponse.DanePobierzPelnyRaportResult.Root.Dane.OuterXml;
        }

        private DanePelne DeserializeToDanePelne
            (
            string dane,
            NazwaRaportu nazwaRaportu
            )
        {
            if (nazwaRaportu.Name == NazwaRaportuEnum.PublDaneRaportPrawna)
            {
                return (DanePelne)MakeDeserializationToClass
                <DaneJednostkiPrawnej>(dane);
            }
            else if (nazwaRaportu.Name == NazwaRaportuEnum.PublDaneRaportLokalnaPrawnej)
            {
                return (DanePelne)MakeDeserializationToClass
                <DaneJednostkiLokalnaPrawnej>(dane);
            }
            else if (nazwaRaportu.Name == NazwaRaportuEnum.PublDaneRaportLokalnaFizycznej)
            {
                return (DanePelne)MakeDeserializationToClass
                <DaneJednostkiLokalnaFizycznej>(dane);
            }
            else if (nazwaRaportu.Name == NazwaRaportuEnum.PublDaneRaportDzialalnoscFizycznejCeidg)
            {
                return (DanePelne)MakeDeserializationToClass
                <DaneJednostkiFizycznejCeidg>(dane);
            }
            else if (nazwaRaportu.Name == NazwaRaportuEnum.PublDaneRaportDzialalnoscFizycznejRolnicza)
            {
                return (DanePelne)MakeDeserializationToClass
                <DaneJednostkiFizycznejRolnicza>(dane);
            }
            else if (nazwaRaportu.Name == NazwaRaportuEnum.PublDaneRaportDzialalnoscFizycznejPozostala)
            {
                return (DanePelne)MakeDeserializationToClass
                <DaneJednostkiFizycznejPozostala>(dane);
            }
            else if (nazwaRaportu.Name == NazwaRaportuEnum.PublDaneRaportDzialalnoscFizycznejWKrupgn)
            {
                return (DanePelne)MakeDeserializationToClass
                <DaneJednostkiFizycznejWKrupgn>(dane);
            }
            throw new AppException(MessagesFactory.GenerateExeptionMessageNazwaRaportuChanged
                (
                this.GetType(),
                MethodBase.GetCurrentMethod(),
                nazwaRaportu
                ));
        }

        private T MakeDeserializationToClass<T>(string xml) where T : class
        {
            XmlSerializer serializer = new XmlSerializer(typeof(T));
            using (StringReader reader = new StringReader(xml))
            {
                var envelope = serializer.Deserialize(reader) as T;
                if (envelope == null)
                {
                    throw new AppException(
                        MessagesFactory.GenerateExeptionMessageDeserializationProblem
                            (
                            this.GetType(),
                            MethodBase.GetCurrentMethod(),
                            xml
                            )
                        );
                }
                return envelope;
            }
        }

        private string ReplaceSpecifySignsToXml(string envelope)
        {
            envelope = envelope.Replace("&lt;", "<")
                    .Replace("&gt;", ">")
                    .Replace("&#xD;", "")//"\r"
                    .Replace("&amp;", "&");
            return envelope;
        }
    }
}
