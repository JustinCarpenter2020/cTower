using System.Collections.Generic;
using cTower.Models;
using cTower.Services;
using Microsoft.AspNetCore.Mvc;

namespace cTower.Controllers
{
      [ApiController]
    [Route("api/[controller]")]
    public class TowerEventController : ControllerBase
    {
        private readonly TowerEventService _service;
        public TowerEventController(TowerEventService service){
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


    }
}