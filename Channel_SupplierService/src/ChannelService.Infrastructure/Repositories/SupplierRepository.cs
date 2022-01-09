using ChannelService.Core.Interfaces.Repositories;
using ChannelService.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChannelService.Infrastructure.Repositories
{
    public class SupplierRepository : ISupplierRepository
    {
        public Task<Supplier> CreateSupplier(Supplier supplier)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteCategory(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Supplier>> GetAllSuppiers()
        {
            throw new NotImplementedException();
        }

        public Task<Supplier> GetSupplierById(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<object> UpdateSupplier(Supplier supplier, Guid id)
        {
            throw new NotImplementedException();
        }
    }
}
