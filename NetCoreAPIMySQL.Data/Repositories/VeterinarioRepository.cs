using Dapper;
using MySql.Data.MySqlClient;
using NetCoreAPIMySQL.Data.Repositories.Interfaz;
using NetCoreAPIMySQL.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetCoreAPIMySQL.Data.Repositories
{
    public class VeterinarioRepository : IVeterinarioRepository
    {
        private MySQLConfiguration _connectionString;

        public VeterinarioRepository(MySQLConfiguration connectionString)
        {
            _connectionString = connectionString;
        }

        protected MySqlConnection dbConection()
        {
            return new MySqlConnection(_connectionString.ConnectionString);
        }

        public async Task<IEnumerable<Veterinario>> GetAllVeterinario()
        {
            var db = dbConection();
            var sql = @"
                        SELECT id_veterinario, nombre_veterinario, id_especialidad 
                        FROM veterinario ";
            return await db.QueryAsync<Veterinario>(sql, new { });
        }

        public async Task<Veterinario> GetVeterinarioDetalles(int id)
        {
            var db = dbConection();
            var sql = @"
                        SELECT id_veterinario, nombre_veterinario, id_especialidad 
                        FROM veterinario 
                        WHERE id_veterinario = @Id ";
            return await db.QueryFirstAsync<Veterinario>(sql, new { Id = id });
        }

        public async Task<bool> InsertarVeterinario(Veterinario veterinario)
        {
            var db = dbConection();
            var sql = @"
                        INSERT INTO veterinario (id_veterinario, nombre_veterinario, id_especialidad)
                        VALUES (@id_veterinario, @nombre_veterinario, @id_especialidad)";
            var resultado = await db.ExecuteAsync(sql, new { veterinario.id_veterinario, veterinario.nombre_veterinario, veterinario.id_especialidad });

            return resultado > 0;
        }

        public async Task<bool> UpdateVeterinario(Veterinario veterinario)
        {
            var db = dbConection();
            var sql = @"
                        UPDATE veterinario 
                        SET   
                            nombre_veterinario = @nombre_veterinario, 
                            id_especialidad = @id_especialidad 
                        WHERE id_veterinario = @id_veterinario";
            var resultado = await db.ExecuteAsync(sql, new { veterinario.nombre_veterinario, veterinario.id_especialidad, veterinario.id_veterinario });

            return resultado > 0;
        }

        public async Task<bool> DeleteVeterinario(Veterinario veterinario)
        {
            var db = dbConection();
            var sql = @"
                        Delete 
                        FROM veterinario 
                        WHERE id_veterinario = @Id ";
            var resultado = await db.ExecuteAsync(sql, new { Id = veterinario.id_veterinario });

            return resultado > 0;
        }
    }
}
