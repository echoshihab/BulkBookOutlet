using BulkBookOutlet.DataAccess.Data.Repository.IRepository;
using BulkBookOutlet.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BulkBookOutlet.DataAccess.Data.Repository
{
    class OrderDetailsRepository: Repository<OrderDetails>, IOrderDetailsRepository
    {
        private readonly ApplicationDbContext _db;

        public OrderDetailsRepository(ApplicationDbContext db): base(db)
        {
            _db = db;
        }

        public void Update(OrderDetails obj)
        {
            _db.Update(obj);
           
        }
    }
}
