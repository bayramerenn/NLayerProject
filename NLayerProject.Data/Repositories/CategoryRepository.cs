using Microsoft.EntityFrameworkCore;
using NLayerProject.Core.Repositories;
using NLayerProject.Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace NLayerProject.Data.Repositories
{
    public class CategoryRepository : Repository<Category>, ICategoryRepository
    {

        public AppDbContext _appDbContext { get => _context as AppDbContext; }
        public CategoryRepository(AppDbContext dbContext) : base(dbContext)
        {

        }
        public async Task<Category> GetWithProductsByIdAsync(int categoryId)
        {
            return await _appDbContext.Categories.Include(x => x.Products).FirstOrDefaultAsync(x => x.Id == categoryId);
        }
    }
}
