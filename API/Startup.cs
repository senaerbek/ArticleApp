using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using API.Utilities;
using Application.Articles;
using Domain;
using MediatR;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using Persistence;

namespace API
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            services.AddDbContext<ArticleContext>(options =>
            {
                options.UseSqlServer(@"Server=DESKTOP-E1T0HQ2; initial catalog=ArticleApp; integrated security=true");
            });
            services.AddMediatR(typeof(List.Handler).Assembly);
            services.AddIdentityCore<User>(opt =>
            {
                opt.Password.RequireDigit = false;
                opt.Password.RequireLowercase = false;
                opt.Password.RequireNonAlphanumeric = false;
                opt.Password.RequireUppercase = false;
                opt.Password.RequiredLength = 4;
            }).AddEntityFrameworkStores<ArticleContext>().AddSignInManager<SignInManager<User>>();

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("secret key secret key"));
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
            .AddJwtBearer(option =>
            {
                option.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = key,
                    ValidateIssuer = false,
                    ValidateAudience = false
                };
            });
            services.AddScoped<TokenHelper>();
            services.AddCors(options =>
        {
            options.AddPolicy("AllowOrigin", builder => builder.WithOrigins("http://localhost:3000").AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin());
        });

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseCors(builder => builder.WithOrigins("http://localhost:3000").AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin() /*get, post, put, delete, patch... izin ver*/);

            app.UseHttpsRedirection();

            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
