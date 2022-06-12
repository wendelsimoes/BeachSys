using System.Collections.Generic;

namespace BeachSys.Models
{
    public class Admin : Usuario
    {
        public virtual ICollection<Armario> Armarios { get; set; }
    }
}