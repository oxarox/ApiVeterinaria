using Dapper;
using MySql.Data.MySqlClient;
using NetCoreAPIMySQL.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NetCoreAPIMySQL.Data.Repositories
{
    public class ClienteRepository : IClienteRepository
    {
        private MySQLConfiguration _connectionString;

        public ClienteRepository(MySQLConfiguration connectionString)
        {
            _connectionString = connectionString;
        }

        protected MySqlConnection dbConection()
        {
            return new MySqlConnection(_connectionString.ConnectionString);
        }

        public async Task<IEnumerable<Cliente>> GetAllCliente()
        {
            var db = dbConection();
            var sql = @"
                        SELECT id_cliente, nombre_cliente, direccion_cliente, telefono
                        FROM cliente ";
            return await db.QueryAsync<Cliente>(sql, new { });
        }

        public async Task<Cliente> GetClienteDetalles(int id)
        {
            var db = dbConection();
            var sql = @"
                        SELECT id_cliente, nombre_cliente, direccion_cliente, telefono
                        FROM cliente 
                        WHERE id_cliente = @Id ";
            return await db.QueryFirstAsync<Cliente>(sql, new { Id = id });
        }

        public async Task<bool> InsertarCliente(Cliente cliente)
        {
            var db = dbConection();
            var sql = @"
                        INSERT INTO cliente (id_cliente, nombre_cliente, direccion_cliente, telefono)
                        VALUES (@id_cliente, @nombre_cliente, @direccion_cliente, @telefono)";
            var resultado = await db.ExecuteAsync(sql, new { cliente.id_cliente, cliente.nombre_cliente, cliente.direccion_cliente, cliente.telefono });

            return resultado > 0;
        }

        public async Task<bool> UpdateCliente(Cliente cliente)
        {
            var db = dbConection();
            var sql = @"
                        UPDATE cliente 
                        SET  
                            id_cliente = @id_cliente, 
                            nombre_cliente = @nombre_cliente, 
                            direccion_cliente = @direccion_cliente, 
                            telefono = @telefono 
                        WHERE id_cliente = @id_cliente";
            var resultado = await db.ExecuteAsync(sql, new { cliente.id_cliente, cliente.nombre_cliente, cliente.direccion_cliente, cliente.telefono });

            return resultado > 0;
        }
        public async Task<bool> DeleteCliente(Cliente cliente)
        {
            var db = dbConection();
            var sql = @"
                        Delete 
                        FROM cliente 
                        WHERE id_cliente = @Id ";
            var resultado = await db.ExecuteAsync(sql, new { Id = cliente.id_cliente  });

            return resultado > 0;
        }
    }
}
