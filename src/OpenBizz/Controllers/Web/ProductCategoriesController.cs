using System.Linq;
using Microsoft.AspNet.Mvc;
using Microsoft.AspNet.Mvc.Rendering;
using Microsoft.Data.Entity;
using OpenBiz.Models;

namespace OpenBiz.Controllers
{
    public class ProductCategoriesController : Controller
    {
        private SCMSContext _context;

        public ProductCategoriesController(SCMSContext context)
        {
            _context = context;    
        }

        // GET: ProductCategories
        public IActionResult Index()
        {
            return View(_context.ProductCategories.ToList());
        }

        // GET: ProductCategories/Details/5
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }

            ProductCategory productCategory = _context.ProductCategories.Single(m => m.CategoryID == id);
            if (productCategory == null)
            {
                return HttpNotFound();
            }

            return View(productCategory);
        }

        // GET: ProductCategories/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ProductCategories/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(ProductCategory productCategory)
        {
            if (ModelState.IsValid)
            {
                _context.ProductCategories.Add(productCategory);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(productCategory);
        }

        // GET: ProductCategories/Edit/5
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }

            ProductCategory productCategory = _context.ProductCategories.Single(m => m.CategoryID == id);
            if (productCategory == null)
            {
                return HttpNotFound();
            }
            return View(productCategory);
        }

        // POST: ProductCategories/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(ProductCategory productCategory)
        {
            if (ModelState.IsValid)
            {
                _context.Update(productCategory);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(productCategory);
        }

        // GET: ProductCategories/Delete/5
        [ActionName("Delete")]
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }

            ProductCategory productCategory = _context.ProductCategories.Single(m => m.CategoryID == id);
            if (productCategory == null)
            {
                return HttpNotFound();
            }

            return View(productCategory);
        }

        // POST: ProductCategories/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            ProductCategory productCategory = _context.ProductCategories.Single(m => m.CategoryID == id);
            _context.ProductCategories.Remove(productCategory);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
