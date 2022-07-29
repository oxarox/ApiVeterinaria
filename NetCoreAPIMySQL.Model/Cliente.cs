using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetCoreAPIMySQL.Model
{
    public class Cliente
    {
        public int id_cliente { get; set; }
        public string nombre_cliente { get; set; }
        public string direccion_cliente { get; set; }
        public string telefono { get; set; }
    }
}
