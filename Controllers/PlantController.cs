using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PlantShop.Models;

namespace PlantShop.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlantController : ControllerBase
    {
        public DatabaseContext db { get; set; } = new DatabaseContext();


        //get all plants in inventory with location
        // [HttpGet("all plants")]
        // public List<Plant> GetAllPlants()
        // {
        //     var plants = db.Plants.OrderBy(m => m.Name);
        //     return plants.ToList();
        // }
        [HttpGet("{LocationID}")]
        public List<Plant> GetAllPlants(int LocationID)
        {
            var allplants = db.Plants.OrderBy(m => m.Name).Where(z => z.LocationID == LocationID);
            return allplants.ToList();
        }


        //get an individual plant with location
        // [HttpGet("{id} location")]
        // public Plant GetOnePlant(int id)
        // {
        //     var item = db.Plants.FirstOrDefault(i => i.Id == id);
        //     return item;
        // }
        [HttpGet("{id}/{LocationID}")]
        public Plant GetOnePlant(int id, int LocationID)
        {
            var item = db.Plants.FirstOrDefault(i => i.Id == id);
            return item;
        }


        //post/add a new plant to inventory with location
        // [HttpPost]
        // public Plant CreatePlant(Plant item)
        // {
        //     db.Plants.Add(item);
        //     db.SaveChanges();
        //     return item;
        // }
        [HttpPost]
        public Plant CreatePlant(Plant item, int LocationID)
        {
            db.Plants.Add(item);
            db.SaveChanges();
            return item;
        }


        //put allows plant update
        // [HttpPut("{id}")]
        // public Plant UpdateOneItem(int id)
        // {
        //     var item = db.Plants.FirstOrDefault(i => i.Id == id);
        //     item.NumberInStock += 5;
        //     db.SaveChanges();
        //     return item;
        // }
        [HttpPut("{id}/{LocationID}")]
        public Plant UpdateOneItem(int id, Plant newData, int LocationID)
        {
            newData.Id = id;
            db.Entry(newData).State = EntityState.Modified;
            db.SaveChanges();
            return newData;
        }


        //delete an item from a location
        // [HttpDelete("{id}")]
        // public ActionResult DeleteOne(int id)
        // {
        //     var item = db.Plants.FirstOrDefault(f => f.Id == id);
        //     if (item == null)
        //     {
        //         return NotFound();
        //     }
        //     db.Plants.Remove(item);
        //     db.SaveChanges();
        //     return Ok();
        // }
        [HttpDelete("{id}/{LocationID}")]
        public ActionResult DeleteOne(int id, int LocationID)
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
        // [HttpGet("plantsout")]
        // public List<Plant> PlantsOutOfStock()
        // {
        //     var outOfStock = db.Plants.Where(i => i.NumberInStock == 0);
        //     foreach (var plant in outOfStock)
        //     {
        //         Console.WriteLine($"{plant.Name}");
        //     }
        //     return outOfStock.ToList();
        // }
        [HttpGet("plantsout")]
        public List<Plant> PlantsOutOfStock(int NumberInStock)
        {
            var outOfStock = db.Plants.Where(i => i.NumberInStock == 0);
            foreach (var plant in outOfStock)
            {
                Console.WriteLine($"{plant.Name}");
            }
            return outOfStock.ToList();
            //maybe get rid of the foreach loop and just return outOfStock.ToList()

        }


        //get all items that are out of stock for location
        // [HttpGet("plantsout location")]
        // public List<Plant> PlantsOutOfStockLocation()
        // {
        //     var outOfStock = db.Plants.Where(i => i.NumberInStock == 0);
        //     foreach (var plant in outOfStock)
        //     {
        //         Console.WriteLine($"{plant.Name}");
        //     }
        //     return outOfStock.ToList();
        // }
        [HttpGet("plantsout/{LocationID}")]
        public List<Plant> PlantsOutOfStockLocation(int NumberInStock, int LocationID)
        {
            var outOfStocklocation = db.Plants.Where(i => i.NumberInStock == 0).Where(z => z.LocationID == LocationID);
            foreach (var plant in outOfStocklocation)
            {
                Console.WriteLine($"{plant.Name}");
            }
            return outOfStocklocation.ToList();
            //maybe get rid of the foreach loop and just return outOfStocklocation.ToList()
        }


        //get search items based on sku
        // [HttpGet("sku/{SKU}")]
        // public List<Plant> GetBySku()
        // {
        //     var plants = db.Plants.OrderBy(m => m.SKU);
        //     return plants.ToList();
        // }
        [HttpGet("sku/{SKU}")]
        public List<Plant> GetBySku(string SKU)
        {
            var plants = db.Plants.Where(m => m.SKU == SKU);
            return plants.ToList();
        }
    }
}