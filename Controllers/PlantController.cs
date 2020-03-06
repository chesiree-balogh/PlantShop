using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PlantShop.Models;

namespace PlantShop.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlantController : ControllerBase
    {
        public DatabaseContext db { get; set; } = new DatabaseContext();


        //post/add new location
        [HttpPost]
        public Location CreateALocation(Location item)
        {
            db.Locations.Add(item);
            db.SaveChanges();
            return item;
        }


        //get all locations
        [HttpGet]
        public List<Location> GetAllLocations()
        {
            var locations = db.Locations.OrderBy(m => m.Address);
            return locations.ToList();
        }


        //get all plants in inventory
        [HttpGet]
        public List<Plant> GetAllPlants()
        {
            var plants = db.Plants.OrderBy(m => m.Name);
            return plants.ToList();
        }


        //get an individual plant
        [HttpGet("{id}")]
        public Plant GetOnePlant(int id)
        {
            var item = db.Plants.FirstOrDefault(i => i.Id == id);
            return item;
        }


        //post/add a new plant to inventory
        [HttpPost]
        public Plant CreatePlant(Plant item)
        {
            db.Plants.Add(item);
            db.SaveChanges();
            return item;
        }


        //put allows plant update
        [HttpPut("{id}")]
        public Plant UpdateOneItem(int id)
        {
            var item = db.Plants.FirstOrDefault(i => i.Id == id);
            item.NumberInStock += 5;
            db.SaveChanges();
            return item;
        }


        //delete an item
        [HttpDelete("{id}")]
        public ActionResult DeleteOne(int id)
        {
            var item = db.Plants.FirstOrDefault(f => f.Id == id);
            if (item == null)
            {
                return NotFound();
            }
            db.Plants.Remove(item);
            db.SaveChanges();
            return Ok();
        }


        //get all items that are out of stock
        [HttpGet("plantsout")]
        public List<Plant> PlantsOutOfStock()
        {
            var outOfStock = db.Plants.Where(i => i.NumberInStock == 0);
            foreach (var plant in outOfStock)
            {
                Console.WriteLine($"{plant.Name}");
            }
            return outOfStock.ToList();

            //var pets = db.Plants.OrderBy(m => m.Name);
            //return pets.ToList();
        }


        //get search items based on sku
        [HttpGet("sku/{SKU}")]
        public List<Plant> GetBySku()
        {
            var plants = db.Plants.OrderBy(m => m.SKU);
            return plants.ToList();
        }
    }
}