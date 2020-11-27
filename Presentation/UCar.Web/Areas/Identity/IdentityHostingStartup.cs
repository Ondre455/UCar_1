using System;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using UCar.Web.Areas.Identity.Data;
using UCar.Web.Data;

[assembly: HostingStartup(typeof(UCar.Web.Areas.Identity.IdentityHostingStartup))]
namespace UCar.Web.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) => {
                services.AddDbContext<AuthUsersDbContext>(options =>
                    options.UseSqlServer(
                        context.Configuration.GetConnectionString("AuthUsersDbContextConnection")));

                services.AddDefaultIdentity<AuthUser>(options =>
                {
                    options.SignIn.RequireConfirmedAccount = false;
                    options.Password.RequireLowercase = false;
                    options.Password.RequireUppercase = false;
                })
                    .AddEntityFrameworkStores<AuthUsersDbContext>();
            });
        }
    }
}