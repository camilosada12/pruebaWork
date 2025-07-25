using Business.Services;
using Data.Services;
using Entity.DTOs;
using Entity.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers
{
    /// <summary>
    /// Controlador API para gestionar usuarios.
    /// Hereda de GenericController para operaciones CRUD estándar sobre UserDto.
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : GenericController<User, UserDto> // <-- heredás del controller base
    {
        private readonly UserRepository _extendedService;

        public UserController(IBaseModelBusiness<User, UserDto> service, UserRepository extendedService
        ) : base(service)
        {
            _extendedService = extendedService;
        }
    }
}
