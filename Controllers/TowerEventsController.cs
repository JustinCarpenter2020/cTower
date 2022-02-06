using System;
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
            catch (Exception e)
            {
                
                return BadRequest(e.Message);
            }
        }

        [HttpGet("{id}")]

        public ActionResult<TowerEvent> getEventById(int id) {
            try
            {
                return Ok(_service.getEventById(id));
            }
            catch (Exception e)
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
            catch (Exception e)
            {
                
                return BadRequest(e.Message);
            }
        }

        // [HttpPut]

        // public actionResult<TowerEvent> EditEvent([FromBody] TowerEvent editableTowerEvent)
        // {
        //     try
        //     {
            
        //     }
        //     catch (System.Exception ex)
        //     {
                
        //        return BadRequest(ex.message);
        //     }
        // }


        


    }
}