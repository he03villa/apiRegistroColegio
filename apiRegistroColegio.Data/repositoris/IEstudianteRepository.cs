using apiRegistroColegio.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace apiRegistroColegio.Data.repositoris
{
    public interface IEstudianteRepository
    {
        Task<IEnumerable<Estudiante>> GetAllEstudiante();
    }
}
