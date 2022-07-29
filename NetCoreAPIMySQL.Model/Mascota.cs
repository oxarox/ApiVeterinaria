using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetCoreAPIMySQL.Model
{
    public class Mascota
    {
        public int id_mascota { get; set; }
        public string nombre_mascota { get; set; }
        public int edad_mascota { get; set; }
        public int id_tipo_mascota { get; set; }
        public int id_cliente { get; set; }
    }
}
