using Business.Services;
using Entity.DTOs;
using Entity.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers
{
    /// <summary>
    /// Controlador API para gestionar operaciones relacionadas con permisos.
    /// Hereda de un controlador genérico que maneja las operaciones CRUD básicas.
    /// </summary>
    [Route("api/[controller]")]
    public class PedidosController : GenericController<Pedidos,PedidosDt>
    {
        /// <summary>
        /// Constructor que recibe el servicio genérico específico para permisos y el servicio de logging.
        /// </summary>
        /// <param name="service">Servicio genérico para operaciones CRUD de permisos.</param>
        /// <param name="logService">Servicio para registrar logs de la aplicación.</param>
        public PedidosController(IBaseModelBusiness<Pedidos, PedidosDt> service)
            : base(service)
        {
        }
    }
}
