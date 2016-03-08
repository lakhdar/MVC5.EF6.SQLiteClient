using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(SQLiteClient.Startup))]
namespace SQLiteClient
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
