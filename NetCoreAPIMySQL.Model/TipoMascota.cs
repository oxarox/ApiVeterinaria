using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetCoreAPIMySQL.Model
{
    public class TipoMascota
    {
        public int id_tipo_mascota { get; set; }
        public string nombre_tipo_mascota { get; set; }
        public string raza_mascota { get; set; }
    }
}
