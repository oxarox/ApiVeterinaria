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
    public class MascotaRepository : IMascotaRepository
    {
        private MySQLConfiguration _connectionString;

        public MascotaRepository(MySQLConfiguration connectionString)
        {
            _connectionString = connectionString;
        }

        protected MySqlConnection dbConection()
        {
            return new MySqlConnection(_connectionString.ConnectionString);
        }

        public async Task<IEnumerable<Mascota>> GetAllMascota()
        {
            var db = dbConection();
            var sql = @"
                        SELECT id_mascota, nombre_mascota, edad_mascota, id_tipo_mascota, id_cliente
                        FROM mascota ";
            return await db.QueryAsync<Mascota>(sql, new { });
        }

        public async Task<Mascota> GetMascotaDetalles(int id)
        {
            var db = dbConection();
            var sql = @"
                        SELECT id_mascota, nombre_mascota, edad_mascota, id_tipo_mascota, id_cliente
                        FROM mascota 
                        WHERE id_mascota = @Id ";
            return await db.QueryFirstAsync<Mascota>(sql, new { Id = id });
        }

        public async Task<bool> InsertarMascota(Mascota mascota)
        {
            var db = dbConection();
            var sql = @"
                        INSERT INTO mascota (id_mascota, nombre_mascota, edad_mascota, id_tipo_mascota, id_cliente)
                        VALUES (@id_mascota, @nombre_mascota, @edad_mascota, @id_tipo_mascota, @id_cliente)";
            var resultado = await db.ExecuteAsync(sql, new { mascota.id_mascota, mascota.nombre_mascota, mascota.edad_mascota, mascota.id_tipo_mascota, mascota.id_cliente });

            return resultado > 0;
        }

        public async Task<bool> UpdateMascota(Mascota mascota)
        {
            var db = dbConection();
            var sql = @"
                        UPDATE mascota 
                        SET  
                            nombre_mascota = @nombre_mascota, 
                            edad_mascota = @edad_mascota, 
                            id_tipo_mascota = @id_tipo_mascota, 
                            id_cliente = @id_cliente 
                        WHERE id_mascota = @id_mascota";
            var resultado = await db.ExecuteAsync(sql, new { mascota.nombre_mascota, mascota.edad_mascota, mascota.id_tipo_mascota, mascota.id_cliente, mascota.id_mascota });

            return resultado > 0;
        }

        public async Task<bool> DeleteMascota(Mascota mascota)
        {
            var db = dbConection();
            var sql = @"
                        Delete 
                        FROM mascota 
                        WHERE id_mascota = @Id ";
            var resultado = await db.ExecuteAsync(sql, new { Id = mascota.id_mascota });

            return resultado > 0;
        }
    }
}
