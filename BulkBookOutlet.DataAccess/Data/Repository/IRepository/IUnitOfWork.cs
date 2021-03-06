﻿using System;
using System.Collections.Generic;
using System.Text;

namespace BulkBookOutlet.DataAccess.Data.Repository.IRepository
{
    public interface IUnitOfWork: IDisposable
    {
        ICategoryRepository Category { get; }

        ICoverTypeRepository CoverType { get; }
        IProductRepository Product { get; }
        ICompanyRepository Company { get; }
        IApplicationUserRepository User { get; }

        IShoppingCartRepository ShoppingCart { get; }

        IOrderDetailsRepository OrderDetails { get; }

        IOrderHeaderRepository OrderHeader { get; }
        ISP_Call SP_Call { get; }

        void Save();
    }
}
