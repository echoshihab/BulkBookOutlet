using BulkBookOutlet.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace BulkBookOutlet.DataAccess.Data.Repository.IRepository
{
    interface ICategoryRepository: IRepository<Category>
    {
        void Update(Category category);

    }
}
