using Data_Tier.GenericRepository;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using Autofac;
using Data_Tier.UnitOfWork;
using ApiNoNODOCO.Service.IService;
using ApiNoNODOCO.Service;
using Data_Tier.ConfigurationExtension;
using System.IO;
using FirebaseAdmin;
using Google.Apis.Auth.OAuth2;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Microsoft.Extensions.Hosting.Internal;
using System;
using System.Text;

namespace ApiNoNODOCO
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
            #region Repositories
            services.AddTransient(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            /*services.AddTransient<IConditionRepository, ConditionRepository>();*/
            // add new repository in here
            #endregion

            #region FireBase
            var pathToKey = Path.Combine(Directory.GetCurrentDirectory(), "keys", "firebase_admin_sdk.json");

            /*if (HostEnvironmentEnvExtensions.IsEnvironment("local"))
                pathToKey = Path.Combine(Directory.GetCurrentDirectory(), "keys", "firebase_admin_sdk.local.json");*/
             
            FirebaseApp.Create(new AppOptions
            {
                Credential = GoogleCredential.FromFile(pathToKey)
            });
            #endregion

            #region Authentication
            /*services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options =>
                {
                    var firebaseProjectName = Configuration["FirebaseProjectName"];
                    options.Authority = "https://securetoken.google.com/" + firebaseProjectName;
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuer = true,    
                        ValidateAudience = true,
                        ValidAudience = firebaseProjectName,
                        ValidIssuer = "https://securetoken.google.com/" + firebaseProjectName,
                        ValidateLifetime = true
                    };
                });*/
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options =>
                {
                    options.RequireHttpsMetadata = false;
                    options.SaveToken = true;
                    options.TokenValidationParameters = new TokenValidationParameters
                    {      
                        ValidateIssuerSigningKey = true,
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Settings.Secret)),
                        ValidateIssuer = false,
                        ValidateAudience = false
                    };
                });
            #endregion


            services.AddControllers();

            #region Swagger
            services.AddSwaggerGen(s => {
                s.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = "v1",
                    Title = "NoNODOCO API",
                    Description = "NoNODOCO API",
                    Contact = new OpenApiContact
                    {
                        Name = "NoNODOCO Team",
                        Email = "test@localhost.com",
                    },
                });
                s.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    Description = "JWT Authorization header using the Bearer scheme (Example: 'Bearer 12345abcdef')",
                    Name = "Authorization",
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.ApiKey,
                    Scheme = "Bearer"
                });
                s.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference
                            {
                                Type = ReferenceType.SecurityScheme,
                                Id = "Bearer"
                            }
                        },
                        Array.Empty<string>()
                    }
                });
            });
            #endregion

            services.AddMonitoringServicesDBConfiguration(Configuration);


            #region Add framework services
            // Add framework services
            services.AddMvc();
            services.AddScoped<IAdminService, AdminService>();
            services.AddScoped<IBonusService, BonusService>();
            services.AddScoped<IBookingService, BookingService>();
            services.AddScoped<ICustomerService, CustomerService>();
            services.AddScoped<IDriverService, DriverService>();
            services.AddScoped<IDriverAvaiabilityService, DriverAvaiabilityService>();
            services.AddScoped<IDriverHaveBonusService, DriverHaveBonusService>();
            services.AddScoped<ITransactionWalletService, TransactionWalletService>();
            services.AddScoped<IVehicleService, VehicleService>();
            services.AddScoped<IWalletService, WalletService>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            //add custom framework services      
            #endregion
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void ConfigureContainer(ContainerBuilder builder)
        {
            builder.RegisterType<UnitOfWork>().As<IUnitOfWork>();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseSwagger(c =>
            {
                c.SerializeAsV2 = true;
            });
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "NoNODOCO v1");
                c.RoutePrefix = string.Empty;
            });
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            
            app.UseHttpsRedirection();
            app.UseCors(x => x
                .AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader());
            app.UseAuthentication();

            app.UseRouting();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
