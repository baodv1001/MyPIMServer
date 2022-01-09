using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AssetsService.Core.Interfaces.Repositories;
using AssetsService.Infrastructure.Context;
using AssetsService.Infrastructure.Entities;

namespace AssetsService.Infrastructure.Repositories
{
    public class AssetsRepository : IAssetsRepository
    {
        private readonly AssetsDbContext _dbContext;
        private readonly IMapper _mapper;
        public async Task<Core.Models.Assets> CreateAsset(Core.Models.Assets asset)
        {
            var dbAsset = _mapper.Map<Assets>(asset);
            await _dbContext.Assets.AddAsync(dbAsset);
            await _dbContext.SaveChangesAsync();
            return _mapper.Map<Core.Models.Assets>(dbAsset);
        }

        public async Task<bool> DeleteAsset(Guid id)
        {
            var asset = await _dbContext.Assets.FindAsync(id);
            if (asset != null)
            {
                // Delete asset
                _dbContext.Assets.Remove(asset);
                // Commit 
                await _dbContext.SaveChangesAsync();
                return true;
            }
            return false;
        }

        public async Task<IEnumerable<Core.Models.Assets>> GetAllAssets()
        {
            var assets = await _dbContext.Assets.ToListAsync().ConfigureAwait(false);
            if (assets != null)
            {
                return _mapper.Map<IEnumerable<Core.Models.Assets>>(assets);
            }
            return null;
        }

        public async Task<Core.Models.Assets> GetAssetById(Guid id)
        {
            var asset = await _dbContext.Assets.FindAsync(id);
            if (asset != null)
            {
                return _mapper.Map<Core.Models.Assets>(asset);
            }
            return null;
        }

        public async Task<object> UpdateAsset(Core.Models.Assets asset, Guid id)
        {
            var dbAsset = await _dbContext.Assets.FindAsync(id);

            if (dbAsset == null || dbAsset.Id != id)
            {
                return new { message = "Not found!" };
            }
            // Handle concurrency
            if (dbAsset.UpdatedAt != asset.UpdatedAt)
            {
                return new { message = "Asset has been updated, please refresh the page!" };
            }
            dbAsset.Name = asset.Name;
            dbAsset.UpdatedAt = DateTime.Now;

            // Update asset
            _dbContext.Assets.Update(dbAsset);
            //Commit
            await _dbContext.SaveChangesAsync();
            return new { message = "Update success!", asset = dbAsset };
        }
    }
}
