using DataAccessLayer.Contrete.Context;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPILayer
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

            services.AddDbContext<MyContext>();
            services.AddIdentity<AppUser, AppRole>(x =>
            {
                x.User.RequireUniqueEmail = true; //emailin uniq olmasi

            })
                .AddEntityFrameworkStores<MyContext>();


            services.Register();

            //services.ConfigureApplicationCookie(_ =>
            //{
            //    _.LoginPath = new PathString("/Account/Login");
            //    _.LogoutPath = new PathString("/Account/LogOut");
            //    _.Cookie = new CookieBuilder
            //    {
            //        Name = "AspNetCoreIdentityExampleCookie", //Olusturulacak Cookie'yi isimlendiriyoruz.
            //        HttpOnly = false, //Kotu niyetli insanlarin client-side tarafindan Cookie'ye erismesini engelliyoruz.
            //                          //Expiration = TimeSpan.FromMinutes(180), //Olusturulacak Cookie'nin vadesini belirliyoruz.
            //        SameSite = SameSiteMode.Lax, //Top level navigasyonlara sebep olmayan requestlere Cookie'nin gonderilmemesini belirtiyoruz.
            //        SecurePolicy = CookieSecurePolicy.Always //HTTPS uzerinden erisilebilir yapiyoruz.
            //    };
            //    _.SlidingExpiration = true; //Expiration suresinin yarisi kadar sure zarfinda istekte bulunulursa eğer geri kalan yarisini tekrar sifirlayarak ilk ayarlanan sureyi tazeleyecektir.
            //    _.ExpireTimeSpan = TimeSpan.FromMinutes(120); //CookieBuilder nesnesinde tanimlanan Expiration degerinin varsayilan degerlerle ezilme ihtimaline karsin tekrardan Cookie vadesi burada da belirtiliyor.
            //});

            //services.AddAuthentication(x => {
            //    x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
            //    x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            //}).AddJwtBearer(o => {
            //    o.RequireHttpsMetadata = false;
            //    o.SaveToken = true;
            //    o.TokenValidationParameters = new TokenValidationParameters
            //    {
            //        //ValidIssuer = "http://localhost",
            //        //ValidAudience = "http://localhost",
            //        ValidateIssuer = false, // kim terefinden yaradildi
            //        ValidateAudience = false, // kim terefinden ist edilecek
            //        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration["jwtSecret"])), //sifreleme ucun gizli acar
            //        ValidateIssuerSigningKey = true, //acarin islene bilmesi ucun 
            //        ValidateLifetime = true, //tokenin zaman boyunca aktiv qalmasi ucun
            //        ClockSkew = TimeSpan.Zero, //saat ferqi olmasin
            //    };
            //});

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "WebAPILayer", Version = "v1" });
            });

            //services.AddMvc(config =>
            //{
            //    var policy = new AuthorizationPolicyBuilder()
            //    .RequireAuthenticatedUser()
            //    .Build();

            //    config.Filters.Add(new AuthorizeFilter(policy));
            //}); // all controller check for login 

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "WebAPILayer v1"));
            }

            app.UseCors(o => o.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod());

            app.UseHttpsRedirection();

            app.UseRouting();

            //app.UseAuthentication();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
