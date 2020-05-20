using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(BookStoreWeb.Startup))]
namespace BookStoreWeb
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
            CreateContainer();
        }
    }
}
