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
    public class AsignaturaRepository : IAsignaturasRepository
    {
        private readonly MySqlCofiguration _connectionString;
        public AsignaturaRepository(MySqlCofiguration connectionString)
        {
            _connectionString = connectionString;
        }

        protected MySqlConnection dbConnection()
        {
            return new MySqlConnection(_connectionString.ConnectionString);
        }

        public async Task<bool> deleteAsignatura(Asignatura asignatura)
        {
            var db = dbConnection();
            var sql = @"Delete  from asignatura where id = @Id";
            var resul = await db.ExecuteAsync(sql, new { Id = asignatura.Id });
            return resul > 0;
        }

        public async Task<IEnumerable<AsignaturaDto>> GetAllAsignatura()
        {
            var db = dbConnection();

            var sql = @"Select *, curso_id as CursoId, profesor_id as ProfesorId from asignatura";
            var arrayAsignatura = await db.QueryAsync<Asignatura>(sql, new {});
            List<AsignaturaDto> arrayAsignaturaDto = new List<AsignaturaDto>();
            foreach (var item in arrayAsignatura)
            {
                var sql2 = @"
                            SELECT est.* FROM inscrito ins
                            Inner join estudiante est on est.id = ins.estudiante_id
                            Where ins.asignatura_id = @Id
                          ";
                var sql3 = @"Select * from profesor Where id = @Id";
                var sql4 = @"Select * from curso Where id = @Id";
                var arrayEstudiante = await db.QueryAsync<Estudiante>(sql2, new { Id = item.Id });
                var profesor = item.ProfesorId != null ? await db.QueryFirstOrDefaultAsync<Profesor>(sql3, new { Id = item.ProfesorId }) : new Profesor();
                var curso = await db.QueryFirstOrDefaultAsync<Curso>(sql4, new { Id = item.CursoId });
                AsignaturaDto asignaturaDto = new AsignaturaDto();
                asignaturaDto.Id = item.Id;
                asignaturaDto.Nombre = item.Nombre;
                asignaturaDto.Estudiantes = (List<Estudiante>)arrayEstudiante;
                asignaturaDto.Curso = (Curso)curso;
                asignaturaDto.Profesor = (Profesor)profesor;
                arrayAsignaturaDto.Add(asignaturaDto);

            }
            return arrayAsignaturaDto;
            //return await db.QueryAsync<Asignatura>(sql, new { });
        }

        public async Task<AsignaturaDto> GetAsignatura(int id)
        {
            var db = dbConnection();
            var sql = @"Select * from asignatura where id = @Id";
            var asignatura = await db.QueryFirstOrDefaultAsync<Asignatura>(sql, new { Id = id });
            var sql2 = @"
                            SELECT est.* FROM inscrito ins
                            Inner join estudiante est on est.id = ins.estudiante_id
                            Where ins.asignatura_id = @Id
                          ";
            var sql3 = @"Select * from profesor Where id = @Id";
            var sql4 = @"Select * from curso Where id = @Id";
            var arrayEstudiante = await db.QueryAsync<Estudiante>(sql2, new { Id = asignatura.Id });
            var profesor = asignatura.ProfesorId != null ? await db.QueryFirstOrDefaultAsync<Profesor>(sql3, new { Id = asignatura.ProfesorId }) : new Profesor();
            var curso = await db.QueryFirstOrDefaultAsync<Curso>(sql4, new { Id = asignatura.CursoId });
            AsignaturaDto asignaturaDto = new AsignaturaDto();
            asignaturaDto.Id = asignatura.Id;
            asignaturaDto.Nombre = asignatura.Nombre;
            asignaturaDto.Estudiantes = (List<Estudiante>)arrayEstudiante;
            asignaturaDto.Curso = (Curso)curso;
            asignaturaDto.Profesor = (Profesor)profesor;
            return asignaturaDto;
            //return await db.QueryFirstOrDefaultAsync<Asignatura>(sql, new { Id = id });
        }

        public async Task<bool> saveAsignatura(Asignatura asignatura)
        {
            var db = dbConnection();
            var sql = @"Insert Into asignatura(nombre, curso_id) Value (@Nombre, @Curso)";
            var resul = await db.ExecuteAsync(sql, new { Nombre = asignatura.Nombre, Curso = asignatura.CursoId });
            return resul > 0;
        }

        public async Task<bool> updateAsignatura(Asignatura asignatura)
        {
            var db = dbConnection();
            var sql = @"Update asignatura Set nombre = @Nombre, curso_id = @Curso Where id = @Id";
            var resul = await db.ExecuteAsync(sql, new { Nombre = asignatura.Nombre, Curso = asignatura.CursoId, Id = asignatura.Id });
            AsignaturaDto asignaturaDto = new AsignaturaDto();
            return resul > 0;
        }

        public async Task<bool> asignaturarDocente(int asignatura, int docente)
        {
            var db = dbConnection();
            var sql = @"Update asignatura Set profesor_id = @Profesor Where id = @Id";
            var resul = await db.ExecuteAsync(sql, new { Profesor = docente, Id = asignatura });
            return resul > 0;
        }

        public async Task<bool> asignaturarEstudiante(int asignatura, int estudiante)
        {
            var db = dbConnection();
            var sql = @"Insert Into inscrito(asignatura_id, estudiante_id) Value (@Asignatura, @Estudiante)";
            var resul = await db.ExecuteAsync(sql, new { Asignatura = asignatura, Estudiante = estudiante });
            return resul > 0;
        }
    }
}
