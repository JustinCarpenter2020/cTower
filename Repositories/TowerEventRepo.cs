using System;
using System.Collections.Generic;
using System.Data;
using cTower.Models;
using Dapper;

namespace cTower.Repositories
{
  public class TowerEventRepo
  {

      private readonly IDbConnection _db;

      public TowerEventRepo(IDbConnection db){
          _db = db;
      }
    internal IEnumerable<TowerEvent> getAllEvents()
    {
      string sql = "SELECT * FROM towerevents";
      return _db.Query<TowerEvent>(sql);
    }

    internal TowerEvent createEvent(TowerEvent towerEvent)
    {
      string sql = @"
      INSERT INTO towerevents
      (name, description, tickets, price, imgUrl, location, status, type)
      VALUES
      (@Name, @Description, @Tickets, @Price, @ImgUrl, @Location, @Status, @Type);
      SELECT LAST_INSERT_ID();";
      towerEvent.Id = _db.ExecuteScalar<int>(sql);
      return towerEvent;
    }
  }
}