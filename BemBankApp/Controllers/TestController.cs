﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace BemBankApp.Controllers
{
    public class TestController : ApiController
    {
        // GET: api/Test
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/Test/5
        public string Get(int id)
        {
            return "value " + id.ToString();
        }

        public string Get(int id, string isim)
        {
            return "value " + id.ToString() + " " + isim;
        }

        // POST: api/Test
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Test/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Test/5
        public void Delete(int id)
        {
        }

    }
}
