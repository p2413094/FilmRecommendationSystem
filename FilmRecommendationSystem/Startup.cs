using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(FilmRecommendationSystem.Startup))]
namespace FilmRecommendationSystem
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
