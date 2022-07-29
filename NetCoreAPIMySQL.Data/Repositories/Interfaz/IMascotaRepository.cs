using NetCoreAPIMySQL.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetCoreAPIMySQL.Data.Repositories.Interfaz
{
    public interface IMascotaRepository
    {
        Task<IEnumerable<Mascota>> GetAllMascota();
        Task<Mascota> GetMascotaDetalles(int id);
        Task<bool> InsertarMascota(Mascota mascota);
        Task<bool> UpdateMascota(Mascota mascota);
        Task<bool> DeleteMascota(Mascota mascota);
    }
}
