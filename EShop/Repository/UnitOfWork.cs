using EShop.Data;

namespace EShop.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _db;

        public UnitOfWork(ApplicationDbContext db)
        {
            _db = db;
        }
        public void SaveChanges()
        {
            _db.SaveChanges();
        }
    }
}
