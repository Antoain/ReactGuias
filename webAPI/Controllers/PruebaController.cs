using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace webAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PruebaController : ControllerBase
    {

        #region Prueva
        [HttpGet("prueba")]

        public string Get()
        {
            return "Hola me quiero morir, no se que hacer con mi vida, no sirvo pa esto :V";
        }
        #endregion
    }
}
