using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;
using SQLiteNetExtensions.Attributes;

namespace Apartamente.Models
{
    public class Obiectiv
    {
        [PrimaryKey, AutoIncrement] public int ID { get; set; }
        public string Description { get; set; }
        [OneToMany] public List<ObiectivLista> ObiectivLista { get; set; }
    }
}
