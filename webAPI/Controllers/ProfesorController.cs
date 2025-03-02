using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using reactBAckend.Models;
using reactBAckend.Repository;

namespace webAPI.Controllers
{
    [Route("api")]
    [ApiController]
    public class ProfesorController : ControllerBase
    { 
        private ProfesorDao _proDao = new ProfesorDao();
        [HttpPost("autenticacion")]

        public string loginProfesor([FromBody] Profesor prof) 
        {
            var prof1 = _proDao.login(prof.Usuario, prof.Pass);
            if (prof1 != null)
            {
                return prof1.Usuario;
            }
            return "Elemento no encontrado";
        }
    }
}
