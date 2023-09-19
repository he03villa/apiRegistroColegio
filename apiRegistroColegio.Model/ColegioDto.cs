using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace apiRegistroColegio.Model
{
    public class ColegioDto
    {
        public int Id { get; set; }
        public int Nombre { get; set; }
        public List<Curso> Cursos { get; set; }
    }
}
