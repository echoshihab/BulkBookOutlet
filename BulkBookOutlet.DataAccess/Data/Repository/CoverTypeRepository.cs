﻿using BulkBookOutlet.DataAccess.Data.Repository.IRepository;
using BulkBookOutlet.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BulkBookOutlet.DataAccess.Data.Repository
{
    public class CoverTypeRepository: Repository<CoverType>, ICoverTypeRepository
    {
        private readonly ApplicationDbContext _db;
        
        public CoverTypeRepository(ApplicationDbContext db): base(db)
        {
            _db = db;
        }

        public void Update(CoverType coverType)
        {
            var objFromDb = _db.CoverTypes.FirstOrDefault(s => s.Id == coverType.Id);

            if(objFromDb != null)
            {
                objFromDb.Name = coverType.Name;
            }
        }
    }
}
