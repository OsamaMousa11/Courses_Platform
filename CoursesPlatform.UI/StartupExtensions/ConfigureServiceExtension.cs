using CoursePlatform.Core.Domain.Entites;
using CoursePlatform.Core.Domain.IdentityEntites;
using CoursePlatform.Core.Domain.RepositoryContract;
using CoursePlatform.Core.Enum;
using CoursePlatform.Core.Service;
using CoursePlatform.Core.ServiceContract;
using CoursePlatform.Infrastructure.Data;
using CoursePlatform.Infrastructure.Repositories;
using CoursesPlatform.UI.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors.Infrastructure;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Net;

namespace CoursesPlatform.UI.StartupExtensions
{
    public static class ConfigureServiceExtension
    {
        public static IServiceCollection ServiceConfiguration(this IServiceCollection Services, IConfiguration configuration)
        {
            Services.AddDbContext<AppDbContext>(options =>
            {
                options.UseSqlServer(configuration.GetConnectionString("connstr"));
            });



            Services.AddControllersWithViews();

            Services.AddScoped<ICategoryService, CategoryService>();
            Services.AddScoped<ICategoryRepository, CategoryRepository>();


            Services.AddScoped<ICourseService, CourseService>();
            Services.AddScoped<ICourseRepository, CourseRepository>();


            Services.AddScoped< IFavouriteService, FavouriteService>();
            Services.AddScoped<IFavouriteRepository, FavouriteRepository>();

            Services.AddScoped<IUserService, UserService>();


            Services.AddScoped<IFileService, FileService>();

            Services.AddIdentity<ApplicationUser, ApplicationRole>()

                .AddEntityFrameworkStores<AppDbContext>().

                AddUserStore<UserStore<ApplicationUser, ApplicationRole, AppDbContext, Guid>>()

                .AddRoleStore<RoleStore<ApplicationRole, AppDbContext, Guid>>();

            Services.Configure<IdentityOptions>(options =>
            {
                options.SignIn.RequireConfirmedAccount = false;
                options.User.RequireUniqueEmail = true;

                options.Password.RequireDigit = false;
                options.Password.RequiredLength = 6;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireUppercase = false;
                options.Password.RequireLowercase = false;
            });

           Services.AddAuthorization(options =>
            {
                options.FallbackPolicy = new AuthorizationPolicyBuilder().RequireAuthenticatedUser().Build();
                 
                options.AddPolicy("NotAuthenticated", policy =>
                {
                    policy.RequireAssertion(context =>
                    {
                        return !context.User.Identity.IsAuthenticated;
                    });
                });
            });
            Services.ConfigureApplicationCookie(options =>
            {
                options.LoginPath = "/Account/Login";
            });

            return Services;
        }
    }
}
