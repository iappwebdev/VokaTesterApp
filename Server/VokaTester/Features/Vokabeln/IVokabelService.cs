namespace VokaTester.Features.Vokabeln
{
    using System.Threading.Tasks;

    public interface IVokabelService
    {
        Task<int> Create(string frz, string deu, int lektionId);
    }
}
