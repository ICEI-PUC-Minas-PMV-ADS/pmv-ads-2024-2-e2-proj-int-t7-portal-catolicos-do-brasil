using Hangfire;
using Hangfire.SqlServer;
using Microsoft.EntityFrameworkCore;
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

            //builder.Services.AddDbContext<AppDbContext>(options =>
            //    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

            builder.Services.AddDbContext<AppDbContext>(options =>
            options.UseSqlServer("Server=PH-WIN11-DELL;Database=portalcatolico;User Id=PH-WIN11-DELL\\Paulo;Password=123456;TrustServerCertificate=True;Trusted_Connection=True"
            , sqlOptions =>
            {
                sqlOptions.EnableRetryOnFailure();
            }));

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

            //app.UseHangfireDashboard("/hangfire");

            //RecurringJob.AddOrUpdate("job-daily-youtube", () => Console.WriteLine("Buscando v�deo do YouTube..."), Cron.Daily);

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }

}
