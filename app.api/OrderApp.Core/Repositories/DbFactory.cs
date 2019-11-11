using Microsoft.EntityFrameworkCore;
using OrderApp.Core.DatabaseContext;

namespace OrderApp.Core.Repositories
{
    public class DbFactory : Disposable, IDbFactory
    {
        private OrderAppContext dbContext;

        public OrderAppContext Init()
        {
            return dbContext ?? (dbContext = new OrderAppContext(new DbContextOptions<OrderAppContext>()));
        }

        protected override void DisposeCore()
        {
            if (dbContext != null)
                dbContext.Dispose();
        }
    }
}
