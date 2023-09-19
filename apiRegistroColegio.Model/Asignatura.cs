using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace apiRegistroColegio.Model
{
    public class Asignatura
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public int CursoId { get; set; }
        public int? ProfesorId { get; set; }
    }
}
