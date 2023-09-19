using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace apiRegistroColegio.Model
{
    public class CursoDto
    {
        public int Id { get; set; }
        public int Grado { get; set; }
        public string Salon { get; set; }
        public List<Asignatura> Asignaturas { get; set; }
    }
}
