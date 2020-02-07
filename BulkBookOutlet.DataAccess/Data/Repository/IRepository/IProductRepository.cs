﻿using BulkBookOutlet.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace BulkBookOutlet.DataAccess.Data.Repository.IRepository
{
    public interface IProductRepository: IRepository<Product>
    {
        void Update(Product product);

    }
}