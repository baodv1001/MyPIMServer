using AttributeService.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AttributeService.Core.Interfaces.Services
{
    public interface ICategoryService
    {
        Task<IEnumerable<Models.Category>> GetAllCategories();
        Task<Models.Category> GetCategoryById(Guid id);
        Task<Models.Category> CreateCategory(Models.Category category);
        Task<object> UpdateCategory(Models.Category category, Guid id);
        Task<bool> DeleteCategory(Guid id);
    }
}
