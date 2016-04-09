using System.Linq;
using Microsoft.AspNet.Mvc;
using Microsoft.AspNet.Mvc.Rendering;
using Microsoft.Data.Entity;
using OpenBiz.Models;

namespace OpenBiz.Controllers
{
    public class ProController : Controller
    {
        private SCMSContext _context;

        public ProController(SCMSContext context)
        {
            _context = context;    
        }

        // GET: Products
        public IActionResult Index()
        {
            var sCMSContext = _context.Products.Include(p => p.Category);
            return View(sCMSContext.ToList());
        }

        // GET: Products/Details/5
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }

            Product product = _context.Products.Single(m => m.ProductID == id);
            if (product == null)
            {
                return HttpNotFound();
            }

            return View(product);
        }

        // GET: Products/Create
        public IActionResult Create()
        {
            ViewData["CategoryID"] = new SelectList(_context.ProductCategories, "CategoryID", "Category");
            ViewData["WarehouseID"] = new SelectList(_context.Warehouses, "WarehouseID", "Warehouse");
            return View();
        }

        // POST: Products/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Product product)
        {
            if (ModelState.IsValid)
            {
                _context.Products.Add(product);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewData["CategoryID"] = new SelectList(_context.ProductCategories, "CategoryID", "Category", product.CategoryID);
            return View(product);
        }

        // GET: Products/Edit/5
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }

            Product product = _context.Products.Single(m => m.ProductID == id);
            if (product == null)
            {
                return HttpNotFound();
            }
            ViewData["CategoryID"] = new SelectList(_context.ProductCategories, "CategoryID", "Category", product.CategoryID);
            return View(product);
        }

        // POST: Products/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Product product)
        {
            if (ModelState.IsValid)
            {
                _context.Update(product);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewData["CategoryID"] = new SelectList(_context.ProductCategories, "CategoryID", "Category", product.CategoryID);
            return View(product);
        }

        // GET: Products/Delete/5
        [ActionName("Delete")]
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }

            Product product = _context.Products.Single(m => m.ProductID == id);
            if (product == null)
            {
                return HttpNotFound();
            }

            return View(product);
        }

        // POST: Products/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            Product product = _context.Products.Single(m => m.ProductID == id);
            _context.Products.Remove(product);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
