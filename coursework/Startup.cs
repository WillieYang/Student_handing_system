using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(coursework.Startup))]
namespace coursework
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
