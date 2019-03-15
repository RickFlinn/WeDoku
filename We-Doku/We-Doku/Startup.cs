using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using We_Doku.Data;
using We_Doku.Hubs;
using We_Doku.Models;
using We_Doku.Models.Handler;
using We_Doku.Models.Interfaces;
using We_Doku.Models.Services;

namespace We_Doku
{
    public class Startup
    {

        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration)
        {
            var builder = new ConfigurationBuilder().AddEnvironmentVariables();
            builder.AddUserSecrets<Startup>();
            Configuration = builder.Build();
        }
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();

            services.AddAuthorization(options =>
            {
                options.AddPolicy("NickNameOnly", policy => policy.Requirements.Add(new NickNameRequirement("true")));
                options.AddPolicy("MemberOnly", policy => policy.RequireRole(ApplicationRoles.Member));

            });
            // Adding Identity and user database Application User Db context
            services.AddIdentity<ApplicationUser, IdentityRole>()
                   .AddEntityFrameworkStores<ApplicationUserDbContext>()
                   .AddDefaultTokenProviders();

            // Add in the db context for identity user 
            services.AddSignalR();
            services.AddDbContext<SudokuDbContext>(options => options.UseSqlServer(Configuration["ConnectionStrings:DefaultConnection"]));
            services.AddDbContext<ApplicationUserDbContext>(options =>options.UseSqlServer(Configuration["ConnectionStrings:DefaultConnection"]));
            services.AddScoped<IGameBoard, GameBoardManager>();
            services.AddScoped<IGameSpace, GameSpaceManager>();
            services.AddScoped<IAuthorizationHandler, NickNameHandler>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
               app.UseDeveloperExceptionPage();
            }
            
            app.UseStaticFiles();

            app.UseAuthentication();
            app.UseMvc();

            app.UseSignalR(routes =>
            {
                routes.MapHub<ChatHub>("/chathub");
            });
            app.UseSignalR(routes =>
            {
                routes.MapHub<GameHub>("/gamehub");
            });
           
            app.UseMvc(route =>
            {
                route.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}"
                    );
            });
        }
    }
}
