using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetCoreAPIMySQL.Model
{
    public class Veterinario
    {
        public int id_veterinario { get; set; }
        public string nombre_veterinario { get; set; }
        public int id_especialidad { get; set; }
    }
}
