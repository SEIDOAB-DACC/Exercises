using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

using Seido.Utilities.SeedGenerator;

using Models;
using Services;
using Configuration;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace AppWebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class csAdminController : Controller
    {

        private IAnimalsService _service = null;

        //GET: api/csAdmin/Info
        [HttpGet()]
        [ActionName("Info")]
        [ProducesResponseType(200, Type = typeof(csConfAddress))]
        [ProducesResponseType(400, Type = typeof(string))]
        public async Task<IActionResult> Info()
        {
            try
            {
                return Ok(csAppConfig.Address);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
           
        }

        //GET: api/csAdmin/AfricanAnimals
        [HttpGet()]
        [ActionName("AfricanAnimals")]
        [ProducesResponseType(200, Type = typeof(csAnimal))]
        [ProducesResponseType(400, Type = typeof(string))]
        public async Task<IActionResult> AfricanAnimals(string count = "5")
        {
            try
            {
                int _count = int.Parse(count);

                var animals = _service.AfricanAnimals(_count);

                return Ok(animals);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
           
        }



        //GET: api/csAdmin/AfricanAnimals
        [HttpGet()]
        [ActionName("Singleton")]
        [ProducesResponseType(200, Type = typeof(csSingleton))]
        [ProducesResponseType(400, Type = typeof(string))]
        public async Task<IActionResult> Singleton()
        {
            try
            {
                var si = csSingleton.Instance;

                return Ok(si);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
           
        }

        public csAdminController(IAnimalsService service)
        {
            _service = service;
        }
    }
}

