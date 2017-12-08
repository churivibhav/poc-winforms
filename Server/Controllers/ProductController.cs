using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using Data;

namespace Server.Controllers
{
    public class ProductController : ApiController
    {
        public Product Get(long id)
        {
            return new Product {Id = 1, Name = "ABC", SalesRate = 100.00m};
        }

        [HttpGet]
        public List<Product> Get()
        {
            return new List<Product>
            {
                new Product {Id = 1, Name = "ABC", SalesRate = 100.00m},
                new Product {Id = 2, Name = "DEF", SalesRate = 200.00m},
                new Product {Id = 4, Name = "XYZ", SalesRate = 300.00m},
                new Product {Id = 6, Name = "PQR", SalesRate = 400.00m},
            };
        }
    }
}
