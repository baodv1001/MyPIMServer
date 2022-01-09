using AttributeService.Core.Interfaces.Repositories;
using AttributeService.Core.Interfaces.Services;
using AttributeService.Core.Models;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AttributeService.Core.Services
{
    public class AttributeService : IAttributeService
    {
        private readonly IAttributeRepository _attributeRepository;
        private readonly ILogger<AttributeService> _logger;
        public AttributeService(IAttributeRepository attributeRepository, ILogger<AttributeService> logger)
        {
            _attributeRepository = attributeRepository ?? throw new ArgumentNullException(nameof(attributeRepository));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }
        public async Task<Models.Attribute> CreateAttribute(Models.Attribute attribute)
        {
            try
            {
                if (attribute == null)
                {
                    throw new ArgumentNullException(nameof(attribute));
                }
                return await _attributeRepository.CreateAttribute(attribute);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error while trying to call Create Attribute in service class, Error Message = {ex}.");
                throw;
            }
        }

        public async Task<bool> DeleteAttribute(Guid id)
        {
            try
            {
                return await _attributeRepository.DeleteAttribute(id);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error while trying to call Delete Attribute in service class, Error Message = {ex}.");
                throw;
            }
        }

        public async Task<IEnumerable<Models.Attribute>> GetAllAttributes()
        {
            try
            {
                /*throw new ArgumentNullException();*/
                return await _attributeRepository.GetAllAttributes();

            }
            catch (Exception ex)
            {
                _logger.LogError($"Error while trying to call Get All Attributes in service class, Error Message = {ex}.");
                throw;
            }
        }

        public async Task<Models.Attribute> GetAttributeById(Guid id)
        {
            try
            {
                return await _attributeRepository.GetAttributeById(id);

            }
            catch (Exception ex)
            {
                _logger.LogError($"Error while trying to call Get Attribute By Id in service class, Error Message = {ex}.");
                throw;
            }
        }

        public async Task<object> UpdateAttribute(Models.Attribute attribute, Guid id)
        {
            try
            {
                if (attribute == null)
                {
                    throw new ArgumentNullException(nameof(attribute));
                }
                return await _attributeRepository.UpdateAttribute(attribute, id);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error while trying to call Update Attribute in service class, Error Message = {ex}.");
                throw;
            }
        }
    }
}
