using Microsoft.AspNetCore.Mvc;
using parcial1.Interfaces;
using parcial1.Models;

namespace parcial1.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductoController(IProductoRepository productoRepository) : ControllerBase
    {
        //Consultar qué tipos de trámites (productos) se pueden realizar y cuál es su costo, por defecto ordenados por precio de menor a mayor.
        [HttpGet("getProductos")]
        public async Task<List<ProductoModel>> GetProductsOrderByPriceAsc()
        {
            return await productoRepository.GetProductsOrderByPriceAsc();
            
        }
        //Para una parte de administración, se debe poder activar y desactivar un trámite(producto).
        [HttpPost("activateDeactivateProduct/{id}")]
        public async Task<bool> ActivateDeactivateProduct(int id, [FromBody] bool isActive)
        {
            if (id <= 0)
            {
                return false;
            }
            return await productoRepository.ActivateDeactivateProduct(id, isActive);
        }
        //7) Nice To Have: En el punto 4, al cambiar el precio, sería ideal que el producto no perdiera el precio histórico del mismo, por cuestiones legales y de anulaciones en el pago. Con respecto a esto el Product Owner nos comentó que no es obligatorio hacer otra tabla,  meramente por un único dato que va a cambiar cada 3 años. Queda a criterio del desarrollador.
        //Para una parte de administración, se debe poder cambiar el precio del trámite.
        //el punto 7 esta hecho con un trigger en la base de datos
        [HttpPost("changeProductPrice/{id}")]
        public async Task<bool> ChangeProductPrice(int id, [FromBody] int newPrice)
        {
            if (id <= 0 || newPrice <= 0)
            {
                return false;
            }
            return await productoRepository.ChangeProductPrice(id, newPrice);
        }
    }
}
