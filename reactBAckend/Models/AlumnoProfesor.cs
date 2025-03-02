using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace reactBAckend.Models
{
    public class AlumnoProfesor
    {
        public int id { get; set; }
        public string dni { get; set; } = null!;
        public string Nombre { get; set; } = null!;
        public string Direccion { get; set; } = null!;
        public int edad { get; set; }
        public string email { get; set; } = null!;
        public string asignatura { get; set; }





    }
}
