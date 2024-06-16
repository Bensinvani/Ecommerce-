using BLL;
using Ecommerce.App_Code.BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace EcommWebApi.controllers
{
    public class CategoryController : ApiController
    {
        // GET: api/Category
        public List<Category> Get()
        {
            return Category.GetAll();
        }

        // GET: api/Category/5
        public Category Get(int id)
        {
            return Category.GetById(id);
        }

        // POST: api/Category
        public void Post([FromBody] Category data)
        {
            data.Cid = -1;
            data.Save();
        }

        // PUT: api/Category/5
        public void Put(int id, [FromBody] Category data)
        {
            data.Cid = id;
            data.Save();
        }

        // DELETE: api/Category/5
        public void Delete(int id)
        {
            Category.Delete(id);
        }
    }
}
