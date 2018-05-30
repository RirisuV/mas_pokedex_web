using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(pokemonWebProject.Startup))]
namespace pokemonWebProject
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
