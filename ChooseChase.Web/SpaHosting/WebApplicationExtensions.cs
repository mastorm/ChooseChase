namespace ChooseChase.Web.SpaHosting;

public static class WebApplicationExtensions
{
    public static void UseStaticWebApp(this WebApplication app)
    {
        const string spaPath = "";
        app.Map(
            new PathString(spaPath),
            client =>
            {
                
                client.UseSpa(spa =>
                {
                    if (app.Environment.IsDevelopment())
                    {
                        // TODO: Refactor this into configurations
                        spa.UseProxyToSpaDevelopmentServer("http://localhost:5173");
                    }
                    else
                    {
                        client.UseSpaStaticFiles();
                        client.UseSpa(spa => { spa.Options.SourcePath = "WebApp"; });
                    }
                });
            });
    }
}