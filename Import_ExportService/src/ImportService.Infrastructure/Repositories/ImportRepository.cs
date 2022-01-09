using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ImportService.Infrastructure.Context;
using ImportService.Infrastructure.Entities;
using ImportService.Core.Models;
using ImportService.Core.Interfaces.Repositories;

namespace ImportService.Infrastructure.Repositories
{
    public class ImportRepository : IImportFileRepository
    {
        private readonly ImportDbContext _dbContext;
        private readonly IMapper _mapper;

        public async Task<bool> Import(Core.Models.ImportFile importFile)
        {
            // modified here to handle import 
            var dbImportFile = _mapper.Map<Entities.ImportFile>(importFile);
            if (importFile.ObjectImported == "Product")
            {
                _dbContext.Products.Add(new Product());
            }    
            await _dbContext.SaveChangesAsync();
            return true;
        }
    }
}
