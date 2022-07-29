using System.Collections.Generic;
using System.Threading.Tasks;
using NetCoreAPIMySQL.Model;

namespace NetCoreAPIMySQL.Data.Repositories.Interfaz
{
    public interface ICitaRepository
    {
        Task<IEnumerable<Cita>> GetAllCita();
        Task<Cita> GetCitaDetalles(int id);
        Task<bool> InsertarCita(Cita cita);
        Task<bool> UpdateCita(Cita cita);
        Task<bool> DeleteCita(Cita cita);
    }
}
