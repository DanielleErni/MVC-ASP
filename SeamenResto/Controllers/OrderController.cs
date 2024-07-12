using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SeamenResto.Data;
using SeamenResto.Models;

namespace SeamenResto.Controllers;

public class OrderController : Controller
{
    private RestoDb _db;
    
    public OrderController(RestoDb db)
    {
        _db = db;
    }

    public IActionResult Index(){
        var orders = _db.Orders.ToList();
        return View(orders);
    }

    
    public IActionResult Create(){
        return View();
    }

    [HttpPost]
    public IActionResult CreateOrder(OrderEntity neworder){
        _db.Orders.Add(neworder);
        _db.SaveChanges();

        return RedirectToAction("Index");
        
    }

    public IActionResult Update(int id){
        var existingOrder = _db.Orders.Find(id);

        if(existingOrder  == null){
            return NotFound();
        }

        return View(existingOrder);
    }

    [HttpPost]
    public IActionResult UpdateOrder(OrderEntity updatedOrder){

        if(ModelState.IsValid){
            _db.Orders.Update(updatedOrder);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }
        return View(updatedOrder);
    }

    //[HttpDelete]
    public IActionResult Delete(int id){
        var order = _db.Orders.Find(id);
        if (order == null)
        {
            return NotFound();
        }
        _db.Orders.Remove(order);
        _db.SaveChanges();
        return RedirectToAction("Index");
    }
    
}