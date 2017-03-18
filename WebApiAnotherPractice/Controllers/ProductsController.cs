using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApiAnotherPractice.Models;

namespace WebApiAnotherPractice.Controllers
{
    public class ProductsController : ApiController
    {
        Product[] products = new Product[]
        {
            new Product {Id=1, Name="Tomato Soup", Category="Groceries", Price=1 },
            new Product {Id=2, Name="Yo-yo", Category="Toys", Price=3.75M },
            new Product {Id=3, Name="Hammer", Category="Hardware", Price=16.9M }
        };

        public IEnumerable<Product> GetAllProducts()
        {
            return products;
        }

        //public IHttpActionResult GetProduct(int id)
        //{
        //    var product = products.FirstOrDefault((p) => p.Id == id);
        //    if (product == null)
        //    {
        //        return NotFound();
        //    }
        //    return Ok(product);
        //}

        public Product GetProductById(int id)
        {
            var product = products.FirstOrDefault((p) => p.Id == id);
            if (product == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
            return product;
        }

        public IEnumerable<Product> GetProductsByCategory(string category)
        {
            return products.Where((p) => string.Equals(p.Category, category, StringComparison.OrdinalIgnoreCase));
        }
    }
}
