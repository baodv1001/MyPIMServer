using AttributeService.Core.Interfaces.Repositories;
using AttributeService.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AttributeService.Infrastructure.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        public Task<Category> CreateCategory(Category category)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteCategory(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Category>> GetAllCategories()
        {
            throw new NotImplementedException();
        }

        public Task<Category> GetCategoryById(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<object> UpdateCategory(Category category, Guid id)
        {
            throw new NotImplementedException();
        }
    }
}
