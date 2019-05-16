using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using LucidiVideoRental.Models;

namespace LucidiVideoRental.Controllers
{
    public class VideosController : ApiController
    {
        private Video[] videos = new Video[]
            {
        new Video { id = 1, name = "Transformers",category="Action"},
        new Video { id = 2, name = "Powder",category="Drama"},
        new Video { id = 3, name = "Lost In Translation",category="Comedy"},
        new Video { id = 4, name = "Iron Man",category="Action"},
        new Video { id = 5, name = "My Best Friends Wedding",category="Romantic Comedy"}
            };

        // GET: api/Videos

        public IEnumerable<Video> Get()
        {
            return videos;
        }

        // GET: api/Videos/5
        [HttpGet]
        public HttpResponseMessage Get(int id)
        {

            var product = videos.FirstOrDefault((p) => p.id == id);

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
