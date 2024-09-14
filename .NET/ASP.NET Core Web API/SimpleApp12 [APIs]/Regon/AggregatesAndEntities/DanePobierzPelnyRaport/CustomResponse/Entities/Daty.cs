using Regon.AggregatesAndEntities.DanePobierzPelnyRaport.CoreResponse.Level5DaneClasses;
using Regon.ValueObjectsAndTheirExceptions.CustomDateOnlyXmlElement;

namespace Regon.AggregatesAndEntities.DanePobierzPelnyRaport.CustomResponse.Entities
{
    public class Daty
    {
        public DateOnly? DataPowstania { get; private set; } = null;
        public DateOnly? DataRozpoczeciaDzialalnosci { get; private set; } = null;
        public DateOnly? DataWpisuDoREGONDzialalnosci { get; private set; } = null;
        public DateOnly? DataZawieszeniaDzialalnosci { get; private set; } = null;
        public DateOnly? DataWznowieniaDzialalnosci { get; private set; } = null;
        public DateOnly? DataZaistnieniaZmianyDzialalnosci { get; private set; } = null;
        public DateOnly? DataZakonczeniaDzialalnosci { get; private set; } = null;
        public DateOnly? DataSkresleniazRegonDzialalnosci { get; private set; } = null;
        public DateOnly? DataWpisuDoRejestruEwidencji { get; private set; } = null;

        public Daty
            (
            DateOnly? dataPowstania,
            DateOnly? dataRozpoczeciaDzialalnosci,
            DateOnly? dataWpisuDoREGONDzialalnosci,
            DateOnly? dataZawieszeniaDzialalnosci,
            DateOnly? dataWznowieniaDzialalnosci,
            DateOnly? dataZaistnieniaZmianyDzialalnosci,
            DateOnly? dataZakonczeniaDzialalnosci,
            DateOnly? dataSkresleniazRegonDzialalnosci,
            DateOnly? dataWpisuDoRejestruEwidencji)
        {
            DataPowstania = dataPowstania;
            DataRozpoczeciaDzialalnosci = dataRozpoczeciaDzialalnosci;
            DataWpisuDoREGONDzialalnosci = dataWpisuDoREGONDzialalnosci;
            DataZawieszeniaDzialalnosci = dataZawieszeniaDzialalnosci;
            DataWznowieniaDzialalnosci = dataWznowieniaDzialalnosci;
            DataZaistnieniaZmianyDzialalnosci = dataZaistnieniaZmianyDzialalnosci;
            DataZakonczeniaDzialalnosci = dataZakonczeniaDzialalnosci;
            DataSkresleniazRegonDzialalnosci = dataSkresleniazRegonDzialalnosci;
            DataWpisuDoRejestruEwidencji = dataWpisuDoRejestruEwidencji;
        }

        public static implicit operator Daty(DaneJednostkiFizycznejCeidg dane)
        {
            return new Daty
                (
                    dataPowstania: ReturnDateOnlyOrNull(dane.FizDataPowstania),
                    dataRozpoczeciaDzialalnosci: ReturnDateOnlyOrNull(dane.FizDataRozpoczeciaDzialalnosci),
                    dataWpisuDoREGONDzialalnosci: ReturnDateOnlyOrNull(dane.FizDataWpisuDoREGONDzialalnosci),
                    dataZawieszeniaDzialalnosci: ReturnDateOnlyOrNull(dane.FizDataZawieszeniaDzialalnosci),
                    dataWznowieniaDzialalnosci: ReturnDateOnlyOrNull(dane.FizDataWznowieniaDzialalnosci),
                    dataZaistnieniaZmianyDzialalnosci: ReturnDateOnlyOrNull(dane.FizDataZaistnieniaZmianyDzialalnosci),
                    dataZakonczeniaDzialalnosci: ReturnDateOnlyOrNull(dane.FizDataZakonczeniaDzialalnosci),
                    dataSkresleniazRegonDzialalnosci: ReturnDateOnlyOrNull(dane.FizDataSkresleniazRegonDzialalnosci),
                    dataWpisuDoRejestruEwidencji: ReturnDateOnlyOrNull(dane.FizCDataWpisuDoRejestruEwidencji)
                );
        }
        public static implicit operator Daty(DaneJednostkiFizycznejPozostala dane)
        {
            return new Daty
                (
                    dataPowstania: ReturnDateOnlyOrNull(dane.FizDataPowstania),
                    dataRozpoczeciaDzialalnosci: ReturnDateOnlyOrNull(dane.FizDataRozpoczeciaDzialalnosci),
                    dataWpisuDoREGONDzialalnosci: ReturnDateOnlyOrNull(dane.FizDataWpisuDoREGONDzialalnosci),
                    dataZawieszeniaDzialalnosci: ReturnDateOnlyOrNull(dane.FizDataZawieszeniaDzialalnosci),
                    dataWznowieniaDzialalnosci: ReturnDateOnlyOrNull(dane.FizDataWznowieniaDzialalnosci),
                    dataZaistnieniaZmianyDzialalnosci: ReturnDateOnlyOrNull(dane.FizDataZaistnieniaZmianyDzialalnosci),
                    dataZakonczeniaDzialalnosci: ReturnDateOnlyOrNull(dane.FizDataZakonczeniaDzialalnosci),
                    dataSkresleniazRegonDzialalnosci: ReturnDateOnlyOrNull(dane.FizDataSkresleniazRegonDzialalnosci),
                    dataWpisuDoRejestruEwidencji: ReturnDateOnlyOrNull(dane.FizPDataWpisuDoRejestruEwidencji)
                );
        }
        public static implicit operator Daty(DaneJednostkiFizycznejRolnicza dane)
        {
            return new Daty
                (
                    dataPowstania: ReturnDateOnlyOrNull(dane.FizDataPowstania),
                    dataRozpoczeciaDzialalnosci: ReturnDateOnlyOrNull(dane.FizDataRozpoczeciaDzialalnosci),
                    dataWpisuDoREGONDzialalnosci: ReturnDateOnlyOrNull(dane.FizDataWpisuDoREGONDzialalnosci),
                    dataZawieszeniaDzialalnosci: ReturnDateOnlyOrNull(dane.FizDataZawieszeniaDzialalnosci),
                    dataWznowieniaDzialalnosci: ReturnDateOnlyOrNull(dane.FizDataWznowieniaDzialalnosci),
                    dataZaistnieniaZmianyDzialalnosci: ReturnDateOnlyOrNull(dane.FizDataZaistnieniaZmianyDzialalnosci),
                    dataZakonczeniaDzialalnosci: ReturnDateOnlyOrNull(dane.FizDataZakonczeniaDzialalnosci),
                    dataSkresleniazRegonDzialalnosci: ReturnDateOnlyOrNull(dane.FizDataSkresleniazRegonDzialalnosci),
                    dataWpisuDoRejestruEwidencji: null
                );
        }
        public static implicit operator Daty(DaneJednostkiFizycznejWKrupgn dane)
        {
            return new Daty
                (
                    dataPowstania: ReturnDateOnlyOrNull(dane.FizDataPowstania),
                    dataRozpoczeciaDzialalnosci: ReturnDateOnlyOrNull(dane.FizDataRozpoczeciaDzialalnosci),
                    dataWpisuDoREGONDzialalnosci: ReturnDateOnlyOrNull(dane.FizDataWpisuDoREGONDzialalnosci),
                    dataZawieszeniaDzialalnosci: ReturnDateOnlyOrNull(dane.FizDataZawieszeniaDzialalnosci),
                    dataWznowieniaDzialalnosci: ReturnDateOnlyOrNull(dane.FizDataWznowieniaDzialalnosci),
                    dataZaistnieniaZmianyDzialalnosci: ReturnDateOnlyOrNull(dane.FizDataZaistnieniaZmianyDzialalnosci),
                    dataZakonczeniaDzialalnosci: ReturnDateOnlyOrNull(dane.FizDataZakonczeniaDzialalnosci),
                    dataSkresleniazRegonDzialalnosci: ReturnDateOnlyOrNull(dane.FizDataSkresleniazRegonDzialalnosci),
                    dataWpisuDoRejestruEwidencji: null
                );
        }
        public static implicit operator Daty(DaneJednostkiPrawnej dane)
        {
            return new Daty
                (
                    dataPowstania: ReturnDateOnlyOrNull(dane.PrawDataPowstania),
                    dataRozpoczeciaDzialalnosci: ReturnDateOnlyOrNull(dane.PrawDataRozpoczeciaDzialalnosci),
                    dataWpisuDoREGONDzialalnosci: ReturnDateOnlyOrNull(dane.PrawDataWpisuDoREGON),
                    dataZawieszeniaDzialalnosci: ReturnDateOnlyOrNull(dane.PrawDataZawieszeniaDzialalnosci),
                    dataWznowieniaDzialalnosci: ReturnDateOnlyOrNull(dane.PrawDataWznowieniaDzialalnosci),
                    dataZaistnieniaZmianyDzialalnosci: ReturnDateOnlyOrNull(dane.PrawDataZaistnieniaZmiany),
                    dataZakonczeniaDzialalnosci: ReturnDateOnlyOrNull(dane.PrawDataZakonczeniaDzialalnosci),
                    dataSkresleniazRegonDzialalnosci: ReturnDateOnlyOrNull(dane.PrawDataSkresleniazRegon),
                    dataWpisuDoRejestruEwidencji: ReturnDateOnlyOrNull(dane.PrawDataWpisuDoRejestruEwidencji)
                );
        }
        public static implicit operator Daty(DaneJednostkiLokalnaFizycznej dane)
        {
            return new Daty
                (
                    dataPowstania: ReturnDateOnlyOrNull(dane.Lokfiz_dataPowstania),
                    dataRozpoczeciaDzialalnosci: ReturnDateOnlyOrNull(dane.Lokfiz_dataRozpoczeciaDzialalnosci),
                    dataWpisuDoREGONDzialalnosci: ReturnDateOnlyOrNull(dane.Lokfiz_dataWpisuDoREGON),
                    dataZawieszeniaDzialalnosci: ReturnDateOnlyOrNull(dane.Lokfiz_dataZawieszeniaDzialalnosci),
                    dataWznowieniaDzialalnosci: ReturnDateOnlyOrNull(dane.Lokfiz_dataWznowieniaDzialalnosci),
                    dataZaistnieniaZmianyDzialalnosci: ReturnDateOnlyOrNull(dane.Lokfiz_dataZaistnieniaZmiany),
                    dataZakonczeniaDzialalnosci: ReturnDateOnlyOrNull(dane.Lokfiz_dataZakonczeniaDzialalnosci),
                    dataSkresleniazRegonDzialalnosci: ReturnDateOnlyOrNull(dane.Lokfiz_dataSkresleniazRegon),
                    dataWpisuDoRejestruEwidencji: ReturnDateOnlyOrNull(dane.Lokfiz_dataWpisuDoRejestruEwidencji)
            );
        }
        public static implicit operator Daty(DaneJednostkiLokalnaPrawnej dane)
        {
            return new Daty
                (
                    dataPowstania: ReturnDateOnlyOrNull(dane.LokprawDataPowstania),
                    dataRozpoczeciaDzialalnosci: ReturnDateOnlyOrNull(dane.LokprawDataRozpoczeciaDzialalnosci),
                    dataWpisuDoREGONDzialalnosci: ReturnDateOnlyOrNull(dane.LokprawDataWpisuDoREGON),
                    dataZawieszeniaDzialalnosci: ReturnDateOnlyOrNull(dane.LokprawDataZawieszeniaDzialalnosci),
                    dataWznowieniaDzialalnosci: ReturnDateOnlyOrNull(dane.LokprawDataWznowieniaDzialalnosci),
                    dataZaistnieniaZmianyDzialalnosci: ReturnDateOnlyOrNull(dane.LokprawDataZaistnieniaZmiany),
                    dataZakonczeniaDzialalnosci: ReturnDateOnlyOrNull(dane.LokprawDataZakonczeniaDzialalnosci),
                    dataSkresleniazRegonDzialalnosci: ReturnDateOnlyOrNull(dane.LokprawDataSkresleniazRegon),
                    dataWpisuDoRejestruEwidencji: ReturnDateOnlyOrNull(dane.LokprawDataWpisuDoRejestruEwidencji)
            );
        }

        //===================================================================================================
        //===================================================================================================
        //Private Methods
        //===================================================================================================
        private static DateOnly? ReturnDateOnlyOrNull(CustomDateOnly? value)
        {
            return value == null || value.DateOnly == null ? null : value.DateOnly;
        }
    }
}
