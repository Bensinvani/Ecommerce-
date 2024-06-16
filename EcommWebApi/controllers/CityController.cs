using Ecommerce.App_Code.BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace EcommWebApi.controllers
{
    public class CityController : ApiController
    {
        // GET: api/City
        public List<City> Get()
        {
            return City.GetAll();
        }

        // GET: api/City/5
        public City Get(int id)
        {
            return City.GetById(id);
        }

        // POST: api/City
        public void Post([FromBody] City data)
        {
            data.CityId = -1;
            data.Save();
        }

        // PUT: api/City/5
        public void Put(int id, [FromBody] City data)
        {
            data.CityId = id;
            data.Save();
        }

        // DELETE: api/City/5
        public void Delete(int id)
        {
            City.Delete(id);
        }
    }
}
