using AssetsService.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssetsService.Core.Interfaces.Repositories
{
    public interface IAssetsRepository
    {
        Task<IEnumerable<Models.Assets>> GetAllAssets();
        Task<Byte[]> GetAssetByUrl(string url);
        Task<string> CreateAsset(Models.Assets asset);
        Task<object> UpdateAsset(Models.Assets asset, Guid id);
        Task<bool> DeleteAsset(Guid id);
    }
}
