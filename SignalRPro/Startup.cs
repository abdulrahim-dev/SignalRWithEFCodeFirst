using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(SignalRPro.Startup))]
namespace SignalRPro
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            app.MapSignalR();
            ConfigureAuth(app);
        }
    }
}
