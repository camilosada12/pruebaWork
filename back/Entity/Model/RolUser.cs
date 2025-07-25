

namespace Entity.Model
{
    public class RolUser : BaseModel // Mucho
    {
        public int rolid { get; set; }
        public int userid { get; set; }
        //public bool Active { get; set; }

        public rol? Rol { get; set; }

        public User? User { get; set; }
    }
}
