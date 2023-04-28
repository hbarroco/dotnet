﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace JwtWithoutIdentity.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class ValuesController : ControllerBase
    {
        private readonly AppSettings _appSettings;

        public ValuesController(IOptions<AppSettings> options)
        {
            _appSettings = options.Value;
        }

        // GET api/values
        [HttpGet]
        [Authorize(Roles = "Administrator")]
        public ActionResult<IEnumerable<string>> Get()
        {
            var name = User.Identity.Name;
            var claims = User.Claims;

            return new string[] { "value1", "value2" };
        }

        // GET api/values/5
        [Authorize(Roles = "User")]
        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
