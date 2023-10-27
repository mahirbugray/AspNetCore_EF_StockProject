using AspNetCoreMvc_EF_Stock.Models;
using AspNetCoreMvc_EF_Stock.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace AspNetCoreMvc_EF_Stock.Controllers
{
    public class ProductController : Controller
    {
        ProductRepository _productRepo = new ProductRepository();
        CategoryRepository _categoryRepo = new CategoryRepository();

        public IActionResult List(int? id, string search)
        {
            var products = _productRepo.GetAllProducts();
            if (id != null)
            {
                products = products.Where(p => p.CategoryId == id).ToList();
            }

            if (search != null)
            {
                products = products.Where(p => p.Name.ToLower().Contains(search.ToLower())).ToList();
            }

            return View(products);
        }
        public IActionResult Details(int id)
        {
            Product product = _productRepo.GetById(id);
            return View(product);
        }
        public IActionResult Index(int? id)
        {
            var products = _productRepo.GetAllProducts();
            if(id != null)
            {
                products = products.Where(p => p.CategoryId == id).ToList();
            }
            return View(products);
        }
        public IActionResult Create()
        {
            //O an tarayıcının adres satırında bulunan url'in bilgilerini RouteData sınıfıyla çekebiliriz.
            //var controllerName = RouteData.Values["controller"];
            //var actionName = RouteData.Values["action"];
            //var parameterValue = RouteData.Values["id"];
            //Url adresindeki queryString ifadesindeki verileri çekmemizi sağlar.
            //var queryData = HttpContext.Request.Query["name"];

            ViewBag.Categories = new SelectList(_categoryRepo.GetAllCategories(), "Id", "Name");
            return View();
        }
        [HttpPost]
        public IActionResult Create(Product model, IFormFile formFile)
        {
            var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\images", formFile.FileName);

            var stream = new FileStream(path, FileMode.Create);

            formFile.CopyTo(stream);

            model.ImageUrl = "/images/" + formFile.FileName;
            _productRepo.Add(model);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var product = _productRepo.GetById(id);
            ViewBag.Categories = new SelectList(_categoryRepo.GetAllCategories(), "Id", "Name");
            return View(product);
        }
        [HttpPost]
        public IActionResult Edit(Product model)
        {
            _productRepo.Update(model); //formdan gelen Category nesnesini kullanarak veritabanındaki category bilgilerini günceller.
            return RedirectToAction("Index");
        }
        public IActionResult Delete(int id)
        {
            var product = _productRepo.GetById(id);
            _productRepo.Delete(product);
            return RedirectToAction("Index");
        }
    }
}
