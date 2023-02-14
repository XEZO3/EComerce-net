

using Domain.IRepository;
using Domain.IService;
using EC.DAL.Repository;
using EC.Service.Service;

namespace EComerce.Common.Extention
{
    public static class IoExtention
    {
        public static IServiceCollection RegisterServices(this WebApplicationBuilder builder)
        {
            builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();  
            builder.Services.AddScoped<IUserRepository, UserRepository>();
            builder.Services.AddScoped<ITokenService, TokenService>();
            builder.Services.AddScoped<IUserService, UserService>();
            builder.Services.AddScoped<IPermessionRepository, PermessionRepository>();
            builder.Services.AddScoped<IRoleRepository, RoleRepository>();
            builder.Services.AddScoped<IRolePermessionRepository, RolePermessionRepository>();
            builder.Services.AddScoped<IRoleService, RoleService>();
            builder.Services.AddScoped<IPermessionService, PermessionService>();

            return builder.Services;
        }
    }
}
