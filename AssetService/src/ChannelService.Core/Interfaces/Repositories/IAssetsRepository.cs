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
        Task<Models.Assets> GetAssetById(Guid id);
        Task<Models.Assets> CreateAsset(Models.Assets asset);
        Task<object> UpdateAsset(Models.Assets asset, Guid id);
        Task<bool> DeleteAsset(Guid id);
    }
}
