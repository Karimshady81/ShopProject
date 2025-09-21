using Microsoft.EntityFrameworkCore;

namespace ShopProject.Models
{
    public class PieRepository : IPieRepository
    {
        private readonly ShopProjectDbContext _shopProjectDbContext;

        public PieRepository(ShopProjectDbContext shopProjectDbContext)
        {
            _shopProjectDbContext = shopProjectDbContext;
        }

        public IEnumerable<Pie> AllPies
        {
            get
            {
                return _shopProjectDbContext.Pies.Include(c => c.Category);
            }
        }

        public IEnumerable<Pie> PiesOfTheWeek
        {
            get
            {
                return _shopProjectDbContext.Pies.Include(c => c.Category).Where(p => p.IsPieOfTheWeek);
            }
        }

        public Pie? GetPieById(int pieId)
        {
            return _shopProjectDbContext.Pies.FirstOrDefault(p => p.PieId == pieId);
        }
    }
}
