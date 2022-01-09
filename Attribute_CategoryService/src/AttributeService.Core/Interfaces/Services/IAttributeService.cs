using AttributeService.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AttributeService.Core.Interfaces.Services
{
    public interface IAttributeService
    {
        Task<IEnumerable<Models.Attribute>> GetAllAttributes();
        Task<Models.Attribute> GetAttributeById(Guid id);
        Task<Models.Attribute> CreateAttribute(Models.Attribute attribute);
        Task<object> UpdateAttribute(Models.Attribute attribute, Guid id);
        Task<bool> DeleteAttribute(Guid id);
    }
}
