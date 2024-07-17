using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SeamenResto.Data;
using SeamenResto.Models;

namespace SeamenResto.Controllers
{
    public class OrderController : Controller
    {
        private readonly RestoDb _db;

        public OrderController(RestoDb db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            var orders = _db.Orders.ToList();
            return View(orders);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CreateOrder(OrderEntity newOrder)
        {
            if (ModelState.IsValid)
            {
                _db.Orders.Add(newOrder);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(newOrder);
        }

        public IActionResult Update(int id)
        {
            var existingOrder = _db.Orders.Find(id);

            if (existingOrder == null)
            {
                return NotFound();
            }

            return View(existingOrder);
        }

        [HttpPost]
        public IActionResult UpdateOrder(OrderEntity updatedOrder)
        {
            if (ModelState.IsValid)
            {
                var existingOrder = _db.Orders.AsNoTracking().FirstOrDefault(o => o.Id == updatedOrder.Id);
                if (existingOrder != null)
                {
                    // If the image is not updated, keep the existing image
                    if (string.IsNullOrEmpty(updatedOrder.Img))
                    {
                        updatedOrder.Img = existingOrder.Img;
                    }

                    _db.Orders.Update(updatedOrder);
                    _db.SaveChanges();
                    return RedirectToAction("Index");
                }
                return NotFound();
            }
            return View(updatedOrder);
        }

        public IActionResult Delete(int id)
        {
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
}