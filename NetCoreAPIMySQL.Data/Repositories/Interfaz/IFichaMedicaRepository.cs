using NetCoreAPIMySQL.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetCoreAPIMySQL.Data.Repositories.Interfaz
{
    public interface IFichaMedicaRepository
    {
        Task<IEnumerable<FichaMedica>> GetAllFichaMedica();
        Task<FichaMedica> GetFichaMedicaDetalles(int id);
        Task<bool> InsertarFichaMedica(FichaMedica fichaMedica);
        Task<bool> UpdateFichaMedica(FichaMedica fichaMedica);
        Task<bool> DeleteFichaMedica(FichaMedica fichaMedica);
    }
}
