using System;
using Transport.Initialization.DatabaseContext;

namespace Transport.Initialization.DatabaseManagement
{
    public interface IDbFactory : IDisposable
    {
        ApplicationDbContext Init();
    }
}
