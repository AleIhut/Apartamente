using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;
using SQLiteNetExtensions.Attributes;

namespace Apartamente.Models
{
   public class ObiectivLista
    {
        [PrimaryKey, AutoIncrement] public int ID { get; set; }
        [ForeignKey(typeof(ListaObiective))] public int ListaObiectiveID { get; set; }
        public int ObiectivID { get; set; }
    }
}
