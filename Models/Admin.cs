using System.Collections.Generic;

namespace BeachSys.Models
{
    public class Admin : Usuario
    {
        public ICollection<Armario> Armarios { get; set; }
    }
}