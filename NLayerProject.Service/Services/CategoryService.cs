using NLayerProject.Core.Repositories;
using NLayerProject.Core.Service;
using NLayerProject.Core.UnitOfWorks;
using NLayerProject.Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace NLayerProject.Service.Services
{
    public class CategoryService : Service<Category>,ICategoryService
    {
        public CategoryService(IUnitOfWork unitOfWork,IRepository<Category> repository):base(unitOfWork,repository)
        {

        }

        public Task<Category> GetWithProductsByIdAsync(int categoryId)
        {
            return _unitOfWork.Categories.GetWithProductsByIdAsync(categoryId);
        }

    }
}
