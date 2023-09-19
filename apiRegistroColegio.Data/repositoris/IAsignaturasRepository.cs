using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using apiRegistroColegio.Model;

namespace apiRegistroColegio.Data.repositoris
{
    public interface IAsignaturasRepository
    {
        Task<IEnumerable<AsignaturaDto>> GetAllAsignatura();
        Task<AsignaturaDto> GetAsignatura(int id);
        Task<bool> saveAsignatura(Asignatura asignatura);
        Task<bool> updateAsignatura(Asignatura asignatura);
        Task<bool> deleteAsignatura(Asignatura asignatura);
        Task<bool> asignaturarDocente(int asignatura, int docente);
        Task<bool> asignaturarEstudiante(int asignatura, int estudiante);
    }
}
