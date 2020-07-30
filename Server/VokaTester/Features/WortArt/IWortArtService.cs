namespace VokaTester.Features.WortArt
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface IWortArtService
    {
        Task<IEnumerable<string>> SetWortart();
    }
}
