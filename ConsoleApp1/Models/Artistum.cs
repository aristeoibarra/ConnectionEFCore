using System;
using System.Collections.Generic;

#nullable disable

namespace ConsoleApp1.Models
{
    public partial class Artistum
    {
        public Artistum()
        {
            Cancions = new HashSet<Cancion>();
        }

        public int CveArtista { get; set; }
        public string NombreArtista { get; set; }

        public virtual ICollection<Cancion> Cancions { get; set; }
    }
}
