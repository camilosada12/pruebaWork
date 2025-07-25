using System;


namespace Entity.Model
{
    public class User : BaseModel  // uno 
    {
        public string? username { get; set; }
        public string? password { get; set; }

        public ICollection<RolUser>? Roles { get; set; }

    }

}
