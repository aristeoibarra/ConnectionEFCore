using System;
using System.Linq;
using System.Data;
using Microsoft.EntityFrameworkCore;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            using (Models.MusicBitDbContext db = new Models.MusicBitDbContext())
            {
                //Models.Genero oGenero = new Models.Genero();
                //oGenero.NombreGenero = "Salsa";
                //db.Generos.Add(oGenero);
                //db.SaveChanges();

                //Models.Genero oGenero = db.Generos.Where(x => x.NombreGenero == "Rap").First();

                //oGenero.NombreGenero = "Ronaldo";
                //db.Entry(oGenero).State = EntityState.Modified;
                //db.SaveChanges();

                Models.Genero oGenero = db.Generos.Find(3);

                db.Generos.Remove(oGenero);
                db.SaveChanges();

                var lst = db.Generos;

                foreach (var _oGenero in lst)
                {
                    Console.WriteLine(_oGenero.NombreGenero);
                }
            }
        }
    }
}
