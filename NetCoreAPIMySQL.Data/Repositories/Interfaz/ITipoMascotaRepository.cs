using NetCoreAPIMySQL.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetCoreAPIMySQL.Data.Repositories.Interfaz
{
    public interface ITipoMascotaRepository
    {
        Task<IEnumerable<TipoMascota>> GetAllTipoMascota();
        Task<TipoMascota> GetTipoMascotaDetalles(int id);
        Task<bool> InsertarTipoMascota(TipoMascota TipoMascota);
        Task<bool> UpdateTipoMascota(TipoMascota TipoMascota);
        Task<bool> DeleteTipoMascota(TipoMascota TipoMascota);
    }
}
