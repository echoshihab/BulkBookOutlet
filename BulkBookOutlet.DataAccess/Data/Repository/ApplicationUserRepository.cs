using BulkBookOutlet.DataAccess.Data.Repository.IRepository;
using BulkBookOutlet.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BulkBookOutlet.DataAccess.Data.Repository
{
    class ApplicationUserRepository : Repository<ApplicationUser>, IApplicationUserRepository
    {
        private readonly ApplicationDbContext _db;

        public ApplicationUserRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        
    }
}
