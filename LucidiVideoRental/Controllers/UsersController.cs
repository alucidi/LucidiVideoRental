using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using LucidiVideoRental.Services;
using LucidiVideoRental.Models;

namespace LucidiVideoRental.Controllers
{
    public class UsersController : ApiController
    {

        private UserRepository userrepository;
        
        private const string CacheKey = "UserStore";

        public UsersController()
        {
            this.userrepository = new UserRepository();
        }
        
        
        // GET: api/Videos

        public IEnumerable<User> Get()
        {

            return userrepository.GetUsers();
        }

        // GET: api/Videos/5
        [HttpGet]
        public HttpResponseMessage Get(int id)
        {

            var product = userrepository.GetUsers().FirstOrDefault((p) => p.id == id);

            if (product == null)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }

            return Request.CreateResponse(HttpStatusCode.OK, product);
        }

        // POST: api/Videos
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Videos/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Videos/5
        public void Delete(int id)
        {
        }

    }
}
