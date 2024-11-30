using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace PL.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductoController : ControllerBase
    {
        [HttpGet]
        [Route("GetAllProducto/{IdSubCategoria}")]
        public IActionResult GetAllCategorias(int IdSubCategoria)
        {
            ML.Result result = BL.Producto.GetAll(IdSubCategoria);

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
