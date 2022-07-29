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
    public class EspecialidadRepository : IEspecialidadRepository
    {

        private MySQLConfiguration _connectionString;

        public EspecialidadRepository(MySQLConfiguration connectionString)
        {
            _connectionString = connectionString;
        }

        protected MySqlConnection dbConection()
        {
            return new MySqlConnection(_connectionString.ConnectionString);
        }

        public async Task<IEnumerable<Especialidad>> GetAllEspecialidad()
        {
            var db = dbConection();
            var sql = @"
                        SELECT id_especialidad, nombre_especialidad, detalle, area_cargo
                        FROM especialidad ";
            return await db.QueryAsync<Especialidad>(sql, new { });
        }

        public async Task<Especialidad> GetEspecialidadDetalles(int id)
        {
            var db = dbConection();
            var sql = @"
                        SELECT id_especialidad, nombre_especialidad, detalle, area_cargo
                        FROM especialidad 
                        WHERE id_especialidad = @Id ";
            return await db.QueryFirstAsync<Especialidad>(sql, new { Id = id });
        }

        public async Task<bool> InsertarEspecialidad(Especialidad especialidad)
        {
            var db = dbConection();
            var sql = @"
                        INSERT INTO especialidad (id_especialidad, nombre_especialidad, detalle, area_cargo)
                        VALUES (@id_especialidad, @nombre_especialidad, @detalle, @area_cargo)";
            var resultado = await db.ExecuteAsync(sql, new { especialidad.id_especialidad, especialidad.nombre_especialidad, especialidad.detalle, especialidad.area_cargo });

            return resultado > 0;
        }

        public async Task<bool> UpdateEspecialidad(Especialidad especialidad)
        {
            var db = dbConection();
            var sql = @"
                        UPDATE especialidad 
                        SET  
                            nombre_especialidad = @nombre_especialidad, 
                            detalle = @detalle, 
                            area_cargo = @area_cargo 
                        WHERE id_especialidad = @id_especialidad";
            var resultado = await db.ExecuteAsync(sql, new { especialidad.nombre_especialidad, especialidad.detalle, especialidad.area_cargo, especialidad.id_especialidad });

            return resultado > 0;
        }

        public async Task<bool> DeleteEspecialidad(Especialidad especialidad)
        {
            var db = dbConection();
            var sql = @"
                        Delete 
                        FROM especialidad 
                        WHERE id_especialidad = @Id ";
            var resultado = await db.ExecuteAsync(sql, new { Id = especialidad.id_especialidad });

            return resultado > 0;
        }
    }
}
