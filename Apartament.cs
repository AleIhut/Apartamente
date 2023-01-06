using Apartamente.Models;
using SQLite;
using SQLiteNetExtensions.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Apartamente
{
    public class Apartament
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
        public string NumeApartament { get; set; }
        public string Adress { get; set; }
        public string DetaliiApartament { get { return NumeApartament + " " + Adress; } }
        [OneToMany]
        public List<ListaObiective> ListaObiective { get; set; }
    }
}
