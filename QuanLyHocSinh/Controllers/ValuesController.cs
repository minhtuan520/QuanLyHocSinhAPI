using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using QuanLyHocSinh.DAL.Model;

namespace QuanLyHocSinh.Controllers
{    
    [Route("api/[controller]")]
    public class ValuesController : Controller
    {
        // GET api/values
        [HttpGet]
        public Account Get()
        {
            QuanLyHocSinhSqlContext context = new QuanLyHocSinhSqlContext();
            var test = context.Account.Where(a => a.Username == "HS00000010").Take(1).ToList();
            if (test.Count > 0)
            {
                return test[0];
            }
            else
            {
                return null;
            }
            
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
