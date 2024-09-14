using BialaListaVat.Models.SingleById;
using BialaListaVat.Repositories.Deserialization;
using BialaListaVat.Repositories.Url;
using BialaListaVat.ValueObjects.NipValue;
using BialaListaVat.ValueObjects.RegonValue;

namespace BialaListaVat.Repositories
{
    public class WhiteListVatRepository : IWhiteListVatRepository
    {
        private readonly IUrlRepository _urlRepository;
        private readonly IDeserializationRepository _deserialization;
        private readonly DateOnly _today = DateOnly.FromDateTime(DateTime.Now.ToLocalTime());
        //2024-03-24

        //Constructor
        public WhiteListVatRepository
            (
            IUrlRepository urlRepository,
            IDeserializationRepository deserialization
            )
        {
            _urlRepository = urlRepository;
            _deserialization = deserialization;
        }

        /// <summary>
        /// Data default = dzisiaj 
        /// </summary>
        /// <param name="nip"></param>
        /// <param name="cancellation"></param>
        /// <param name="date">Automaticly choose Today</param>
        /// <returns></returns>
        public async Task<Response> GetCompanyByNipAsync
            (
            string nip,
            CancellationToken cancellation,
            DateOnly date = default
            )
        {
            date = (date == default) ? _today : date;
            try
            {
                var nipValue = new Nip(nip);
                var url = _urlRepository.GenerateUrlWithNip(nipValue, date);

                return await GetSingleCompanyByUrl(url, cancellation);
            }
            catch (NipException ex)
            {
                return new Response
                {
                    IsSuccess = false,
                    IsServerProblem = false,
                    Message = ex.Message,
                };
            }
        }

        /// <summary>
        /// Data default = dzisiaj 
        /// </summary>
        /// <param name="nip"></param>
        /// <param name="cancellation"></param>
        /// <param name="date">Automaticly choose Today</param>
        /// <returns></returns>
        public async Task<Response> GetCompanyByRegonAsync
            (
            string regon,
            CancellationToken cancellation,
            DateOnly date = default
            )
        {
            date = (date == default) ? _today : date;
            try
            {
                var regonValue = new Regon(regon);
                var url = _urlRepository.GenerateUrlWithRegon(regonValue, date);

                return await GetSingleCompanyByUrl(url, cancellation);
            }
            catch (RegonException ex)
            {
                return new Response
                {
                    IsSuccess = false,
                    IsServerProblem = false,
                    Message = ex.Message,
                };
            }
        }

        //===========================================================================================================================================
        //===========================================================================================================================================
        //Private Methods
        //===========================================================================================================================================

        private async Task<Response> GetSingleCompanyByUrl
            (
            string url,
            CancellationToken cancellation
            )
        {
            try
            {
                using (var client = new HttpClient())
                using (var response = await client.GetAsync(url, cancellation))
                {
                    var body = await response.Content.ReadAsStringAsync(cancellation);

                    if (response.IsSuccessStatusCode)
                    {
                        var correct = _deserialization.DeserializationSingleCompany(body);
                        return new Response
                        {
                            IsSuccess = false,
                            IsServerProblem = false,
                            Message = Messages.MessageForClientOk,
                            Company = correct,
                        };
                    }
                    else
                    {
                        var exeption = _deserialization.DeserializationIncorrectResponse(body);
                        return new Response
                        {
                            IsSuccess = false,
                            IsServerProblem = false,
                            Message = exeption.Message,
                        };
                    }
                }
            }
            catch (Exception ex)
            {
                await WriteExeptionToFile(ex);
                return new Response
                {
                    IsSuccess = false,
                    IsServerProblem = true,
                    Message = Messages.MessageForClientServerError,
                };
            }
        }
        private async Task WriteExeptionToFile(Exception ex)
        {
            var directoryPath = Directory.GetParent(Directory.GetCurrentDirectory());
            var fileName = $"Exeptions BialaListaVat {DateOnly.FromDateTime(DateTime.UtcNow).ToString("yyyy-MM-dd")}.txt";
            var fullPath = $"{directoryPath}/{fileName}";

            if (!File.Exists(fullPath))
            {
                File.Create(fullPath);
            }

            await using (FileStream fs = File.Open(
                                                    fullPath,
                                                    FileMode.Append,
                                                    FileAccess.Write,
                                                    FileShare.ReadWrite
                                                   )
                )
            {
                await using (BufferedStream bs = new BufferedStream(fs))
                {
                    using (var sw = new StreamWriter(bs))
                    {
                        await sw.WriteLineAsync($"{ex.GetType().Name}; {ex.Message};");
                    }
                }
            }
        }
    }
}
