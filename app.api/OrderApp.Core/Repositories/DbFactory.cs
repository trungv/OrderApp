using OrderApp.Core.DatabaseContext;
using System;
using System.Collections.Generic;
using System.Text;

namespace OrderApp.Core.Repositories
{
    public class DbFactory : Disposable, IDbFactory
    {
        private OrderAppContext dbContext;

        public OrderAppContext Init()
        {
            return dbContext ?? (dbContext = new OrderAppContext());
        }

        protected override void DisposeCore()
        {
            if (dbContext != null)
                dbContext.Dispose();
        }
    }
}
