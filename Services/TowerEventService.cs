using System;
using System.Collections.Generic;
using cTower.Models;
using cTower.Repositories;

namespace cTower.Services
{
  public class TowerEventService
  {
    private readonly TowerEventRepo _repo;
    public TowerEventService(TowerEventRepo repo){
      _repo = repo;
    }
    public IEnumerable<TowerEvent> getAllEvents()
    {
      return _repo.getAllEvents();
    }

    public TowerEvent getEventById(int id)
    {
      return _repo.getEventById(id);
    }

    public TowerEvent createEvent(TowerEvent towerEvent)
    {
      return _repo.createEvent(towerEvent);
    }
  }
}