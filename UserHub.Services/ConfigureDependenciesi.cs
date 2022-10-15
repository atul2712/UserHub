using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using UserHub.DAL;
using UserHub.DAL.Entities;
using UserHub.Repositories.Implementations;
using UserHub.Repositories.Interfaces;
using UserHub.Services.Implementations;
using UserHub.Services.Interfaces;

namespace UserHub.Services
{
    public class ConfigureDependenciesi
    {
        public static void RegisterServices(IServiceCollection services, IConfiguration configuration)
        {
            //Database

            services.AddDbContext<AppDbContext>(options =>
            {
                options.UseSqlServer(configuration.GetConnectionString("DbConnection"));
            });
            services.AddScoped<DbContext, AppDbContext>();

            //repositories
            services.AddScoped<IRepository<User>, Repository<User>>();

            services.AddScoped<IUserRepository, UserRepository>();

            //services
            services.AddScoped<IAuthService, AuthService>();
        }
    }
}
