using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ImportService.Core.Models;
using ImportService.Core.Interfaces.Repositories;
using ImportService.Core.Interfaces.Services;

namespace ImportService.Core.Services
{
    public class ImportService : IImportService
    {
        private readonly IImportFileRepository _importRepository;
        private readonly ILogger<ImportService> _logger;
        public ImportService(IImportFileRepository importRepository, ILogger<ImportService> logger)
        {
            _importRepository = importRepository ?? throw new ArgumentNullException(nameof(importRepository));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }
        public async Task<bool> Import(ImportFile importFile)
        {
            try
            {
                if (importFile == null)
                {
                    throw new ArgumentNullException(nameof(importFile));
                }
                return await _importRepository.Import(importFile);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error while trying to call Create Channel in service class, Error Message = {ex}.");
                throw;
            }
        }


    }
}
