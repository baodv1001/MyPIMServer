using ChannelService.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChannelService.Core.Interfaces.Services
{
    public interface ISupplierService
    {
        Task<IEnumerable<Supplier>> GetAllSuppliers();
        Task<Supplier> GetSupplierById(Guid id);
        Task<Supplier> CreateSupplier(Supplier supplier);
        Task<object> UpdateSupplier(Supplier supplier, Guid id);
        Task<bool> DeleteSupplier(Guid id);
    }
}
