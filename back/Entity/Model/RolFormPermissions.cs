using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Model
{
    public class RolFormPermissions : BaseModel
    {
        public int rolid { get; set; }
        public int formid { get; set; }
        public int permissionid { get; set; }
        public rol Rol { get; set; }
        public Pizzas Form { get; set; }
        public Pedidos Permission { get; set; }
    }
}
