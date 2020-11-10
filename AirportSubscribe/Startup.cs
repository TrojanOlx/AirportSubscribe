using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using AntDesign.Pro.Layout;
using AirportSubscribe.Models;
using Microsoft.EntityFrameworkCore;
using MediatR;
using AutoMapper;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace AirportSubscribe
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {

            services.AddAutoMapper(typeof(Startup));
            services.AddMediatR(typeof(Startup));

            services.AddRazorPages();
            services.AddServerSideBlazor();
            services.AddAntDesign();
            services.AddScoped(sp => new HttpClient
            {
                BaseAddress = new Uri(sp.GetService<NavigationManager>().BaseUri)
            });
            services.Configure<ProSettings>(Configuration.GetSection("ProSettings"));

            var connectionString = Configuration.GetConnectionString("MysqlConnection");

            services.AddDbContext<AirportContext>(options => options.UseMySql(connectionString, builder =>
            {
                builder.EnableRetryOnFailure(5, TimeSpan.FromSeconds(10), null);
            }));


            //添加认证相关的服务
            AddAuthentication(services);


        }



        private void AddAuthentication(IServiceCollection services)
        {
            JwtSecurityTokenHandler.DefaultMapInboundClaims = false;

            services.AddAuthentication(options =>
            {
                options.DefaultScheme = "Cookies";
                options.DefaultChallengeScheme = "oidc";
            })
                .AddCookie("Cookies")
                .AddOpenIdConnect("oidc", options =>
                {
                    options.Authority = "https://localhost:5001";

                    options.ClientId = "AirportSubscribe";
                    options.ClientSecret = "secret";
                    options.ResponseType = "code";

                    options.SaveTokens = true;
                    options.GetClaimsFromUserInfoEndpoint = true;
                    options.Scope.Add("role");
                    options.Scope.Add("permission");
                    options.TokenValidationParameters.RoleClaimType = "role";
                    options.TokenValidationParameters.NameClaimType = "name";
                    options.Events.OnUserInformationReceived = (context) =>
                    {

                        ClaimsIdentity claimsId = context.Principal.Identity as ClaimsIdentity;

                        var roleElement = context.User.RootElement.GetProperty("role");
                        if (roleElement.ValueKind == System.Text.Json.JsonValueKind.Array)
                        {
                            var roles = context.User.RootElement.GetProperty("role").EnumerateArray().Select(e =>
                            {
                                return e.ToString();
                            });
                            claimsId.AddClaims(roles.Select(r => new Claim("role", r)));
                        }
                        else
                        {
                            claimsId.AddClaim(new Claim("role", roleElement.ToString()));
                        }

                        var permissionElement = context.User.RootElement.GetProperty("permission");
                        if (permissionElement.ValueKind == System.Text.Json.JsonValueKind.Array)
                        {
                            var permissions = permissionElement.EnumerateArray().Select(e =>
                            {
                                return e.ToString();
                            });
                            claimsId.AddClaims(permissions.Select(p => new Claim("permission", p)));
                        }
                        else
                        {
                            claimsId.AddClaim(new Claim("permission", permissionElement.ToString()));
                        }


                        return Task.CompletedTask;
                    };
                });

            services.AddAuthorizationCore(option =>
            {
                string[] permissions = new string[]
                {
                    "create",
                    "retrieve",
                    "update",
                    "delete"
                };
                foreach (var p in permissions)
                {
                    option.AddPolicy(p, policy =>
                    {
                        policy.RequireClaim("permission", new string[] { p });
                    });
                }
            });
        }


        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();


            app.UseEndpoints(endpoints =>
            {
                endpoints.MapBlazorHub();
                endpoints.MapControllerRoute("mvc", "{controller}/{action}");
                endpoints.MapFallbackToPage("/_Host");
            });
        }
    }
}
