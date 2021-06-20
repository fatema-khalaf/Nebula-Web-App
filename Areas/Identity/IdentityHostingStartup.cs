using System;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Nebula.Areas.Identity.Data;
using Nebula.Data;

[assembly: HostingStartup(typeof(Nebula.Areas.Identity.IdentityHostingStartup))]
namespace Nebula.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) => {
                services.AddDbContext<NebulaContext>(options =>
                    options.UseSqlServer(
                        context.Configuration.GetConnectionString("NebulaContextConnection")));

                services.AddDefaultIdentity<NebulaUser>(options => options.SignIn.RequireConfirmedAccount = true)
                    .AddEntityFrameworkStores<NebulaContext>();
                services.ConfigureApplicationCookie(options =>
                {
                    options.LoginPath = $"/register/login";
                    options.LogoutPath = $"/register/logout";
                    options.AccessDeniedPath = $"/register/login";
                });
            });
        }
    }
}