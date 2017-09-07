using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MVCDBFirst.Startup))]
namespace MVCDBFirst
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
