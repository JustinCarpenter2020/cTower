using System.Collections.Generic;
using cTower.Models;
using cTower.Services;
using Microsoft.AspNetCore.Mvc;

namespace cTower.Controllers
{
      [ApiController]
    [Route("api/[controller]")]
    public class TowerEventsController : ControllerBase
    {
        private readonly TowerEventService _service;
        public TowerEventsController(TowerEventService service){
            _service = service;
        }

        [HttpGet]
        public ActionResult<IEnumerable<TowerEvent>>  getAllEvents(){
            try
            {
                return Ok(_service.getAllEvents());
            }
            catch (System.Exception e)
            {
                
                return BadRequest(e.Message);
            }
        }


        [HttpPost]
        public ActionResult<TowerEvent> createEvent([FromBody] TowerEvent towerEvent) {
            try
            {
                return Ok(_service.createEvent(towerEvent));
            }
            catch (System.Exception e)
            {
                
                return BadRequest(e.Message);
            }
        }


    }
}