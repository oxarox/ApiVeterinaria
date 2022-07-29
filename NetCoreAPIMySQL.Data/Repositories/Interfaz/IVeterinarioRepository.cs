using NetCoreAPIMySQL.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetCoreAPIMySQL.Data.Repositories.Interfaz
{
    public interface IVeterinarioRepository
    {
        Task<IEnumerable<Veterinario>> GetAllVeterinario();
        Task<Veterinario> GetVeterinarioDetalles(int id);
        Task<bool> InsertarVeterinario(Veterinario veterinario);
        Task<bool> UpdateVeterinario(Veterinario veterinario);
        Task<bool> DeleteVeterinario(Veterinario veterinario);
    }
}
