using BialaListaVat.Models.SingleById;
using BialaListaVat.Models.SingleById.CorrectResponse;
using BialaListaVat.Models.SingleById.UncorrectResponse;
using BialaListaVat.ValueObjects.NipValue;
using BialaListaVat.ValueObjects.RegonValue;
using System.Text.Json;

namespace BialaListaVat.Repositories
{
    public class WhiteListVatRepository : IWhiteListVatRepository
    {
        private readonly string _today = DateOnly.FromDateTime(DateTime.Now.ToLocalTime()).ToString("yyyy-MM-dd");
        private readonly string _url = "https://wl-api.mf.gov.pl/api/search/";
        private readonly string _nipSegment = "nip/";
        private readonly string _regonSegment = "regon/";
        private readonly string _dateQueryString = "?date="; //2024-03-24


        public async Task<ResponseDTO> GetCompanyDataByNipAsync
            (
            string nip, 
            CancellationToken cancellation
            ) 
        {
            try
            {
                var nipValue = new Nip(nip);
            }
            catch (NipException ex) 
            {
                return new ResponseDTO 
                { 
                    IsSuccess = false,
                    Message = ex.Message,
                };
            }

            var url = $"{_url}{_nipSegment}{nip}{_dateQueryString}{_today}";
            return await GetSingleCompanyByUrl(url, cancellation);
        }

        public async Task<ResponseDTO> GetCompanyDataByRegonAsync
            (
            string regon,
            CancellationToken cancellation
            )
        {
            try 
            { 
                var regonValue = new Regon(regon);
            }
            catch (RegonException ex)
            {
                return new ResponseDTO
                {
                    IsSuccess = false,
                    Message = ex.Message,
                };
            }

            var url = $"{_url}{_regonSegment}{regon}{_dateQueryString}{_today}";

            return await GetSingleCompanyByUrl(url, cancellation);
        }

        private async Task<ResponseDTO> GetSingleCompanyByUrl
            (
            string url,
            CancellationToken cancellation
            )
        {
            if (!IsValidHttpOrHttpsUrl(url))
            {
                return new ResponseDTO
                {
                    IsSuccess = false,
                    Message = "Incorrect URL",
                    Company = null,
                };
            }

            using (var client = new HttpClient())
            using (var response = await client.GetAsync(url, cancellation))
            {
                var body = await response.Content.ReadAsStringAsync(cancellation);

                if (response.IsSuccessStatusCode)
                {
                    return SuccessStatusCodeDeserialization(body);
                }
                else
                {
                    return UnsuccessStatusCodeDeserialization(body);
                }
            }
        }

        private ResponseDTO SuccessStatusCodeDeserialization(string body) 
        {
            var result = JsonSerializer.Deserialize<EntityResponse>(body);
            if (result == null)
            {
                return new ResponseDTO
                {
                    IsSuccess = false,
                    Message = "Problem with serialization",
                    Company = null,
                };
            }
            else
            {
                return new ResponseDTO
                {
                    IsSuccess = true,
                    Message = "Success",
                    Company = result.Result.Subject,
                };
            }
        }

        private ResponseDTO UnsuccessStatusCodeDeserialization(string body)
        {
            var result = JsonSerializer.Deserialize<Incorrect>(body);
            if (result == null)
            {
                return new ResponseDTO
                {
                    IsSuccess = false,
                    Message = "Problem with serialization",
                    Company = null,
                };
            }
            else
            {
                return new ResponseDTO
                {
                    IsSuccess = false,
                    Message = result.Message,
                    Company = null,
                };
            }
        }

        private bool IsValidHttpOrHttpsUrl( string url) 
        {
            return Uri.TryCreate(url, UriKind.Absolute, out var uriResult) &&
            (uriResult.Scheme == Uri.UriSchemeHttp || uriResult.Scheme == Uri.UriSchemeHttps);
        }
    }
}
