using System;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using RegisterToDoc.Areas.Identity.Data;
using RegisterToDoc.Data;

[assembly: HostingStartup(typeof(RegisterToDoc.Areas.Identity.IdentityHostingStartup))]
namespace RegisterToDoc.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) => {
                services.AddDbContext<RegisterToDocContext>(options =>
                    options.UseSqlite(
                        context.Configuration.GetConnectionString("RegisterToDocContextConnection")));

                services.AddDefaultIdentity<RegisterToDocUser>(options => options.SignIn.RequireConfirmedAccount = false)
                    .AddEntityFrameworkStores<RegisterToDocContext>();
            });
        }
    }
}