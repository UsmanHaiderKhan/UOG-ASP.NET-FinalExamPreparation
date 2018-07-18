using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ValidationAuthenticationForFinalExam.Startup))]
namespace ValidationAuthenticationForFinalExam
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
