using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetCoreAPIMySQL.Model
{
    public class FichaMedica
    {
        public int id_ficha_medica { get; set; }
        public DateTime fecha_ingreso { get; set; }
        public int peso_mascota { get; set; }
        public string diagnostico { get; set; }
        public string tratamiento { get; set; }
        public int id_cita { get; set; }
    }
}
