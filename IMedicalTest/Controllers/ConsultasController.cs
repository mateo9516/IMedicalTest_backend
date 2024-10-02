using IMedicalTest.Datos;
using IMedicalTest.Datos.ContratosRespuesta;
using IMedicalTest.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace IMedicalTest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ConsultasController : ControllerBase
    {   
        private readonly InfoCiudades InfoCiudades;
        private readonly TestImedicalContext contexto;
        public ConsultasController(TestImedicalContext _contexto) 
        {
            contexto = _contexto;
            InfoCiudades = new InfoCiudades(_contexto);
        }


        [Route("consulta-noticias")]
        [HttpGet]
        public ActionResult<IEnumerable<ResNoticias>> GetNoticias(string nombreCiudad)
        {
            return Ok(InfoCiudades.GetNoticiasCiudad(nombreCiudad));
        }

        [Route("consulta-noticias-clima")]
        [HttpGet]
        public ActionResult<IEnumerable<ResNoticiasClima>> GetNoticiasClima(string nombreCiudad)
        {
            return Ok(InfoCiudades.GetNoticiasClima(nombreCiudad));
        }

        [Route("consultas-realizadas")]
        [HttpGet]
        public ActionResult<IEnumerable<ResConsultas>> GetConsultas()
        {
            return Ok(InfoCiudades.GetConsultas());
        }

    }
}
