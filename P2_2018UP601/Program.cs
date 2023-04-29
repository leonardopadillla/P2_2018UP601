using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using P2_2018UP601;

var builder = WebApplication.CreateBuilder(args);

// Registra el contexto ApplicationDbContext con la cadena de conexi�n "DefaultConnection" del archivo appsettings.json
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("CovidCaseDbConnection")));

// Registra otros servicios aqu�, como servicios de identidad, middleware, etc.
// Por ejemplo: builder.Services.AddIdentity, builder.Services.AddControllersWithViews(), etc.

builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configura el middleware y la canalizaci�n de la aplicaci�n aqu�.
// Por ejemplo: app.UseStaticFiles(), app.UseAuthentication(), app.UseAuthorization(), etc.

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=CovidCases}/{action=Index}/{id?}");
app.Run();