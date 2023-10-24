using ChooseChase.Web.SpaHosting;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllers();
builder.Services.AddSpaStaticFiles(configuration => {
    configuration.RootPath = "WebApp/dist";
});

var app = builder.Build();

app.UseAuthorization();

app.MapControllers();
app.UseStaticWebApp();

app.Run();