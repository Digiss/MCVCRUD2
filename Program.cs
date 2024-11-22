using MCVCRUD2.Data;
using MCVCRUD2.Repositorio;
using Microsoft.EntityFrameworkCore;

internal class Program
{
    private static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        builder.Services.AddControllersWithViews();
        string connectionString = builder.Configuration.GetConnectionString("DataBase");
        builder.Services.AddDbContext<BancoContext>(options => options.UseSqlServer(connectionString));
        builder.Services.AddScoped<IContatoRepositorio, ContatoRepositorio>();
        var app = builder.Build();

        if (!app.Environment.IsDevelopment())
        {
            app.UseExceptionHandler("/Home/Error");
        }

        app.UseStaticFiles();
        app.UseRouting();
        app.UseAuthorization();

        app.MapControllerRoute(
            name: "default",
            pattern: "{controller=Home}/{action=Index}/{id?}");

        app.Run();
    }
}
