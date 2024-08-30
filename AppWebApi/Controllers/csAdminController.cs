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
        private const string seedSource = "./friends-seeds.json";

        //GET: api/musicgroups/seed?count={count}
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

        [HttpGet()]
        [ActionName("AfricanAnimals")]
        [ProducesResponseType(200, Type = typeof(csAnimal))]
        [ProducesResponseType(400, Type = typeof(string))]
        public async Task<IActionResult> AfricanAnimals(string count)
        {
            try
            {
                int _count = int.Parse(count);

                var fn = Path.GetFullPath(seedSource);
                var _seeder = new csSeedGenerator(fn);

                //var animal = new csAnimal().Seed(_seeder);

                var animals = _seeder.ItemsToList<csAnimal>(_count);
                return Ok(animals);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
           
        }
    }
}

