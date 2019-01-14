using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Blog.Core.Controllers
{

    using Blog.Core.Model.Models;
    using Blog.Core.IService; 

    [Route("api/[controller]")]
    [ApiController]
    public class BlogController : ControllerBase
    {
        protected readonly IAdvertisementServices advertisementServices;

        public BlogController(IAdvertisementServices services)
        {
            advertisementServices = services;
        }

        // GET: api/Blog
        [HttpGet]
        public IEnumerable<string> Get()
        { 
            return new string[] { "value1", "value2" };
        }

        // GET: api/Blog/5 
        [HttpGet("{id}", Name = "Get")]
        public async Task<List<Advertisement>> Get(int id)
        { 
            var list = await advertisementServices?.Query(w => w.Id == id);
            return  list;
        }

        // POST: api/Blog
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT: api/Blog/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
