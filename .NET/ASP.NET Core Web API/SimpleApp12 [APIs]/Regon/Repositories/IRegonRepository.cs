using Regon.Models.ResponseDaneSzukaj.Level4;

namespace Regon.Repositories
{
    public interface IRegonRepository
    {
        Task<Regon.Models.ResponseDaneSzukaj.Envelope> GetCompanyBYNIP
            (
            string nip,
            string userKey,
            bool askTestApi,
            CancellationToken cancellation
            );
    }
}
