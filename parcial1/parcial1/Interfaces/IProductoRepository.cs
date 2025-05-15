using parcial1.EF;
using parcial1.Models;

namespace parcial1.Interfaces
{
    public interface IProductoRepository
    {
        Task<List<ProductoModel>> GetProductsOrderByPriceAsc();


        //Para una parte de administración, se debe poder activar y desactivar un trámite(producto).

        Task<bool> ActivateDeactivateProduct(int id, bool isActive);

        //Para una parte de administración, se debe poder cambiar el precio del trámite.
        Task<bool> ChangeProductPrice(int id, int newPrice);


    
    }
}
