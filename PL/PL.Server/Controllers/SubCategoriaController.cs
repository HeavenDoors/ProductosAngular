using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace PL.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SubCategoriaController : ControllerBase
    {
        [HttpGet]
        [Route("GetAllSubCategoria/{IdCategoria}")]
        public IActionResult GetAllSubCategoria(int IdCategoria)
        {
            ML.Result result = BL.SubCategoria.GetAll(IdCategoria);

            if (result.Success)
            {
                return Ok(result.Objects);
            }
            else
            {
                return NotFound();
            }
        }
    }
}
