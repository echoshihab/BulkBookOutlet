using BulkBookOutlet.DataAccess.Data.Repository.IRepository;
using BulkBookOutlet.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BulkBookOutlet.DataAccess.Data.Repository
{
    class OrderHeaderRepository : Repository<OrderHeader>, IOrderHeaderRepository
    {
        private readonly ApplicationDbContext _db;

        public OrderHeaderRepository(ApplicationDbContext db): base(db)
        {
            _db = db;
        }

        public void Update(OrderHeader obj)
        {
            _db.Update(obj);

        }
    }
}
