using Book_Store.Models.Domain;
using Book_Store.Repositories.Abstract;
using Book_Store.Repositories.Implementation;
using Microsoft.EntityFrameworkCore;

namespace Book_Store
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();
            //add services
            builder.Services.AddScoped<IGenreService, GenreService>();
            //connection to database 
            builder.Services.AddDbContext<BookStoreContext>(options =>
                options.UseSqlServer(builder.Configuration.GetConnectionString("con")));
            var app = builder.Build();
          

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Genre}/{action=Add}/{id?}");

            app.Run();
        }
    }
}
 