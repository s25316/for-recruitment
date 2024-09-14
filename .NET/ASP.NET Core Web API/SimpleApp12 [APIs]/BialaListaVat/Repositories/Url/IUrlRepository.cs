using BialaListaVat.ValueObjects.NipValue;
using BialaListaVat.ValueObjects.RegonValue;

namespace BialaListaVat.Repositories.Url
{
    public interface IUrlRepository
    {
        string GenerateUrlWithNip(Nip nip, DateOnly date);
        string GenerateUrlWithRegon(Regon regon, DateOnly date);
        bool IsValidHttpOrHttpsUrl(string url);
    }
}
