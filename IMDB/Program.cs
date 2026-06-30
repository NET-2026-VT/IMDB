using IMDB.Models.Entities;
using Microsoft.EntityFrameworkCore;

internal class Program
{
    private static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.
        var connectionString = builder.Configuration.GetConnectionString("IMDBContext") ?? throw new InvalidOperationException("Connection string 'IMDBContext' not found.");
        builder.Services.AddDbContext<IMDBContext>(options => options.UseSqlServer(connectionString));

        builder.Services.AddControllersWithViews();

        var app = builder.Build();





        // Configure the HTTP request pipeline.
        if (!app.Environment.IsDevelopment())
        {
            app.UseExceptionHandler("/Home/Error");
            // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
            app.UseHsts();
        }

        app.UseHttpsRedirection();
        app.UseRouting();

        app.UseAuthorization();

        app.MapStaticAssets();

        app.MapControllerRoute(
            name: "default",
            pattern: "{controller=Movies}/{action=Index}/{id?}")
            .WithStaticAssets();


        app.Run();

    }
}