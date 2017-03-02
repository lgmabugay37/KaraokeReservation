using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(KaraokeReservation.Startup))]
namespace KaraokeReservation
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
