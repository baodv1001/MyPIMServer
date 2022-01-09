using AssetsService.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssetsService.Core.Interfaces.Services
{
    public interface IAssetsService
    {
        Task<IEnumerable<Assets>> GetAllAssets();
        Task<Assets> GetAssetByUrl(string url);
        Task<string> CreateAsset(Assets asset);
        Task<object> UpdateAsset(Assets asset, Guid id);
        Task<bool> DeleteAsset(Guid id);
    }
}
