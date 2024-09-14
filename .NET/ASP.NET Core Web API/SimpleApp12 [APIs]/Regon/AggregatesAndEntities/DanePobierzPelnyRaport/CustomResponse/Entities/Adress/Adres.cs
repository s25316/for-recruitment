using Regon.AggregatesAndEntities.DanePobierzPelnyRaport.CoreResponse.Level5DaneClasses;
using System.Text.Json.Serialization;

namespace Regon.AggregatesAndEntities.DanePobierzPelnyRaport.CustomResponse.Entities.Adress
{
    public class Adres
    {
        [JsonConverter(typeof(JsonStringEnumConverter))]
        public AdresTyp Typ { get; set; }
        public string? NazwaPodmiotu { get; set; } = null;
        public string? KrajNazwa { get; private set; } = null;
        public string? WojewodztwoNazwa { get; private set; } = null;
        public string? PowiatNazwa { get; private set; } = null;
        public string? GminaNazwa { get; private set; } = null;
        public string? MiejscowoscPocztyNazwa { get; private set; } = null;
        public string? MiejscowoscNazwa { get; private set; } = null;
        public string? UlicaNazwa { get; private set; } = null;
        public string? KodPocztowy { get; private set; } = null;
        public string? NumerNieruchomosci { get; private set; } = null;
        public string? NumerLokalu { get; private set; } = null;
        public string? NietypoweMiejsceLokalizacji { get; private set; } = null;

        public Adres
            (
            AdresTyp typ,
            string? nazwaPodmiotu,
            string? krajNazwa,
            string? wojewodztwoNazwa,
            string? powiatNazwa,
            string? gminaNazwa,
            string? miejscowoscPocztyNazwa,
            string? miejscowoscNazwa,
            string? ulicaNazwa,
            string? kodPocztowy,
            string? numerNieruchomosci,
            string? numerLokalu,
            string? nietypoweMiejsceLokalizacji
            )
        {
            Typ = typ;
            NazwaPodmiotu = nazwaPodmiotu;
            KrajNazwa = krajNazwa;
            WojewodztwoNazwa = wojewodztwoNazwa;
            PowiatNazwa = powiatNazwa;
            GminaNazwa = gminaNazwa;
            MiejscowoscPocztyNazwa = miejscowoscPocztyNazwa;
            MiejscowoscNazwa = miejscowoscNazwa;
            UlicaNazwa = ulicaNazwa;
            KodPocztowy = kodPocztowy;
            NumerNieruchomosci = numerNieruchomosci;
            NumerLokalu = numerLokalu;
            NietypoweMiejsceLokalizacji = nietypoweMiejsceLokalizacji;
        }



        public static Adres Siedziba(DaneJednostkiFizycznejCeidg dane)
        {
            return new Adres
               (
                typ: AdresTyp.Siedziba,
                   nazwaPodmiotu: dane.FizNazwa,
                   krajNazwa: ReturnStringOrNull(dane.FizAdSiedzKrajNazwa),
                   wojewodztwoNazwa: ReturnStringOrNull(dane.FizAdSiedzWojewodztwoNazwa),
                   powiatNazwa: ReturnStringOrNull(dane.FizAdSiedzPowiatNazwa),
                   gminaNazwa: ReturnStringOrNull(dane.FizAdSiedzGminaNazwa),
                   miejscowoscPocztyNazwa: ReturnStringOrNull(dane.FizAdSiedzMiejscowoscPocztyNazwa),
                   miejscowoscNazwa: ReturnStringOrNull(dane.FizAdSiedzMiejscowoscNazwa),
                   ulicaNazwa: ReturnStringOrNull(dane.FizAdSiedzUlicaNazwa),
                   kodPocztowy: ReturnStringOrNull(dane.FizAdSiedzKodPocztowy),
                   numerNieruchomosci: ReturnStringOrNull(dane.FizAdSiedzNumerNieruchomosci),
                   numerLokalu: ReturnStringOrNull(dane.FizAdSiedzNumerLokalu),
                   nietypoweMiejsceLokalizacji: ReturnStringOrNull(dane.FizAdSiedzNietypoweMiejsceLokalizacji)
               );
        }
        public static Adres Siedziba(DaneJednostkiFizycznejPozostala dane)
        {
            return new Adres
                (
                typ: AdresTyp.Siedziba,
                    nazwaPodmiotu: dane.FizNazwa,
                    krajNazwa: ReturnStringOrNull(dane.FizAdSiedzKrajNazwa),
                    wojewodztwoNazwa: ReturnStringOrNull(dane.FizAdSiedzWojewodztwoNazwa),
                    powiatNazwa: ReturnStringOrNull(dane.FizAdSiedzPowiatNazwa),
                    gminaNazwa: ReturnStringOrNull(dane.FizAdSiedzGminaNazwa),
                    miejscowoscPocztyNazwa: ReturnStringOrNull(dane.FizAdSiedzMiejscowoscPocztyNazwa),
                    miejscowoscNazwa: ReturnStringOrNull(dane.FizAdSiedzMiejscowoscNazwa),
                    ulicaNazwa: ReturnStringOrNull(dane.FizAdSiedzUlicaNazwa),
                    kodPocztowy: ReturnStringOrNull(dane.FizAdSiedzKodPocztowy),
                    numerNieruchomosci: ReturnStringOrNull(dane.FizAdSiedzNumerNieruchomosci),
                    numerLokalu: ReturnStringOrNull(dane.FizAdSiedzNumerLokalu),
                    nietypoweMiejsceLokalizacji: ReturnStringOrNull(dane.FizAdSiedzNietypoweMiejsceLokalizacji)
                );
        }
        public static Adres Siedziba(DaneJednostkiFizycznejRolnicza dane)
        {
            return new Adres
                (
                typ: AdresTyp.Siedziba,
                    nazwaPodmiotu: dane.FizNazwa,
                    krajNazwa: ReturnStringOrNull(dane.FizAdSiedzKrajNazwa),
                    wojewodztwoNazwa: ReturnStringOrNull(dane.FizAdSiedzWojewodztwoNazwa),
                    powiatNazwa: ReturnStringOrNull(dane.FizAdSiedzPowiatNazwa),
                    gminaNazwa: ReturnStringOrNull(dane.FizAdSiedzGminaNazwa),
                    miejscowoscPocztyNazwa: ReturnStringOrNull(dane.FizAdSiedzMiejscowoscPocztyNazwa),
                    miejscowoscNazwa: ReturnStringOrNull(dane.FizAdSiedzMiejscowoscNazwa),
                    ulicaNazwa: ReturnStringOrNull(dane.FizAdSiedzUlicaNazwa),
                    kodPocztowy: ReturnStringOrNull(dane.FizAdSiedzKodPocztowy),
                    numerNieruchomosci: ReturnStringOrNull(dane.FizAdSiedzNumerNieruchomosci),
                    numerLokalu: ReturnStringOrNull(dane.FizAdSiedzNumerLokalu),
                    nietypoweMiejsceLokalizacji: ReturnStringOrNull(dane.FizAdSiedzNietypoweMiejsceLokalizacji)
                );
        }
        public static Adres Siedziba(DaneJednostkiFizycznejWKrupgn dane)
        {
            return new Adres
               (
                    typ: AdresTyp.Siedziba,
                    nazwaPodmiotu: dane.FizNazwa,
                    krajNazwa: ReturnStringOrNull(dane.FizAdSiedzKrajNazwa),
                    wojewodztwoNazwa: ReturnStringOrNull(dane.FizAdSiedzWojewodztwoNazwa),
                    powiatNazwa: ReturnStringOrNull(dane.FizAdSiedzPowiatNazwa),
                    gminaNazwa: ReturnStringOrNull(dane.FizAdSiedzGminaNazwa),
                    miejscowoscPocztyNazwa: ReturnStringOrNull(dane.FizAdSiedzMiejscowoscPocztyNazwa),
                    miejscowoscNazwa: ReturnStringOrNull(dane.FizAdSiedzMiejscowoscNazwa),
                    ulicaNazwa: ReturnStringOrNull(dane.FizAdSiedzUlicaNazwa),
                    kodPocztowy: ReturnStringOrNull(dane.FizAdSiedzKodPocztowy),
                    numerNieruchomosci: ReturnStringOrNull(dane.FizAdSiedzNumerNieruchomosci),
                    numerLokalu: ReturnStringOrNull(dane.FizAdSiedzNumerLokalu),
                    nietypoweMiejsceLokalizacji: ReturnStringOrNull(dane.FizAdSiedzNietypoweMiejsceLokalizacji)
                );
        }
        public static Adres Siedziba(DaneJednostkiPrawnej dane)
        {
            return new Adres
              (
                typ: AdresTyp.Siedziba,
                nazwaPodmiotu: dane.PrawNazwa,
                krajNazwa: ReturnStringOrNull(dane.PrawAdSiedzKrajNazwa),
                wojewodztwoNazwa: ReturnStringOrNull(dane.PrawAdSiedzWojewodztwoNazwa),
                powiatNazwa: ReturnStringOrNull(dane.PrawAdSiedzPowiatNazwa),
                gminaNazwa: ReturnStringOrNull(dane.PrawAdSiedzGminaNazwa),
                miejscowoscPocztyNazwa: ReturnStringOrNull(dane.PrawAdSiedzMiejscowoscPocztyNazwa),
                miejscowoscNazwa: ReturnStringOrNull(dane.PrawAdSiedzMiejscowoscNazwa),
                ulicaNazwa: ReturnStringOrNull(dane.PrawAdSiedzUlicaNazwa),
                kodPocztowy: ReturnStringOrNull(dane.PrawAdSiedzKodPocztowy),
                numerNieruchomosci: ReturnStringOrNull(dane.PrawAdSiedzNumerNieruchomosci),
                numerLokalu: ReturnStringOrNull(dane.PrawAdSiedzNumerLokalu),
                nietypoweMiejsceLokalizacji: ReturnStringOrNull(dane.PrawAdSiedzNietypoweMiejsceLokalizacji)
              );
        }
        public static Adres Korespondencja(DaneJednostkiPrawnej dane)
        {
            return new Adres
                (
                typ: AdresTyp.Korespondencja,
                    nazwaPodmiotu: ReturnStringOrNull(dane.PrawAdKorNazwaPodmiotuDoKorespondencji),
                    krajNazwa: ReturnStringOrNull(dane.PrawAdKorKrajNazwa),
                    wojewodztwoNazwa: ReturnStringOrNull(dane.PrawAdKorWojewodztwoNazwa),
                    powiatNazwa: ReturnStringOrNull(dane.PrawAdKorPowiatNazwa),
                    gminaNazwa: ReturnStringOrNull(dane.PrawAdKorGminaNazwa),
                    miejscowoscPocztyNazwa: ReturnStringOrNull(dane.PrawAdKorMiejscowoscPocztyNazwa),
                    miejscowoscNazwa: ReturnStringOrNull(dane.PrawAdKorMiejscowoscNazwa),
                    ulicaNazwa: ReturnStringOrNull(dane.PrawAdKorUlicaNazwa),
                    kodPocztowy: ReturnStringOrNull(dane.PrawAdKorKodPocztowy),
                    numerNieruchomosci: ReturnStringOrNull(dane.PrawAdKorNumerNieruchomosci),
                    numerLokalu: ReturnStringOrNull(dane.PrawAdKorNumerLokalu),
                    nietypoweMiejsceLokalizacji: ReturnStringOrNull(dane.PrawAdKorNietypoweMiejsceLokalizacji)
                );
        }
        public static Adres Siedziba(DaneJednostkiLokalnaFizycznej dane)
        {
            return new Adres
              (
                    typ: AdresTyp.Siedziba,
                    nazwaPodmiotu: dane.Lokfiz_nazwa,
                    krajNazwa: ReturnStringOrNull(dane.Lokfiz_adSiedzKraj_Nazwa),
                    wojewodztwoNazwa: ReturnStringOrNull(dane.Lokfiz_adSiedzWojewodztwo_Nazwa),
                    powiatNazwa: ReturnStringOrNull(dane.Lokfiz_adSiedzPowiat_Nazwa),
                    gminaNazwa: ReturnStringOrNull(dane.Lokfiz_adSiedzGmina_Nazwa),
                    miejscowoscPocztyNazwa: ReturnStringOrNull(dane.Lokfiz_adSiedzMiejscowoscPoczty_Nazwa),
                    miejscowoscNazwa: ReturnStringOrNull(dane.Lokfiz_adSiedzMiejscowosc_Nazwa),
                    ulicaNazwa: ReturnStringOrNull(dane.Lokfiz_adSiedzUlica_Nazwa),
                    kodPocztowy: ReturnStringOrNull(dane.Lokfiz_adSiedzKodPocztowy),
                    numerNieruchomosci: ReturnStringOrNull(dane.Lokfiz_adSiedzNumerNieruchomosci),
                    numerLokalu: ReturnStringOrNull(dane.Lokfiz_adSiedzNumerLokalu),
                    nietypoweMiejsceLokalizacji: ReturnStringOrNull(dane.Lokfiz_adSiedzNietypoweMiejsceLokalizacji)
                );
        }
        public static Adres Siedziba(DaneJednostkiLokalnaPrawnej dane)
        {
            return new Adres
              (
                    typ: AdresTyp.Siedziba,
                    nazwaPodmiotu: dane.LokprawNazwa,
                    krajNazwa: ReturnStringOrNull(dane.LokprawAdSiedzKrajNazwa),
                    wojewodztwoNazwa: ReturnStringOrNull(dane.LokprawAdSiedzWojewodztwoNazwa),
                    powiatNazwa: ReturnStringOrNull(dane.LokprawAdSiedzPowiatNazwa),
                    gminaNazwa: ReturnStringOrNull(dane.LokprawAdSiedzGminaNazwa),
                    miejscowoscPocztyNazwa: ReturnStringOrNull(dane.LokprawAdSiedzMiejscowoscPocztyNazwa),
                    miejscowoscNazwa: ReturnStringOrNull(dane.LokprawAdSiedzMiejscowoscNazwa),
                    ulicaNazwa: ReturnStringOrNull(dane.LokprawAdSiedzUlicaNazwa),
                    kodPocztowy: ReturnStringOrNull(dane.LokprawAdSiedzKodPocztowy),
                    numerNieruchomosci: ReturnStringOrNull(dane.LokprawAdSiedzNumerNieruchomosci),
                    numerLokalu: ReturnStringOrNull(dane.LokprawAdSiedzNumerLokalu),
                    nietypoweMiejsceLokalizacji: ReturnStringOrNull(dane.LokprawAdSiedzNietypoweMiejsceLokalizacji)
                );
        }


        public bool IsNull()
        {
            return string.IsNullOrEmpty(KrajNazwa)
                        && string.IsNullOrEmpty(WojewodztwoNazwa)
                        && string.IsNullOrEmpty(PowiatNazwa)
                        && string.IsNullOrEmpty(GminaNazwa)
                        && string.IsNullOrEmpty(MiejscowoscPocztyNazwa)
                        && string.IsNullOrEmpty(MiejscowoscNazwa)
                        && string.IsNullOrEmpty(UlicaNazwa)
                        && string.IsNullOrEmpty(KodPocztowy)
                        && string.IsNullOrEmpty(NumerNieruchomosci)
                        && string.IsNullOrEmpty(NumerLokalu)
                        && string.IsNullOrEmpty(NietypoweMiejsceLokalizacji);
        }
        //==================================================================================================
        //==================================================================================================
        //Private Methods
        //==================================================================================================
        private static string? ReturnStringOrNull(string? value)
        {
            if (string.IsNullOrEmpty(value))
            {
                return null;
            }
            return value;
        }
    }
}
