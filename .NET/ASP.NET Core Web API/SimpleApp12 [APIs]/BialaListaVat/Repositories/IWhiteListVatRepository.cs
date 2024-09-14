using BialaListaVat.Models.SingleById;

namespace BialaListaVat.Repositories
{
    public interface IWhiteListVatRepository
    {
        /// <summary>
        /// Data default = dzisiaj 
        /// </summary>
        /// <param name="nip"></param>
        /// <param name="cancellation"></param>
        /// <param name="date">Automaticly choose Today</param>
        /// <returns></returns>
        Task<Response> GetCompanyByNipAsync(string nip, CancellationToken cancellation, DateOnly date = default);
        /// <summary>
        /// Data default = dzisiaj 
        /// </summary>
        /// <param name="regon"></param>
        /// <param name="cancellation"></param>
        /// <param name="date">Automaticly choose Today</param>
        /// <returns></returns>
        Task<Response> GetCompanyByRegonAsync(string regon, CancellationToken cancellation, DateOnly date = default);
    }
}
