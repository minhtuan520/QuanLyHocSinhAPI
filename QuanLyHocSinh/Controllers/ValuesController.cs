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
        public List<Account> Get()
        {
            QuanLyHocSinhSqlContext context = new QuanLyHocSinhSqlContext();
            var test = context.Account.Take(5).ToList();
            if (test.Count == 5)
            {
                List<Account> result = new List<Account>();
                result.Add(test[0]);
                result.Add(test[1]);
                result.Add(test[2]);
                result.Add(test[3]);
                result.Add(test[4]);

                return result;
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
