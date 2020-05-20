using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(BookStoreAdmin.Startup))]
namespace BookStoreAdmin
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
