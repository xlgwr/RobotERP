﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

// For more information on enabling Web API for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace RobotERP.WebApi.Controllers
{
    [Route("identity")]
    [Authorize]
    public class IdentityController : ControllerBase
    {
       
        [HttpGet]
        public IActionResult Get()
        {
            return new JsonResult(
                from c in User.Claims
                select new
                {
                    c.Type,
                    c.Value
                });
        }
    }
}
