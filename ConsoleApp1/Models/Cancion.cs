using System;
using System.Collections.Generic;

#nullable disable

namespace ConsoleApp1.Models
{
    public partial class Cancion
    {
        public int CveCancion { get; set; }
        public string NombreCancion { get; set; }
        public string LetraCancion { get; set; }
        public int? CveartistaCancion { get; set; }
        public int? CvegeneroCancion { get; set; }

        public virtual Artistum CveartistaCancionNavigation { get; set; }
        public virtual Genero CvegeneroCancionNavigation { get; set; }
    }
}
