
using HospitalAPI.Converters;
using HospitalAPI.DTO;
using HospitalAPI.Security;
using HospitalAPI.Security.Models;
using HospitalLibrary.Core.DomainService;
using HospitalLibrary.Core.Repository;
using HospitalLibrary.Core.Service;
using HospitalLibrary.Settings;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Text;
using System.Text.Json.Serialization;


namespace HospitalAPI
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();

            services.AddDbContext<HospitalDbContext>(options =>
            {
                options.UseNpgsql(Configuration.GetConnectionString("HospitalDB"));
                options.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
            });
            services.AddDbContext<AppIdentityDbContext>(options => options.UseNpgsql(Configuration.GetConnectionString("HospitalDB")));

            services.AddScoped(typeof(IFeedbackService), typeof(FeedbackService));
            services.AddScoped(typeof(IPatientService), typeof(PatientService));

            services.AddScoped(typeof(IFeedbackRepository), typeof(FeedbackRepository));
            services.AddScoped(typeof(IPatientRepository), typeof(PatientRepository));

            services.AddScoped(typeof(IAllergensRepository), typeof(AllergensRepository));
            services.AddScoped(typeof(IAllergenService), typeof(AllergenService));

            services.AddScoped(typeof(IAddressRepository), typeof(AddressRepository));
            services.AddScoped(typeof(IAddressService), typeof(AddressService));

            services.AddAutoMapper(typeof(MappingProfile));

            services.AddControllers()
                .AddJsonOptions(options =>
                {
                    options.JsonSerializerOptions.Converters.Add(new DateOnlyJsonConverter());
                    options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
                });

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "HospitalAPI", Version = "v1" });
            });

            services.AddScoped<IDoctorService, DoctorService>();
            services.AddScoped<IDoctorRepository, DoctorRepository>();
            services.AddScoped<IExaminationService, ExaminationService>();
            services.AddScoped<IExaminationRepository, ExaminationRepository>();
            services.AddScoped<IAppointmentRepository, AppointmentRepository>();
            services.AddScoped<IAppointmentService, AppointmentService>();
            services.AddScoped<AuthService>();
            services.AddScoped<DoctorScheduler>();
           
            services.AddCors(options =>
            {
                options.AddPolicy(name: "InternAllow",
                      policy =>
                      {
                          policy.WithOrigins("http://localhost:4200")
                          .AllowAnyHeader()
                          .AllowAnyMethod()
                          .WithExposedHeaders("content-disposition");
                      });
                options.AddPolicy(name: "PublicAllow",
                policy =>
                {
                    policy.AllowAnyOrigin()
                         .AllowAnyMethod()
                         .AllowAnyHeader()
                         .WithExposedHeaders("content-disposition");
                });
            });

            services.AddIdentity<User, IdentityRole<int>>(options =>
            {
                options.Password.RequireDigit = false;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequiredLength = 5;
                options.Password.RequireLowercase = false;
                options.Password.RequireUppercase = false;
                options.SignIn.RequireConfirmedEmail = false;
            })
                .AddEntityFrameworkStores<AppIdentityDbContext>()
                .AddDefaultTokenProviders();

            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(o =>
            {
                o.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidIssuer = Configuration["Jwt:ValidIssuer"],
                    //ValidAudience = Configuration["Jwt:Audience"],
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration["Jwt:Secret"])),
                    ValidateIssuer = true,
                    ValidateAudience = false,
                    ValidateLifetime = false,
                    ValidateIssuerSigningKey = true
                };
            });
            services.AddAuthentication();
            services.AddAuthorization();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "HospitalAPI v1"));
            }

            AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);

            app.UseRouting();

            app.UseCors("PublicAllow");
            app.UseCors("InternAllow");

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }

    }
}
