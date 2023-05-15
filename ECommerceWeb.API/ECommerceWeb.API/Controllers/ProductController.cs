﻿using ECommerceWeb.API.Models;
using ECommerceWeb.API.Services;
using Microsoft.AspNetCore.Mvc;

namespace ECommerceWeb.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private ProductService _productServices;
        public ProductController(ProductService Product)
        {
            _productServices = Product;
        }
        [HttpPost("SaveProduct")]
        public IActionResult SaveProduct(Product Product)
        {
            return Ok(_productServices.SaveProduct(Product));
        }

        [HttpDelete("DeleteProduct")]
        public IActionResult DeleteProduct(int ProductId)
        {
            return Ok(_productServices.DeleteProduct(ProductId));
        }

        [HttpPut("UpdateProduct")]
        public IActionResult UpdateProducte(Product Product)
        {
            return Ok(_productServices.UpdateProduct(Product));
        }

        [HttpGet("GetProduct")]
        public IActionResult GetProduct(int ProductId)
        {
            return Ok(_productServices.GetProduct(ProductId));
        }

        [HttpGet("GetAllProduct()")]
        public List<Product> GetAllProduct()
        {
            return _productServices.GetAllProduct();
        }

    }
}
