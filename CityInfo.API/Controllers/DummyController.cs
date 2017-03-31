﻿using CityInfo.API.Entities;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CityInfo.API.Controllers
{
    public class DummyController : Controller
    {
        private CityInfoContext _cityInfoContext;

        public DummyController(CityInfoContext cityInfoContext)
        {
            _cityInfoContext = cityInfoContext;
        }

        [HttpGet]
        [Route("api/testdb")]
        public IActionResult TestDatabase()
        {
            return Ok();
        }
    }
}
