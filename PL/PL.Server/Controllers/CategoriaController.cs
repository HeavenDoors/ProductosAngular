using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace PL.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriaController : ControllerBase
    {
        [HttpGet]
        [Route("GetAllCategoria")]
        public IActionResult GetAllCategoria()
        {
            ML.Result result = BL.Categoria.GetAll();

            if (result.Success)
            {
                return Ok(result.Objects);
            }
            else
            {
                return BadRequest();
            }
        }
    }
}
