using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AssetsService.Core.Interfaces.Repositories;
using AssetsService.Core.Interfaces.Services;

namespace AssetsService.Core.Services
{
    public class AssetsService : IAssetsService
    {
        private readonly IAssetsRepository _assetsRepository;
        private readonly ILogger<AssetsService> _logger;
        public AssetsService(IAssetsRepository assetsRepository, ILogger<AssetsService> logger)
        {
            _assetsRepository = assetsRepository ?? throw new ArgumentNullException(nameof(assetsRepository));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }
        public async Task<Models.Assets> CreateAsset(Models.Assets assets)
        {
            try
            {
                if (assets == null)
                {
                    throw new ArgumentNullException(nameof(assets));
                }
                return await _assetsRepository.CreateAsset(assets);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error while trying to call Create Assets in service class, Error Message = {ex}.");
                throw;
            }
        }

        public async Task<bool> DeleteAsset(Guid id)
        {
            try
            {
                return await _assetsRepository.DeleteAsset(id);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error while trying to call Delete Assets in service class, Error Message = {ex}.");
                throw;
            }
        }

        public async Task<IEnumerable<Models.Assets>> GetAllAssets()
        {
            try
            {
                /*throw new ArgumentNullException();*/
                return await _assetsRepository.GetAllAssets();

            }
            catch (Exception ex)
            {
                _logger.LogError($"Error while trying to call Get All Assetss in service class, Error Message = {ex}.");
                throw;
            }
        }

        public async Task<Models.Assets> GetAssetById(Guid id)
        {
            try
            {
                return await _assetsRepository.GetAssetById(id);

            }
            catch (Exception ex)
            {
                _logger.LogError($"Error while trying to call Get Assets By Id in service class, Error Message = {ex}.");
                throw;
            }
        }

        public async Task<object> UpdateAsset(Models.Assets assets, Guid id)
        {
            try
            {
                if (assets == null)
                {
                    throw new ArgumentNullException(nameof(assets));
                }
                return await _assetsRepository.UpdateAsset(assets, id);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error while trying to call Update Assets in service class, Error Message = {ex}.");
                throw;
            }
        }
    }
}
