using NetCoreAPIMySQL.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetCoreAPIMySQL.Data.Repositories.Interfaz
{
    public interface IEspecialidadRepository
    {
        Task<IEnumerable<Especialidad>> GetAllEspecialidad();
        Task<Especialidad> GetEspecialidadDetalles(int id);
        Task<bool> InsertarEspecialidad(Especialidad especialidad);
        Task<bool> UpdateEspecialidad(Especialidad especialidad);
        Task<bool> DeleteEspecialidad(Especialidad especialidad);
    }
}
