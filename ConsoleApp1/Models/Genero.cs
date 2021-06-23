using System;
using System.Collections.Generic;

#nullable disable

namespace ConsoleApp1.Models
{
    public partial class Genero
    {
        public Genero()
        {
            Cancions = new HashSet<Cancion>();
        }

        public int CveGenero { get; set; }
        public string NombreGenero { get; set; }

        public virtual ICollection<Cancion> Cancions { get; set; }
    }
}
