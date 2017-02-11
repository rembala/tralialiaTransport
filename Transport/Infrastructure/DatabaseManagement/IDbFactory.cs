using System;
using Transport.Infrastructure.DatabaseContext;

namespace Transport.Infrastructure.DatabaseManagement
{
    public interface IDbFactory : IDisposable
    {
        ApplicationDbContext Init();
    }
}
