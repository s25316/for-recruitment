using BialaListaVat.CustomExceptions;
using BialaListaVat.ValueObjects.NipValue;
using BialaListaVat.ValueObjects.RegonValue;

namespace BialaListaVat.Repositories.Url
{
    public class UrlRepository : IUrlRepository
    {
        private readonly string _url = "https://wl-api.mf.gov.pl/api/search/";
        private readonly string _nipSegment = "nip/";
        private readonly string _regonSegment = "regon/";
        private readonly string _dateQueryString = "?date=";


        public string GenerateUrlWithNip(Nip nip, DateOnly date)
        {
            var stringDate = ParseDateOnlyToString(date);
            var url = $"{_url}{_nipSegment}{nip.Number}{_dateQueryString}{stringDate}";
            RaseBialaListaVatExceptionIfIsNotValid(url);
            return url;
        }

        public string GenerateUrlWithRegon(Regon regon, DateOnly date)
        {
            var stringDate = ParseDateOnlyToString(date);
            var url = $"{_url}{_regonSegment}{regon.Number}{_dateQueryString}{stringDate}";
            RaseBialaListaVatExceptionIfIsNotValid(url);
            return url;
        }

        public bool IsValidHttpOrHttpsUrl(string url)
        {
            return Uri.TryCreate(url, UriKind.Absolute, out var uriResult) &&
            (uriResult.Scheme == Uri.UriSchemeHttp || uriResult.Scheme == Uri.UriSchemeHttps);
        }
        //===========================================================================================================================================
        //===========================================================================================================================================
        //Private Methods
        //===========================================================================================================================================
        private string ParseDateOnlyToString(DateOnly date)
        {
            return date.ToString("yyyy-MM-dd");
        }

        private void RaseBialaListaVatExceptionIfIsNotValid(string url)
        {
            if (!IsValidHttpOrHttpsUrl(url))
            {
                throw new BialaListaVatException($"{Messages.IncorrectUrl}: {url}");
            }
        }
    }
}
