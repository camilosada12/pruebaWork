using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Entity.Model;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Entity.DTOs
{
    /// <summary>
    /// Perfil de AutoMapper que define los mapeos entre entidades del modelo y sus DTOs correspondientes.
    /// </summary>
    public class AutoMapperProfile : Profile
    {
        /// <summary>
        /// Inicializa una nueva instancia del perfil de AutoMapper y configura los mapeos.
        /// </summary>
        public AutoMapperProfile()
        {
            // Mapeo entre Form y FormDto
            CreateMap<Pizzas, PizzasDto>();
            CreateMap<PizzasDto, Pizzas>();


            // Mapeo entre Permission y PermissionDto
            CreateMap<Pedidos, PedidosDt>();
            CreateMap<PedidosDt, Pedidos>();

            // Mapeo entre rol y rolDto
            CreateMap<rol, rolDto>();
            CreateMap<rolDto, rol>();

            // Mapeo complejo entre RolFormPermission y RolFormPermissionDto con mapeos personalizados para nombres
            CreateMap<RolFormPermissions, RolFormPermissionDto>();
            CreateMap<RolFormPermissionDto, RolFormPermissions>();

            // Mapeo entre RolUser y RolUserDto con mapeos personalizados para nombres de usuario y rol
            CreateMap<RolUser, RolUserDto>();
            CreateMap<RolUserDto, RolUser>();

            // Mapeo entre User y UserDto
            CreateMap<User, UserDto>();
            CreateMap<UserDto, User>();
        }
    }
}
