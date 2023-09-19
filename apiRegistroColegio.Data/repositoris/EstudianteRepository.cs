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
    public class EstudianteRepository : IEstudianteRepository
    {
        private readonly MySqlCofiguration _connectionString;
        public EstudianteRepository(MySqlCofiguration connectionString)
        {
            _connectionString = connectionString;
        }

        protected MySqlConnection dbConnection()
        {
            return new MySqlConnection(_connectionString.ConnectionString);
        }
        public async Task<IEnumerable<Estudiante>> GetAllEstudiante()
        {
            var db = dbConnection();
            var sql = @"Select * from estudiante";
            return await db.QueryAsync<Estudiante>(sql, new { });
        }
    }
}
