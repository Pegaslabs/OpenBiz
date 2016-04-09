using System;
using System.Text;
using System.Security.Cryptography;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNet.Mvc;
using OpenBiz.Models;
using OpenBiz.Models.Core.Repositories;
using Microsoft.Extensions.Logging;
using OpenBiz.ViewModels;
using AutoMapper;
using Microsoft.AspNet.Http;
using System.IO;
using Microsoft.Extensions.PlatformAbstractions;
using Microsoft.Net.Http.Headers;

namespace OpenBiz.Controllers.Web
{
    public class ProductsController : Controller
    {
        private ILogger<ProductsController> _logger;
        private IProductRepository _products;
        private IRepository<Warehouse> _warehouses;
        private IRepository<ProductCategory> _categories;
        private IApplicationEnvironment _appEnvironment;
        private IRepository<ProductImage> _images;
        private IMapper _mapper;

        public ProductsController(IApplicationEnvironment appEnvironment, IProductRepository products, IRepository<Warehouse> warehouses, IRepository<ProductCategory> categories, IRepository<ProductImage> images, ILogger<ProductsController> logger, IMapper mapper)
        {
            _products = products;
            _warehouses = warehouses;
            _categories = categories;
            _images = images;
            _appEnvironment = appEnvironment;
            _logger = logger;
            _mapper = mapper;
        }

        public IActionResult Index()
        {
            try
            {
                ViewData["ProductImages"] = _images.GetAll().ToList().GetEnumerator();
                return View(_products.GetAll().ToList());
            }
            catch (Exception ex)
            {
                _logger.LogDebug(ex.Message);
                throw;
            }

        }

        public IActionResult Create()
        {
            try
            {
                ProductViewModel p = new ProductViewModel()
                {
                    Categories = _categories.GetAll().ToList(),
                };

                return View(p);
            }
            catch (Exception ex)
            {
                _logger.LogDebug(ex.Message);
                throw;
            }

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(ProductViewModel product, IFormFile ProductImage)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    string FileName = "";
                    string FileExtension = "";
                    MD5 Hash = MD5.Create();
                    if (ProductImage != null && ProductImage.Length > 0)
                    {
                        //Get File Extension from Uploaded file's path
                        var parsedContentDisposition = ContentDispositionHeaderValue.Parse(ProductImage.ContentDisposition);
                        string FilePath = parsedContentDisposition.FileName.Trim('"'); //remove double quotes from the file's path
                        FileExtension = Path.GetExtension(FilePath);

                        //Web app's base path + product images folder'path defined in config.json + a new folder for product 
                        var uploadDir = _appEnvironment.ApplicationBasePath + Startup.Configuration["StaticFiles:ProductImages"].Replace(@"\\", @"/") + product.ProductName + @"/";

                        if (!Directory.Exists(uploadDir))//folder creation for new product 
                        {
                            Directory.CreateDirectory(uploadDir);
                        }

                        //convert product name into bytes for md5 conversion
                        byte[] Bytes = UTF8Encoding.UTF8.GetBytes(product.ProductName);
                        FileName = string.Concat(Hash.ComputeHash(Bytes).Select(x => x.ToString("X2"))); //convert md5 string to a hex string.
                        var imageUrl = uploadDir + FileName + FileExtension;
                        ProductImage.SaveAs(imageUrl);
                    }
                    var newProduct = _mapper.Map<Product>(product);
                    _products.Add(newProduct);
                    if (_products.SaveAll())
                    {
                        ProductImage image = new ProductImage();
                        image.Hash = FileName;
                        image.Extension = FileExtension;
                        image.ProductID = newProduct.ProductID;
                        _images.Add(image);
                        if (_images.SaveAll())
                        {
                            return RedirectToAction("Index");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                _logger.LogDebug(ex.Message);
                throw;
            }
            ProductViewModel p = new ProductViewModel()
            {
                Categories = _categories.GetAll().ToList(),
            };
            return View(p);
        }

        public IActionResult Edit(string param)
        {
            try
            {
                param = param.Replace("-", " ");
                var product = _products.Find(x => x.ProductName == param).Single();
                ViewData["Id"] = product.ProductID;
                ProductViewModel p = new ProductViewModel();
                var Product = _mapper.Map<ProductViewModel>(product);
                Product.Categories = _categories.GetAll().ToList();
                return View(Product);
            }
            catch (Exception ex)
            {
                _logger.LogDebug(ex.Message);
                throw;
            }

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(ProductViewModel product, int id, IFormFile ProductImage)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var Product = _products.Find(x => x.ProductID == id).Single();
                    string tempName = Product.ProductName; //for deleting directory if name has been changed.
                    Product = _mapper.Map<Product>(product);
                    string FileName = "";
                    string FileExtension = "";
                    MD5 Hash = MD5.Create();
                    if (ProductImage != null && ProductImage.Length > 0)
                    {
                        var parsedContentDisposition = ContentDispositionHeaderValue.Parse(ProductImage.ContentDisposition);
                        string FilePath = parsedContentDisposition.FileName.Trim('"');
                        FileExtension = Path.GetExtension(FilePath);
                        var uploadDir = _appEnvironment.ApplicationBasePath + Startup.Configuration["StaticFiles:ProductImages"].Replace(@"\\", @"/") + Product.ProductName + @"/";
                        if (!Directory.Exists(uploadDir))
                        {
                            //product name has been changed.
                            DirectoryInfo di = new DirectoryInfo(_appEnvironment.ApplicationBasePath + Startup.Configuration["StaticFiles:ProductImages"].Replace(@"\\", @"/") + tempName + @"/");

                            foreach (FileInfo file in di.GetFiles())
                            {
                                file.Delete();
                            }

                            //Delete old directory as the product name has been changed.
                            Directory.Delete(_appEnvironment.ApplicationBasePath + Startup.Configuration["StaticFiles:ProductImages"].Replace(@"\\", @"/") + tempName + @"/");
                            Directory.CreateDirectory(uploadDir);
                        }
                        else
                        {
                            //product name hasn't been changed.
                            DirectoryInfo di = new DirectoryInfo(uploadDir);

                            foreach (FileInfo file in di.GetFiles())
                            {
                                file.Delete();
                            }

                        }
                        byte[] Bytes = UTF8Encoding.UTF8.GetBytes(Product.ProductName);
                        FileName = string.Concat(Hash.ComputeHash(Bytes).Select(x => x.ToString("X2")));
                        var imageUrl = uploadDir + FileName + FileExtension;
                        ProductImage.SaveAs(imageUrl);
                    }
                    else if(Product.ProductName!=tempName)
                    {
                        string srcDir = _appEnvironment.ApplicationBasePath + Startup.Configuration["StaticFiles:ProductImages"].Replace(@"\\", @"/") + tempName + @"/";
                        string destDir = _appEnvironment.ApplicationBasePath + Startup.Configuration["StaticFiles:ProductImages"].Replace(@"\\", @"/") + Product.ProductName + @"/";
                        //rename directory if only product name has been changed
                        Directory.Move(srcDir, destDir);
                        Directory.Delete(srcDir);
                    }
                    //Insert id again after mapping 
                    Product.ProductID = id;
                    ProductImage image = _images.Find(m => m.ProductID == id).Single();
                    image.Hash = FileName;
                    image.Product = Product;
                    image.Extension = FileExtension;
                    image.ProductID = Product.ProductID;
                    _products.Update(Product);
                    _images.Update(image);
                    if (_products.SaveAll() && _images.SaveAll())
                    {
                        return RedirectToAction("Index");
                    }
                }

            }
            catch (Exception ex)
            {
                _logger.LogDebug(ex.Message);
                throw;
            }
            product.Categories = _categories.GetAll().ToList();
            return View(product);
        }

        [ActionName("Delete")]
        public IActionResult Delete(string param)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(param))
                {
                    return HttpNotFound();
                }

                param = param.Replace("-", " ");
                Product product = _products.Find(x => x.ProductName == param).Single();
                ProductImage image = _images.Find(x => x.ProductID == product.ProductID).Single();
                if (product == null)
                {
                    return HttpNotFound();
                }

                return View(product);
            }
            catch (Exception ex)
            {
                _logger.LogDebug(ex.Message);
                throw;
            }

        }

        // POST: Products1/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(string param)
        {
            param = param.Replace("-", " ");
            Product product = _products.Find(m => m.ProductName == param).Single();
            _products.Remove(product);
            _products.SaveAll();
            return RedirectToAction("Index");
        }

        [HttpPost("api/search/products")]
        public JsonResult GetProducts([FromBody]DTParameters param)
        {
            try
            {
                var dtsource = new List<Product>();
                dtsource = _products.GetAll().ToList();

                List<string> columnSearch = new List<string>();

                foreach (var col in param.Columns)
                {
                    columnSearch.Add(col.Search.Value);
                }

                List<Product> data = new ResultSet().GetResult(param.Search.Value, param.SortOrder, param.Start, param.Length, dtsource, columnSearch);
                int count = new ResultSet().Count(param.Search.Value, dtsource, columnSearch);
                DTResult<Product> result = new DTResult<Product>
                {
                    draw = param.Draw,
                    data = data,
                    recordsFiltered = count,
                    recordsTotal = count
                };
                return Json(result);
            }
            catch (Exception ex)
            {
                return Json(new { error = ex.Message });
            }
        }


    }
}