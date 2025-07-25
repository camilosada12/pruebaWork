using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Model
{
    public class Pedidos : BaseModel
    {
        public string name { get; set; }
        public string description { get; set; }
        public ICollection<RolFormPermissions> RolFormPermission { get; set; }
    }

}
