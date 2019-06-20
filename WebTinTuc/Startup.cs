using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(WebTinTuc.Startup))]
namespace WebTinTuc
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
