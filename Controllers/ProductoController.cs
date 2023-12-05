using apiProductos.Data;
using apiProductos.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace apiProductos.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductoController : ControllerBase
    {
        private readonly DataContext _context;

        public ProductoController(DataContext context)
        {
            _context = context;
        }

        [HttpPost]
        public async Task<ActionResult<Producto>> PostProducto(Producto producto){
            var nuevoProducto = new Producto(
                Id: producto.Id,
                Nombre: producto.Nombre,
                Descripcion: producto.Descripcion,
                Precio : producto.Precio,
                Fecha : DateTime.Now,
                Activo: true
            );

            _context.Productos.Add(nuevoProducto);

            await _context.SaveChangesAsync();

            return nuevoProducto;
        }

        [HttpGet]
        public async Task<ActionResult<List<Producto>>> GetProductos(){
            return await _context.Productos.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Producto>> GetProducto(int id){
            var busquedaProducto = await _context.Productos.FindAsync(id);

            if(busquedaProducto == null){
                return NotFound();
            }

            return busquedaProducto;
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutProducto(int id, Producto producto){
            if(id != producto.Id){
                return BadRequest();
            }

            var busquedaProducto = await _context.Productos.FindAsync(id);

            if(busquedaProducto == null){
                return NotFound();
            }

            busquedaProducto.Nombre = producto.Nombre;
            busquedaProducto.Descripcion = producto.Descripcion;
            busquedaProducto.Precio = producto.Precio;
            busquedaProducto.Activo = producto.Activo;

            await _context.SaveChangesAsync();
            return Ok();
        }
        

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProducto(int id){
            var busquedaProducto = await _context.Productos.FindAsync(id);
             if(busquedaProducto == null){
                return NotFound();
            }

            _context.Productos.Remove(busquedaProducto);

            await _context.SaveChangesAsync();

            return Ok();

        }
    }
    
}