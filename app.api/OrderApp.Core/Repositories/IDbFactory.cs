using OrderApp.Core.DatabaseContext;
using System;
using System.Collections.Generic;
using System.Text;

namespace OrderApp.Core.Repositories
{
    public interface IDbFactory : IDisposable
    {
        OrderAppContext Init();
    }
}
