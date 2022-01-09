using AttributeService.Core.Interfaces.Repositories;
using AttributeService.Core.Models;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using AttributeService.Infrastructure.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AttributeService.Infrastructure.Repositories
{
    public class AttributeRepository : IAttributeRepository
    {
        private readonly AttributeDbContext _dbContext;
        private readonly IMapper _mapper;
        public async Task<Core.Models.Attribute> CreateAttribute(Core.Models.Attribute attribute)
        {
            var dbAttribute = _mapper.Map<Entities.Attribute>(attribute);
            await _dbContext.Attributes.AddAsync(dbAttribute);
            await _dbContext.SaveChangesAsync();
            return _mapper.Map<Core.Models.Attribute>(dbAttribute);
        }

        public async Task<bool> DeleteAttribute(Guid id)
        {
            var attribute = await _dbContext.Attributes.FindAsync(id);
            if (attribute != null)
            {
                // Delete attribute
                _dbContext.Attributes.Remove(attribute);
                // Commit 
                await _dbContext.SaveChangesAsync();
                return true;
            }
            return false;
        }

        public async Task<IEnumerable<Core.Models.Attribute>> GetAllAttributes()
        {
            var attributes = await _dbContext.Attributes.ToListAsync().ConfigureAwait(false);
            if (attributes != null)
            {
                return _mapper.Map<IEnumerable<Core.Models.Attribute>>(attributes);
            }
            return null;
        }

        public async Task<Core.Models.Attribute> GetAttributeById(Guid id)
        {
            var attribute = await _dbContext.Attributes.FindAsync(id);
            if (attribute != null)
            {
                return _mapper.Map<Core.Models.Attribute>(attribute);
            }
            return null;
        }

        public async Task<object> UpdateAttribute(Core.Models.Attribute attribute, Guid id)
        {
            var dbAttribute = await _dbContext.Attributes.FindAsync(id);

            if (dbAttribute == null || dbAttribute.Id != id)
            {
                return new { message = "Not found!" };
            }
            // Handle concurrency
            if (dbAttribute.UpdatedAt != attribute.UpdatedAt)
            {
                return new { message = "Attribute has been updated, please refresh the page!" };
            }
            dbAttribute.Name = attribute.Name;
            dbAttribute.UpdatedAt = DateTime.Now;

            // Update attribute
            _dbContext.Attributes.Update(dbAttribute);
            //Commit
            await _dbContext.SaveChangesAsync();
            return new { message = "Update success!", attribute = dbAttribute };
        }
    }
}
