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
    public class CitaRepository : ICitaRepository
    {
        private MySQLConfiguration _connectionString;

        public CitaRepository(MySQLConfiguration connectionString)
        {
            _connectionString = connectionString;
        }

        protected MySqlConnection dbConection()
        {
            return new MySqlConnection(_connectionString.ConnectionString);
        }

        public async Task<IEnumerable<Cita>> GetAllCita()
        {
            var db = dbConection();
            var sql = @"
                        SELECT id_cita, fecha_cita, id_veterinario, id_mascota, id_usuario
                        FROM cita ";
            return await db.QueryAsync<Cita>(sql, new { });
        }

        public async Task<Cita> GetCitaDetalles(int id)
        {
            var db = dbConection();
            var sql = @"
                        SELECT id_cita, fecha_cita, id_veterinario, id_mascota, id_usuario
                        FROM cita 
                        WHERE id_cita = @Id ";
            return await db.QueryFirstAsync<Cita>(sql, new { Id = id });
        }

        public async Task<bool> InsertarCita(Cita cita)
        {
            var db = dbConection();
            var sql = @"
                        INSERT INTO cita (id_cita, fecha_cita, id_veterinario, id_mascota, id_usuario)
                        VALUES (@id_cita, @fecha_cita, @id_veterinario, @id_mascota, @id_usuario)";
            var resultado = await db.ExecuteAsync(sql, new { cita.id_cita, cita.fecha_cita, cita.id_veterinario, cita.id_mascota, cita.id_usuario });

            return resultado > 0;
        }

        public async Task<bool> UpdateCita(Cita cita)
        {
            var db = dbConection();
            var sql = @"
                        UPDATE cita 
                        SET  
                            fecha_cita = @fecha_cita, 
                            id_veterinario = @id_veterinario, 
                            id_mascota = @id_mascota, 
                            id_usuario = @id_usuario 
                        WHERE id_cita = @id_cita";
            var resultado = await db.ExecuteAsync(sql, new { cita.fecha_cita, cita.id_veterinario, cita.id_mascota, cita.id_usuario, cita.id_cita });

            return resultado > 0;
        }
        
        public async Task<bool> DeleteCita(Cita cita)
        {
            var db = dbConection();
            var sql = @"
                        Delete 
                        FROM cita 
                        WHERE id_cita = @Id ";
            var resultado = await db.ExecuteAsync(sql, new { Id = cita.id_cita });

            return resultado > 0;
        }
    }
}
