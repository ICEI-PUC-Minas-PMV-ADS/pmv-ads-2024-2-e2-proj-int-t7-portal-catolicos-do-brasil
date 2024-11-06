using Hangfire;
using Hangfire.SqlServer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using PortalCatolicoBrasil.Interfaces;
using PortalCatolicoBrasil.Service;

namespace PortalCatolicoBrasil
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddControllersWithViews();
            builder.Services.AddRazorPages().AddRazorRuntimeCompilation();

            builder.Services.AddHttpClient<ILiturgiaService, LiturgiaService>();

            builder.Services.AddDbContext<AppDbContext>(options =>
            options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"), sqlOptions =>
            {
                sqlOptions.EnableRetryOnFailure();
            }));


            var app = builder.Build();

            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}

//builder.Services.AddDbContext<AppDbContext>(options =>
//    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));


//app.UseHangfireDashboard("/hangfire");

//RecurringJob.AddOrUpdate("job-daily-youtube", () => Console.WriteLine("Buscando v�deo do YouTube..."), Cron.Daily);


//builder.Services.AddHangfire(configuration =>
//    configuration.SetDataCompatibilityLevel(CompatibilityLevel.Version_170)
//                 .UseSimpleAssemblyNameTypeSerializer()
//                 .UseRecommendedSerializerSettings()
//                 .UseSqlServerStorage(builder.Configuration.GetConnectionString("DefaultConnection"),
//                     new Hangfire.SqlServer.SqlServerStorageOptions
//                     {
//                         CommandBatchMaxTimeout = TimeSpan.FromMinutes(5),
//                         SlidingInvisibilityTimeout = TimeSpan.FromMinutes(5),
//                         QueuePollInterval = TimeSpan.Zero,
//                         UseRecommendedIsolationLevel = true,
//                         DisableGlobalLocks = true
//                     }));

//builder.Services.AddHangfireServer();