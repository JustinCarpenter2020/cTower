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
    internal IEnumerable<TowerEvent> getAllEvents()
    {
      return _repo.getAllEvents();
    }

    internal TowerEvent createEvent(TowerEvent towerEvent)
    {
      return _repo.createEvent(towerEvent);
    }
  }
}