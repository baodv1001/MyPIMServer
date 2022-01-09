using ChannelService.Core.Interfaces.Services;
using ChannelService.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChannelService.Core.Services
{
    public class SupplierService : ISupplierService
    {
        public Task<Supplier> CreateSupplier(Supplier supplier)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteSupplier(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Supplier>> GetAllSuppliers()
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
