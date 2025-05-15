using Microsoft.EntityFrameworkCore;
using parcial1.EF;
using parcial1.Interfaces;
using parcial1.Models;

namespace parcial1.Repositories
{
    public class ProductoRepository(MiDBContext _context) : IProductoRepository
    {
        public async Task<bool> ActivateDeactivateProduct(int id, bool isActive)
        {
           var product = await _context.Productos.FirstOrDefaultAsync(p => p.Id == id);

            if (product == null)
            {
                return false;
            }
            else
            {
                product.Activo = isActive;
                _context.SaveChangesAsync();
                return true;
            }
        }

        public async Task<bool> ChangeProductPrice(int id, int newPrice)
        {
            var product = await _context.Productos.FirstOrDefaultAsync(p => p.Id == id);

            if(product == null)
            {
                return false;
            }
            else
            {
                product.Precio = newPrice;

                var status = await _context.SaveChangesAsync();

                return (status > 0);
            }


        }

        public async Task<List<ProductoModel>> GetProductsOrderByPriceAsc()
        {
            var products = await _context.Productos
                .Where(p => p.Activo)
                .OrderBy(p => p.Precio)
                .Select(p => new ProductoModel
                {
                    Descripcion = p.Descripcion,
                    Precio = p.Precio
                })
                .ToListAsync();

            return products;    
        } 
    }

}
