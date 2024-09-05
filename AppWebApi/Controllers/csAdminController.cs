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
        private ILogger<csAdminController> _logger = null;

        private IAnimalsService _service = null;
        private IAttractionService _aservice = null;

        //GET: api/csAdmin/Info
        [HttpGet()]
        [ActionName("Info")]
        [ProducesResponseType(200, Type = typeof(csConfAddress))]
        [ProducesResponseType(400, Type = typeof(string))]
        public async Task<IActionResult> Info()
        {
            try
            {
                _logger.LogInformation("Endpoint Info executed");
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
        [ProducesResponseType(200, Type = typeof(List<csAnimal>))]
        [ProducesResponseType(400, Type = typeof(string))]
        public async Task<IActionResult> AfricanAnimals(string count = "5")
        {
            try
            {
                _logger.LogInformation("Endpoint AfricanAnimals executed");
                int _count = int.Parse(count);

                var animals = _service.AfricanAnimals(_count);

                return Ok(animals);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
           
        }

        //GET: api/csAdmin/Attractions
        [HttpGet()]
        [ActionName("Attractions")]
        [ProducesResponseType(200, Type = typeof(List<csAttraction>))]
        [ProducesResponseType(400, Type = typeof(string))]
        public async Task<IActionResult> Attractions(string count = "5")
        {
            _logger.LogInformation("Endpoint Attractions executed");
           try
            {
                int _count = int.Parse(count);

                var s = new csAttractionService();
                var attractions = s.Attractions(_count);

                return Ok(attractions);
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
                _logger.LogInformation("Endpoint Singleton executed");
                var si = csSingleton.Instance;

                return Ok(si);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
           
        }

        //GET: api/csAdmin/log
        [HttpGet()]
        [ActionName("Log")]
        [ProducesResponseType(200, Type = typeof(IEnumerable<csLogMessage>))]
        public async Task<IActionResult> Log([FromServices] ILoggerProvider _loggerProvider)
        {
            //Note the way to get the LoggerProvider, not the logger from Services via DI
            if (_loggerProvider is csInMemoryLoggerProvider cl)
            {
                return Ok(await cl.MessagesAsync);
            }
            return Ok("No messages in log");
        }
        public csAdminController(IAnimalsService service, IAttractionService aservice, ILogger<csAdminController> logger)
        {
            _service = service;
            _aservice = aservice;
            _logger = logger;
        }
    }
}

