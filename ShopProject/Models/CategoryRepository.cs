
namespace ShopProject.Models
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly ShopProjectDbContext _shopProjectDbContext;

        public CategoryRepository(ShopProjectDbContext shopProjectDbContext)
        {
            _shopProjectDbContext = shopProjectDbContext;
        }

        public IEnumerable<Category> AllCategories => _shopProjectDbContext.Categories.OrderBy(c => c.CategoryName);

    }
}
