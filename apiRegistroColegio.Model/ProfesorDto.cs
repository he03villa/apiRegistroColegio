using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace apiRegistroColegio.Model
{
    public class ProfesorDto
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public List<Asignatura> Asignaturas { get; set; }
    }
}
