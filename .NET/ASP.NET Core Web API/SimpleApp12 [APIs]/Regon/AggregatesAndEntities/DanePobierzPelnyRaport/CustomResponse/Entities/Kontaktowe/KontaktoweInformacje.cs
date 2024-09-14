using Regon.AggregatesAndEntities.DanePobierzPelnyRaport.CoreResponse.Level5DaneClasses;
using System.Text.Json.Serialization;

namespace Regon.AggregatesAndEntities.DanePobierzPelnyRaport.CustomResponse.Entities.Kontaktowe
{
    public class KontaktoweInformacje
    {
        [JsonConverter(typeof(JsonStringEnumConverter))]
        public KontaktoweInformacjeTyp Typ { get; private set; }
        public string? NumerTelefonu { get; private set; } = null;
        public string? NumerWewnetrznyTelefonu { get; private set; } = null;
        public string? NumerFaksu { get; private set; } = null;
        public string? AdresEmail { get; private set; } = null;
        public string? AdresEmail2 { get; private set; } = null;
        public string? AdresStronyinternetowej { get; private set; } = null;

        public KontaktoweInformacje
            (
            KontaktoweInformacjeTyp typ,
            string? numerTelefonu,
            string? numerWewnetrznyTelefonu,
            string? numerFaksu,
            string? adresEmail,
            string? adresEmail2,
            string? adresStronyinternetowej
            )
        {
            Typ = typ;
            NumerTelefonu = numerTelefonu;
            NumerWewnetrznyTelefonu = numerWewnetrznyTelefonu;
            NumerFaksu = numerFaksu;
            AdresEmail = adresEmail;
            AdresEmail2 = adresEmail2;
            AdresStronyinternetowej = adresStronyinternetowej;
        }

        public static KontaktoweInformacje DaneKontaktoweOgolne(DaneJednostkiFizycznejCeidg dane)
        {
            return new KontaktoweInformacje
               (
                   typ: KontaktoweInformacjeTyp.Podstawowe,
                   numerTelefonu: ReturnStringOrNull(dane.FizNumerTelefonu),
                   numerWewnetrznyTelefonu: ReturnStringOrNull(dane.FizNumerWewnetrznyTelefonu),
                   numerFaksu: ReturnStringOrNull(dane.FizNumerFaksu),
                   adresEmail: ReturnStringOrNull(dane.FizAdresEmail),
                   adresEmail2: ReturnStringOrNull(dane.FizAdresEmail2),
                   adresStronyinternetowej: ReturnStringOrNull(dane.FizAdresStronyinternetowej)
               );
        }
        public static KontaktoweInformacje DaneKontaktoweDodatkowe(DaneJednostkiFizycznejCeidg dane)
        {
            return new KontaktoweInformacje
                (
                    typ: KontaktoweInformacjeTyp.Dodatkowe,
                    numerTelefonu: ReturnStringOrNull(dane.FizCNumerTelefonu),
                    numerWewnetrznyTelefonu: ReturnStringOrNull(dane.FizCNumerWewnetrznyTelefonu),
                    numerFaksu: ReturnStringOrNull(dane.FizCNumerFaksu),
                    adresEmail: ReturnStringOrNull(dane.FizCAdresEmail),
                    adresEmail2: null,
                    adresStronyinternetowej: ReturnStringOrNull(dane.FizCAdresStronyInternetowej)
                );
        }
        public static KontaktoweInformacje DaneKontaktoweOgolne(DaneJednostkiFizycznejPozostala dane)
        {
            return new KontaktoweInformacje
                (
                    typ: KontaktoweInformacjeTyp.Podstawowe,
                    numerTelefonu: ReturnStringOrNull(dane.FizNumerTelefonu),
                    numerWewnetrznyTelefonu: ReturnStringOrNull(dane.FizNumerWewnetrznyTelefonu),
                    numerFaksu: ReturnStringOrNull(dane.FizNumerFaksu),
                    adresEmail: ReturnStringOrNull(dane.FizAdresEmail),
                    adresEmail2: ReturnStringOrNull(dane.FizAdresEmail2),
                    adresStronyinternetowej: ReturnStringOrNull(dane.FizAdresStronyinternetowej)
                );
        }
        public static KontaktoweInformacje DaneKontaktoweOgolne(DaneJednostkiFizycznejRolnicza dane)
        {
            return new KontaktoweInformacje
                (
                    typ: KontaktoweInformacjeTyp.Podstawowe,
                    numerTelefonu: ReturnStringOrNull(dane.FizNumerTelefonu),
                    numerWewnetrznyTelefonu: ReturnStringOrNull(dane.FizNumerWewnetrznyTelefonu),
                    numerFaksu: ReturnStringOrNull(dane.FizNumerFaksu),
                    adresEmail: ReturnStringOrNull(dane.FizAdresEmail),
                    adresEmail2: ReturnStringOrNull(dane.FizAdresEmail2),
                    adresStronyinternetowej: ReturnStringOrNull(dane.FizAdresStronyinternetowej)
                );
        }
        public static KontaktoweInformacje DaneKontaktoweOgolne(DaneJednostkiFizycznejWKrupgn dane)
        {
            return new KontaktoweInformacje
                (
                    typ: KontaktoweInformacjeTyp.Podstawowe,
                    numerTelefonu: ReturnStringOrNull(dane.FizNumerTelefonu),
                    numerWewnetrznyTelefonu: ReturnStringOrNull(dane.FizNumerWewnetrznyTelefonu),
                    numerFaksu: ReturnStringOrNull(dane.FizNumerFaksu),
                    adresEmail: ReturnStringOrNull(dane.FizAdresEmail),
                    adresEmail2: ReturnStringOrNull(dane.FizAdresEmail2),
                    adresStronyinternetowej: ReturnStringOrNull(dane.FizAdresStronyinternetowej)
                );
        }
        public static KontaktoweInformacje DaneKontaktoweOgolne(DaneJednostkiPrawnej dane)
        {
            return new KontaktoweInformacje
                (
                    typ: KontaktoweInformacjeTyp.Podstawowe,
                    numerTelefonu: ReturnStringOrNull(dane.PrawNumerTelefonu),
                    numerWewnetrznyTelefonu: ReturnStringOrNull(dane.PrawNumerWewnetrznyTelefonu),
                    numerFaksu: ReturnStringOrNull(dane.PrawNumerFaksu),
                    adresEmail: ReturnStringOrNull(dane.PrawAdresEmail),
                    adresEmail2: ReturnStringOrNull(dane.PrawAdresEmail2),
                    adresStronyinternetowej: ReturnStringOrNull(dane.PrawAdresStronyinternetowej)
                );
        }
        //=======================================================================================================================================================
        //=======================================================================================================================================================
        //Private Methods
        //=======================================================================================================================================================
        public bool IsNull()
        {
            return string.IsNullOrEmpty(NumerTelefonu)
                && string.IsNullOrEmpty(NumerWewnetrznyTelefonu)
                && string.IsNullOrEmpty(NumerFaksu)
                && string.IsNullOrEmpty(AdresEmail)
                && string.IsNullOrEmpty(AdresEmail2)
                && string.IsNullOrEmpty(AdresStronyinternetowej);
        }

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
