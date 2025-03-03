using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using reactBAckend.Repository;
using reactBAckend.Models;



namespace webAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CalificacionController : ControllerBase
    {
        private CalificacionDao _cdao = new CalificacionDao();

        #region Lista de calificaciones
        [HttpGet("calificaciones")]
        public List<Calificacion> get(int idMatricula) {
            return _cdao.seleccion(idMatricula);
        
        }
        #endregion


        #region ingresarDatos
        [HttpPost("calificacion")]
        public bool Insertar([FromBody] Calificacion calificacion) { 
            return _cdao.Insertar(calificacion);
        }
        #endregion

        #region EliminarCalificaciones
        [HttpDelete("calificacion")]
        public bool delete(int idCalificacion)
        {
            return _cdao.eliminarCalificacion(idCalificacion);
        }
        #endregion
    }
}
