using System.Text.Json.Serialization;
using Business.Services;
using Data.Interfaces;
using Data.Repository;
using Data.Services;
using Entity.DTOs;
using Entity.Model;

namespace Web.Service_Extensions
{
    public static class ServicesDependency
    {
        public static IServiceCollection AddProjectDependencies(this IServiceCollection services)
        {
            // Repositorio genérico
            services.AddScoped(typeof(IBaseModelData<,>), typeof(BaseModelData<,>));

            // Servicios genéricos
            services.AddScoped(typeof(IBaseModelBusiness<Pizzas,PizzasDto>), typeof(BaseModelBusiness<Pizzas, PizzasDto>));
            services.AddScoped(typeof(IBaseModelBusiness<User,UserDto>), typeof(BaseModelBusiness<User, UserDto>));
            services.AddScoped(typeof(IBaseModelBusiness<RolUser, RolUserDto>), typeof(BaseModelBusiness<RolUser,RolUserDto>));
            services.AddScoped(typeof(IBaseModelBusiness<rol,rolDto>), typeof(BaseModelBusiness<rol, rolDto>));
            services.AddScoped(typeof(IBaseModelBusiness<Pedidos,PedidosDt>), typeof(BaseModelBusiness<Pedidos, PedidosDt>));
            services.AddScoped(typeof(IBaseModelBusiness<RolFormPermissions,RolFormPermissionDto>), typeof(BaseModelBusiness<RolFormPermissions, RolFormPermissionDto>));

            // Configuración para controlar la serialización JSON con conversión de enums a string
            services.AddControllers().AddJsonOptions(options =>
            {
                options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
            });

            return services;
        }
    }
}
