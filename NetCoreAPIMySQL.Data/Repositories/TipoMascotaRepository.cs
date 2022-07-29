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
    public class TipoMascotaRepository : ITipoMascotaRepository
    {
        private MySQLConfiguration _connectionString;

        public TipoMascotaRepository(MySQLConfiguration connectionString)
        {
            _connectionString = connectionString;
        }

        protected MySqlConnection dbConection()
        {
            return new MySqlConnection(_connectionString.ConnectionString);
        }

        public async Task<IEnumerable<TipoMascota>> GetAllTipoMascota()
        {
            var db = dbConection();
            var sql = @"
                        SELECT id_tipo_mascota, nombre_tipo_mascota, raza_mascota 
                        FROM tipo_mascota ";
            return await db.QueryAsync<TipoMascota>(sql, new { });
        }

        public async Task<TipoMascota> GetTipoMascotaDetalles(int id)
        {
            var db = dbConection();
            var sql = @"
                        SELECT id_tipo_mascota, nombre_tipo_mascota, raza_mascota 
                        FROM tipo_mascota 
                        WHERE id_tipo_mascota = @Id ";
            return await db.QueryFirstAsync<TipoMascota>(sql, new { Id = id });
        }

        public async Task<bool> InsertarTipoMascota(TipoMascota tipoMascota)
        {
            var db = dbConection();
            var sql = @"
                        INSERT INTO tipo_mascota (id_tipo_mascota, nombre_tipo_mascota, raza_mascota)
                        VALUES (@id_tipo_mascota, @nombre_tipo_mascota, @raza_mascota)";
            var resultado = await db.ExecuteAsync(sql, new { tipoMascota.id_tipo_mascota, tipoMascota.nombre_tipo_mascota, tipoMascota.raza_mascota });

            return resultado > 0;
        }

        public async Task<bool> UpdateTipoMascota(TipoMascota tipoMascota)
        {
            var db = dbConection();
            var sql = @"
                        UPDATE tipo_mascota 
                        SET   
                            nombre_tipo_mascota = @nombre_tipo_mascota, 
                            raza_mascota = @raza_mascota 
                        WHERE id_tipo_mascota = @id_tipo_mascota";
            var resultado = await db.ExecuteAsync(sql, new { tipoMascota.nombre_tipo_mascota, tipoMascota.raza_mascota, tipoMascota.id_tipo_mascota });

            return resultado > 0;
        }

        public async Task<bool> DeleteTipoMascota(TipoMascota tipoMascota)
        {
            var db = dbConection();
            var sql = @"
                        Delete 
                        FROM tipo_mascota 
                        WHERE id_tipo_mascota = @Id ";
            var resultado = await db.ExecuteAsync(sql, new { Id = tipoMascota.id_tipo_mascota });

            return resultado > 0;
        }
    }
}
