using BulkBookOutlet.DataAccess.Data.Repository.IRepository;
using BulkBookOutlet.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BulkBookOutlet.DataAccess.Data.Repository
{
    class ShoppingCartRepository: Repository<ShoppingCart>, IShoppingCartRepository
    {
        private readonly ApplicationDbContext _db;

        public ShoppingCartRepository(ApplicationDbContext db): base(db)
        {
            _db = db;
        }

        public void Update(ShoppingCart obj)
        {
            _db.Update(obj);

        }
    }
}
