using ECommerceWeb.API.Data;
using ECommerceWeb.API.Models;
using Microsoft.EntityFrameworkCore;

namespace ECommerceWeb.API.Repository
{
    public class ProductRepo:IProduct
    {
        private ECommerceApplicationContext _dbContext;

        #region ProductRepo
        /// <summary>
        /// ProductRepo Constuctor
        /// </summary>
        /// <param name="ShoppingCartDb"></param>
        public ProductRepo(ECommerceApplicationContext ShoppingCartDb)
        {
            _dbContext = ShoppingCartDb;
        }
        #endregion


        #region DeleteProduct
        /// <summary>
        /// Method for deleting product
        /// </summary>
        /// <param name="ProductId"></param>
        /// <returns></returns>
        public string DeleteProduct(int ProductId)
        {
            string msg = "";
            Product delete = _dbContext.Product.Find(ProductId);//storing the details of the Product in the obj 
            try
            {
                if (delete != null)
                {
                    _dbContext.Product.Remove(delete);
                    _dbContext.SaveChanges();
                    msg = "Deleted";
                }
            }
            catch (Exception)
            {
                throw;
            }
            return msg;
        }
        #endregion


        #region GetAllProduct
        /// <summary>
        /// Method to get all the product
        /// </summary>
        /// <returns></returns>
        public List<Product> GetAllProduct()
        {

            List<Product> product = _dbContext.Product.ToList();
            return product;
        }
        #endregion


        #region GetProduct
        /// <summary>
        /// Method to get product by id
        /// </summary>
        /// <param name="ProductId"></param>
        /// <returns></returns>
        public Product GetProduct(int ProductId)
        {
            try
            {   
                Product product = _dbContext.Product.Find(ProductId);
                return product;
            }
            catch (Exception)
            {
                throw;
            }
        }
        #endregion


        #region SaveProduct
        /// <summary>
        /// Method to save the product details
        /// </summary>
        /// <param name="Product"></param>
        /// <returns></returns>
        public string SaveProduct(Product Product)
        {
            try
            {
                _dbContext.Product.Add(Product);
                _dbContext.SaveChanges();
            }
            catch (Exception)
            {
                throw;
            }
            return "Saved";
        }
        #endregion


        #region UpdateProduct
        /// <summary>
        /// Method to Update product details
        /// </summary>
        /// <param name="Product"></param>
        /// <returns></returns>
        public string UpdateProduct(Product Product)
        {
            try
            {
                _dbContext.Entry(Product).State = EntityState.Modified;
                _dbContext.SaveChanges();
            }
            catch (Exception)
            {
                throw;
            }
            return "Updated";
        }
        #endregion
    }
}
