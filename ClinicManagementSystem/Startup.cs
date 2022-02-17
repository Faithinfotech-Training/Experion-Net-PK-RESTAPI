using ClinicManagementSystem.Models;
using ClinicManagementSystem.Repository;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicManagementSystem
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
            services.AddControllers();

            services.AddDbContext<clinicalmanagementsystemContext>(db =>
             db.UseSqlServer(Configuration.GetConnectionString("CmsDBConnection")));

            services.AddScoped<IDoctorRepo, DoctorRepo>(); 
            services.AddScoped<IAppointmentRepo, AppointmentRepo>();
            services.AddScoped<IUsersRepo, UsersRepo>();
            services.AddScoped<IRoleRepo, RoleRepo>();
            services.AddScoped<IPatientsRepo, PatientsRepo>();
            services.AddScoped<IMedicineRepo, MedicineRepo>();
            services.AddScoped<ITestPrescriptionRepo, TestPrescriptionRepo>();
            services.AddScoped<ITestRepo, TestRepo>();
            services.AddScoped<ITestReportRepo, TestReportRepo>();
            services.AddScoped<ITestPriceRepo, TestPriceRepo>();
            services.AddScoped<IMedicinePrescriptionRepo, MedicinePrescriptionRepo>();
            services.AddScoped<IMedicineItemPriceRepo, MedicineItemPriceRepo>();
            services.AddScoped<ISpecializationRepo, SpecializationRepo>();
            services.AddScoped<IMedicineListRepo, MedicineListRepo>();
            services.AddScoped<IGeneralNotesRepo, GeneralNotesRepo>();




            //adding services
            services.AddControllers().AddNewtonsoftJson(
                options => {
                    options.SerializerSettings
                    .ContractResolver = new DefaultContractResolver();
                }
                );

            services
                .AddControllers().AddNewtonsoftJson(
                options =>
                {
                    options.SerializerSettings.ReferenceLoopHandling =
                    Newtonsoft.Json.ReferenceLoopHandling.Ignore;
                });


            //JWT Authentication
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
            .AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    ValidIssuer = Configuration["Jwt:Issuer"],
                    ValidAudience = Configuration["Jwt:Issuer"],
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration["Jwt:Key"]))
                };
            });



            services.AddCors();

        }













        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {

            app.UseCors(option =>
            option.AllowAnyOrigin()
            .AllowAnyMethod()
            .AllowAnyHeader()
            );

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
