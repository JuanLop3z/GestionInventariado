using InventarioBackend.Models;
using InventarioDB.DataBase;
using InventarioDB.DataBase.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using Utils.Responses;

namespace InventarioBackend.Controllers
{
    [EnableCors("AllowAngular")]
    [ApiController]
    [Route("productos")]
    [Authorize]
    public class ProductosController : ControllerBase
    {
        private readonly InventarioContext _context;

        public ProductosController(InventarioContext context)
        {
            _context = context;
        }

        //GET /productos/inventario
        [Authorize]
        [HttpGet("inventario")]
        public async Task<ApiResponse<List<Productos>>> GetInventario()
        {
            List < Productos > productos = new List<Productos>();
            try
            {
                 productos = await _context.Productos.ToListAsync();

                return ApiResponseTypes.Success(productos, "Consulta de cabeceras de documentos referencia exitosa");

            }
            catch (Exception ex)
            {
                return ApiResponseTypes.BadRequest(productos, ex);
            }
        }

        // POST /productos/movimiento
        [Authorize]
        [HttpPost("movimiento")]
        public async Task<ApiResponse<Productos>> Movimiento([FromBody] MovimientoRequest request)
        {
            Productos producto = null!;
            try
            {
                producto = await _context.Productos.FirstOrDefaultAsync(p => p.Id == request.ProductoId);
                if (producto == null)
                    return ApiResponseTypes.Error<Productos>(200,"Producto no encontrado");

                if (request.Tipo == "entrada")
                {
                    producto.Cantidad += request.Cantidad;
                }
                else if (request.Tipo == "salida")
                {
                    if (producto.Cantidad < request.Cantidad)
                        return ApiResponseTypes.Error<Productos>(401,"No hay suficiente inventario");

                    producto.Cantidad -= request.Cantidad;
                }
                else
                {
                    return ApiResponseTypes.Error<Productos>(401,"Tipo de movimiento inválido (use 'entrada' o 'salida')");
                }

                _context.Productos.Update(producto);
                await _context.SaveChangesAsync();

                return ApiResponseTypes.Success(producto, "Movimiento registrado correctamente");
            }
            catch (Exception ex)
            {
                return ApiResponseTypes.BadRequest(producto, ex);
            }
        }
    }
}
