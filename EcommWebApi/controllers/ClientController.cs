using Ecommerce.App_Code;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace EcommWebApi.controllers
{
    public class ClientController : ApiController
    {
        // GET: api/Client
        public List<Client> Get()
        {
            return Client.GetAll();
        }

        // GET: api/Client/5
        public Client Get(int id)
        {
            return Client.GetById(id);
        }

        // POST: api/Client
        public void Post([FromBody] Client data)
        {
            data.ClientId = -1;
            data.Save();
        }

        // PUT: api/Client/5
        public void Put(int id, [FromBody] Client data)
        {
            data.ClientId = id;
            data.Save();
        }

        // DELETE: api/Client/5
        public void Delete(int id)
        {
            Client.Delete(id);
        }
    }
}
