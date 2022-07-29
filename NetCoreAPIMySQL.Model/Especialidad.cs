using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetCoreAPIMySQL.Model
{
    public class Especialidad
    {
        public int id_especialidad { get; set; }
        public string nombre_especialidad { get; set; }
        public string detalle { get; set; }
        public string area_cargo { get; set; }
    }
}
