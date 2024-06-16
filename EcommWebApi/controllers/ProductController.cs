using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using BLL;

namespace EcommWebApi.controllers
{
    public class ProductController : ApiController
    {
        // GET: api/v1/Product
        public List<Product> Get()
        {
            return Product.GetAll();
        }

        // GET: api/Product/5
        public Product Get(int id)
        {
            return Product.GetById(id);
        }

        // POST: api/Product
        public void Post([FromBody] Product Data)
        {
            Data.Pid = -1;
            Data.Save();
        }

        // PUT: api/Product/5
        public void Put(int id, [FromBody] Product Data)
        {
            Data.Pid = id;
            Data.Save();
        }

        // DELETE: api/Product/5
        public void Delete(int id)
        {
            Product.Delete(id);
        }
    }
}
