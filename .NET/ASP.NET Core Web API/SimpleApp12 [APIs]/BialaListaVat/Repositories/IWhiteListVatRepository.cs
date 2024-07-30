using BialaListaVat.Models.SingleById;

namespace BialaListaVat.Repositories
{
    public interface IWhiteListVatRepository
    {
        Task<ResponseDTO> GetCompanyDataByNipAsync(string nip, CancellationToken cancellation);
        Task<ResponseDTO> GetCompanyDataByRegonAsync(string regon, CancellationToken cancellation);
    }
}
