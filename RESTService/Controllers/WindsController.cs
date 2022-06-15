using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RESTService.Managers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace RESTService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WindsController : ControllerBase
    {
        //Internal reference to a manager
        private WindsManager _manager = new WindsManager();

        //Simply returns all wind data
        //Return a 204 if no sensors has send any data
        //Instead of 204 we could use 404, but that is seen as an error
        // GET: api/<WindsController>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [HttpGet]
        public ActionResult<IEnumerable<Wind>> Get()
        {
            IEnumerable<Wind> result = _manager.GetAll();
            if (result.Count() > 0)
            {
                return Ok(result);
            }
            else
            {
                return NoContent();
            }
        }

        //Adds a wind object, delegates the responsibility of added id to the manager
        //Here we use the 201 status code to tell the user that it has been created, but because we have no access to the specific sensordata, we just return the Uri to the get method
        // POST api/<WindsController>
        [ProducesResponseType(StatusCodes.Status201Created)]
        [HttpPost]
        public ActionResult Post([FromBody] Wind value)
        {
            _manager.Add(value);
            return Created("/api/speed", value);
        }
    }
}
