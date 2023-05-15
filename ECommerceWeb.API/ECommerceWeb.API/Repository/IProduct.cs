using ECommerceWeb.API.Models;

namespace ECommerceWeb.API.Repository
{
    public interface IProduct
    {
        public string SaveProduct(Product Product);
        public string UpdateProduct(Product Product);
        public string DeleteProduct(int ProductId);
        Product GetProduct(int ProductId);
        List<Product> GetAllProduct();
    }
}
