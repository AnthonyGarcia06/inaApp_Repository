using inaApp.Common.interfaces;
using inaApp.Entities;
using inaApp.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace inaApp.Api.Controllers
{
    [ApiController]
    [Route("api/producto")]
    public class ProductoController : Controller
    {

        //inyeccion de dependencia
        private readonly IGenericService<Producto> _productoService;
        

        public ProductoController(IGenericService<Producto> productoServ)
        {
            _productoService = productoServ;
            
        }

        // GET: ProductoController

        [HttpGet]
        public async Task<ActionResult> IndexAsync()
        {
            
            try
            {
                var lista = await _productoService.obtenerTodosAsync();

                if (lista.Count == 0)
                {
                    return NotFound("No hay datos");
                }

                return Ok(lista);
            }
            catch (Exception)
            {

                return StatusCode(500, "Error de servidor,contacte con el servidor");
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> ByIdAsync(int id)
        {

            try
            {
                var result = await _productoService.obtenerPorIdAsync(id);

                if (result == null)
                {
                    return NotFound("Producto no encontrado");
                }

                return Ok(result);
            }
            catch (Exception ex)
            {

                return StatusCode(500, "Error de servidor,contacte con el servidor");
            }
        }

        // GET: ProductoController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        //// GET: ProductoController/Create
        //public ActionResult Create()
        //{



        //    return View();
        //}

        // POST: ProductoController/Create
        [HttpPost]
        public async Task<ActionResult> Create([FromBody] Producto producto)
        {

            try
            {
                var result = await _productoService.CrearAsync(producto);

                return Created("producto creado",result);
            }
            catch (Exception)
            {

                return  StatusCode(500, "Error de servidor,contacte con el servidor");
            }
        }

        //// GET: ProductoController/Edit/5
        //public ActionResult Edit(int id)
        //{
        //    return View();
        //}

        //// POST: ProductoController/Edit/5
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Edit(int id, IFormCollection collection)
        //{
        //    try
        //    {
        //        return RedirectToAction(nameof(IndexAsync));
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}

        // GET: ProductoController/Delete/5

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteAsync(int id)
        {
            try
            {
                if (id <= 0)
                    return BadRequest("Error al eliminar, id invalido");

                var result = await _productoService.EliminarAsync(id);

                return result ? Ok("Producto eliminado") : BadRequest("Error al eliminar el producto");
            }
            catch (Exception ex)
            {

                return StatusCode (500,"Error de servidor,contacte con el servidor");
            }

        }

        [HttpPut("{id}")]
        public async Task<ActionResult> EditAsync(int id, [FromBody] Producto producto)
        {
            try
            {
                if (id <= 0)
                    return BadRequest("Error,id inválido");

                if (id != producto.Id)
                    return BadRequest("El id no coincide con el producto enviado");

                var result = await _productoService.ActualizarAsync(producto);

                return Ok(result);
            }
            catch (Exception)
            {
                return StatusCode(500, "Error de servidor, contacte con el administrador");
            }
        }


    }
}
