using Microsoft.Owin;
using Owin;
using TransportInitDB = Transport.Infrastructure.DatabaseInitialization;

[assembly: OwinStartupAttribute(typeof(Transport.Startup))]
namespace Transport
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            new TransportInitDB.Startup().ConfigureAuth(app);
        }
    }
}
