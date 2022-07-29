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
    public class FichaMedicaRepository : IFichaMedicaRepository
    {
        private MySQLConfiguration _connectionString;

        public FichaMedicaRepository(MySQLConfiguration connectionString)
        {
            _connectionString = connectionString;
        }

        protected MySqlConnection dbConection()
        {
            return new MySqlConnection(_connectionString.ConnectionString);
        }

        public async Task<IEnumerable<FichaMedica>> GetAllFichaMedica()
        {
            var db = dbConection();
            var sql = @"
                        SELECT id_ficha_medica, fecha_ingreso, peso_mascota, diagnostico, tratamiento, id_cita
                        FROM ficha_medica ";
            return await db.QueryAsync<FichaMedica>(sql, new { });
        }

        public async Task<FichaMedica> GetFichaMedicaDetalles(int id)
        {
            var db = dbConection();
            var sql = @"
                        SELECT id_ficha_medica, fecha_ingreso, peso_mascota, diagnostico, tratamiento, id_cita
                        FROM ficha_medica 
                        WHERE id_ficha_medica = @Id ";
            return await db.QueryFirstAsync<FichaMedica>(sql, new { Id = id });
        }

        public async Task<bool> InsertarFichaMedica(FichaMedica fichaMedica)
        {
            var db = dbConection();
            var sql = @"
                        INSERT INTO ficha_medica (id_ficha_medica, fecha_ingreso, peso_mascota, diagnostico, tratamiento, id_cita)
                        VALUES (@id_ficha_medica, @fecha_ingreso, @peso_mascota, @diagnostico, @tratamiento, @id_cita)";
            var resultado = await db.ExecuteAsync(sql, new { fichaMedica.id_ficha_medica, fichaMedica.fecha_ingreso, fichaMedica.peso_mascota, fichaMedica.diagnostico, fichaMedica.tratamiento, fichaMedica.id_cita });

            return resultado > 0;
        }

        public async Task<bool> UpdateFichaMedica(FichaMedica fichaMedica)
        {
            var db = dbConection();
            var sql = @"
                        UPDATE ficha_medica 
                        SET   
                            fecha_ingreso = @fecha_ingreso, 
                            peso_mascota = @peso_mascota, 
                            diagnostico = @diagnostico, 
                            tratamiento = @tratamiento, 
                            id_cita = @id_cita 
                        WHERE id_ficha_medica = @id_ficha_medica";
            var resultado = await db.ExecuteAsync(sql, new { fichaMedica.fecha_ingreso, fichaMedica.peso_mascota, fichaMedica.diagnostico, fichaMedica.tratamiento, fichaMedica.id_cita, fichaMedica.id_ficha_medica });

            return resultado > 0;
        }

        public async Task<bool> DeleteFichaMedica(FichaMedica fichaMedica)
        {
            var db = dbConection();
            var sql = @"
                        Delete 
                        FROM ficha_medica 
                        WHERE id_ficha_medica = @Id ";
            var resultado = await db.ExecuteAsync(sql, new { Id = fichaMedica.id_ficha_medica });

            return resultado > 0;
        }
    }
}
