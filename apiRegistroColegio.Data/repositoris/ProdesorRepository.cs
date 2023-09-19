using apiRegistroColegio.Model;
using Dapper;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace apiRegistroColegio.Data.repositoris
{
    public class ProdesorRepository : IProdesorRepository
    {

        private readonly MySqlCofiguration _connectionString;
        public ProdesorRepository(MySqlCofiguration connectionString)
        {
            _connectionString = connectionString;
        }

        protected MySqlConnection dbConnection()
        {
            return new MySqlConnection(_connectionString.ConnectionString);
        }
        public async Task<IEnumerable<Profesor>> GetAllProfesor()
        {
            var db = dbConnection();
            var sql = @"Select * from profesor";
            return await db.QueryAsync<Profesor>(sql, new {  });
        }
    }
}
