using System;
using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Web_API.Authorization.Handlers;
using Web_API.Authorization.Requirements;
using Web_API.Data;
using Web_API.Helpers;
using Web_API.Middleware;
using Web_API.Services;

namespace Web_API
{
    public class Startup
    {
        private readonly IWebHostEnvironment _env;

        public Startup(IConfiguration configuration, IWebHostEnvironment env)
        {
            Configuration = configuration;
            _env = env;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            if (_env.IsProduction())
                services.AddDbContext<AppDbContext>();
            else
                services.AddDbContext<AppDbContext, SqliteAppDbContext>();

            services.AddCors();
            services.AddControllers().AddJsonOptions(x => x.JsonSerializerOptions.IgnoreNullValues = true);
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
            //services.AddSwaggerGen();
            // services.AddSwaggerGen(c =>
            // {
            //     c.SwaggerDoc("v1", new OpenApiInfo {Title = "Web API", Version = "v1"});
            //     c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
            //     {
            //         In = ParameterLocation.Header,
            //         Description = "Please enter JWT with Bearer into field",
            //         Name = "Authorization",
            //         Type = SecuritySchemeType.ApiKey
            //     });
            //     c.AddSecurityRequirement(new OpenApiSecurityRequirement
            //     {
            //         {
            //             new OpenApiSecurityScheme
            //             {
            //                 Reference = new OpenApiReference {Type = ReferenceType.SecurityScheme, Id = "Bearer"}
            //             },
            //             Array.Empty<string>()
            //         }
            //     });
            // });
            
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Web API", Version = "v1" });

                c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    Type = SecuritySchemeType.Http,
                    BearerFormat = "JWT",
                    In = ParameterLocation.Header,
                    Scheme = "bearer",
                    Description = "Please insert JWT token into field"
                });

                c.AddSecurityRequirement(new OpenApiSecurityRequirement
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

            // configure strongly typed settings objects
            var appSettingsSection = Configuration.GetSection("AppSettings");
            services.Configure<AppSettings>(appSettingsSection);


            var tokenValidationParameters = new TokenValidationParameters
            {
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(Configuration["AppSettings:Secret"])),
                ValidateIssuer = false,
                ValidateAudience = false,
                ClockSkew = TimeSpan.Zero
            };

            services
                .AddAuthentication(options => { options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme; })
                .AddJwtBearer(cfg => { cfg.TokenValidationParameters = tokenValidationParameters; });


            services.AddAuthorization(cfg =>
            {
                cfg.AddPolicy("Admin", policy => policy.RequireClaim("UserType", "Admin"));
                cfg.AddPolicy("LoggedIn", policy => policy.RequireClaim("Id"));
                cfg.AddPolicy("SubClubMember", policy=> policy.Requirements.Add(new SubClubMemberRequirement()));
                cfg.AddPolicy("SelfOrAdmin", policy => policy.Requirements.Add(new SelfOrAdminRequirement()));
                cfg.AddPolicy("SubClubAdmin", policy => policy.Requirements.Add(new SubClubAdminRequirement()));
            });

            services.AddTransient<IAuthorizationHandler, SubClubAdminHandler>();
            services.AddTransient<IAuthorizationHandler, SelfHandler>();
            services.AddTransient<IAuthorizationHandler, AdminHandler>();

            // configure DI for application services
            // TODO: why don't we add 'em as Singleton?
            services.AddScoped<IClubService, ClubService>();
            services.AddScoped<ICommentService, CommentService>();
            services.AddScoped<IEmailService, EmailService>();
            services.AddScoped<IOfflineEventService, OfflineEventService>();
            services.AddScoped<IOnlineEventService, OnlineEventService>();
            services.AddScoped<IPostService, PostService>();
            services.AddScoped<IQuestionService, QuestionService>();
            services.AddScoped<IReportService, ReportService>();
            services.AddScoped<IReviewAndRateService, ReviewAndRateService>();
            services.AddScoped<ISubClubService, SubClubService>();
            services.AddScoped<ISubClubUserService, SubClubUserService>();
            services.AddScoped<IUserService, UserService>();
            // TODO: add services.
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, AppDbContext appDbContext)
        {
            appDbContext.Database.Migrate();

            app.UseSwagger();
            app.UseSwaggerUI(x =>
            {
                x.SwaggerEndpoint("/swagger/v1/swagger.json", "Social Interest e-Club Web API");
                x.RoutePrefix = string.Empty;
            });
            app.UseRouting();

            app.UseCors(x => x
                .SetIsOriginAllowed(origin => true)
                .AllowAnyHeader()
                .AllowAnyMethod()
                .AllowAnyHeader()
            );

            app.UseMiddleware<ErrorHandlerMiddleware>();
            app.UseAuthentication();
            app.UseAuthorization();
            app.UseEndpoints(endpoints => endpoints.MapControllers());
        }
    }
}