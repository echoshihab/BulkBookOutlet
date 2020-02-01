using BulkBookOutlet.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace BulkBookOutlet.DataAccess.Data.Repository.IRepository
{
    public interface ICoverTypeRepository: IRepository<CoverType>
    {
        public void Update(CoverType coverType);
    }
}
