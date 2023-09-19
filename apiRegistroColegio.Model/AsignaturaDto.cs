using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace apiRegistroColegio.Model
{
    public class AsignaturaDto
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public Profesor? Profesor { get; set; }
        public List<Estudiante> Estudiantes { get; set; }
        public Curso Curso { get; set; }
    }
}
