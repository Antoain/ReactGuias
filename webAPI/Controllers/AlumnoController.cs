using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using reactBAckend.Models;
using reactBAckend.Repository;

namespace webAPI.Controllers
{
    [Route("api")]
    [ApiController]
    public class AlumnoController : ControllerBase
    {
        #region A
        private AlumnoDao _dao = new AlumnoDao();
        #endregion
        #region endPoniTAlumnoProfesor
        [HttpGet("alumnoProfesor")]
        public List<AlumnoProfesor> GetAlumnoProfesors(string usuario) {
            return _dao.alumnoProfesors(usuario);
        }
        #endregion

        #region SelectById
        [HttpGet("alumno")]

        public Alumno selectById(int id) {
            var alumno = _dao.GetById(id);
            return alumno;

        }

        #endregion

        #region ActualizarDatos

        [HttpPut("alumno")]

        public bool actualizarAlumno([FromBody] Alumno alumno)
        {
            return _dao.Update(alumno.Id, alumno);
        }


        #endregion

        #region AlumnoMatricula
        [HttpPost("alumno")]
        public bool InsertarMatricula([FromBody] Alumno alumno, int idAsignatura) {
            return _dao.InsertarMatricula(alumno, idAsignatura);
        
        
        }
        #endregion

        #region deleteAlumno
        [HttpDelete("alumno")]
        public bool EliminarAlumno(int id)
        {
            return _dao.EliminarAlumno(id);
        }
        #endregion
    }
}
