using Dapper;
using MySql.Data.MySqlClient;
using NetCoreAPIMySQL.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NetCoreAPIMySQL.Data.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private MySQLConfiguration _connectionString;

        public UsuarioRepository(MySQLConfiguration connectionString)
        {
            _connectionString = connectionString;
        }
        protected MySqlConnection dbConection()
        {
            return new MySqlConnection(_connectionString.ConnectionString);
        }

        public async Task<IEnumerable<Usuario>> GetAllUsuario()
        {
            var db = dbConection();
            var sql = @"
                        SELECT id_usuario, nombre_usuario, password, cargo, token 
                        FROM usuario ";
            return await db.QueryAsync<Usuario>(sql, new { });
        }

        public async Task<Usuario> GetUsuarioDetalles(int id)
        {
            var db = dbConection();
            var sql = @"
                        SELECT id_usuario, nombre_usuario, password, cargo, token
                        FROM usuario 
                        WHERE id_usuario = @Id ";
            return await db.QueryFirstAsync<Usuario>(sql, new { Id = id });
        }

        public async Task<bool> InsertarUsuario(Usuario usuario)
        {
            var db = dbConection();
            var sql = @"
                        INSERT INTO usuario (id_usuario, nombre_usuario, password, cargo, token)
                        VALUES (@id_usuario, @nombre_usuario, @password, @cargo, @token)";
            var resultado = await db.ExecuteAsync(sql, new { usuario.id_usuario, usuario.nombre_usuario, usuario.password, usuario.cargo, usuario.token });

            return resultado > 0;
        }

        public async Task<bool> UpdateUsuario(Usuario usuario)
        {
            var db = dbConection();
            var sql = @"
                        UPDATE usuario 
                        SET  
                            nombre_usuario = @nombre_usuario, 
                            password = @password, 
                            cargo = @cargo,
                            token = @token 
                        WHERE id_usuario = @id_usuario";
            var resultado = await db.ExecuteAsync(sql, new { usuario.nombre_usuario, usuario.password, usuario.cargo, usuario.token, usuario.id_usuario });

            return resultado > 0;
        }
        public async Task<bool> DeleteUsuario(Usuario usuario)
        {
            var db = dbConection();
            var sql = @"
                        Delete 
                        FROM usuario 
                        WHERE id_usuario = @Id ";
            var resultado = await db.ExecuteAsync(sql, new { Id = usuario.id_usuario });

            return resultado > 0;
        }

        // con el nombre de usuario y una contraseña retornar un usuario si existe si no retornar null
        public async Task<Usuario> comprobarCredencialesUsuario(string nombreUsuario, string password)
        {
            var db = dbConection();
            var sql = @"
                        SELECT id_usuario, nombre_usuario, password, cargo, token 
                        FROM usuario 
                        WHERE nombre_usuario = @NombreUsuario AND password = @Password ";
            return await db.QueryFirstAsync<Usuario>(sql, new { NombreUsuario = nombreUsuario, Password = password });
        }

    }
}
