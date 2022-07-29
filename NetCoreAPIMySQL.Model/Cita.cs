using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetCoreAPIMySQL.Model
{
    public class Cita
    {
        public int id_cita { get; set; }
        public DateTime fecha_cita { get; set; }
        public int id_veterinario { get; set; }
        public int id_mascota { get; set; }
        public int id_usuario { get; set; }
    }
}
