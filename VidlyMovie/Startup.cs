using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(VidlyMovie.Startup))]
namespace VidlyMovie
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
