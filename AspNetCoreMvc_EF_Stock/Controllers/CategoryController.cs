using AspNetCoreMvc_EF_Stock.Models;
using AspNetCoreMvc_EF_Stock.Repositories;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics.Contracts;

namespace AspNetCoreMvc_EF_Stock.Controllers
{
    public class CategoryController : Controller
    {
        CategoryRepository _categoryRepo = new CategoryRepository();
        public IActionResult Index()
        {
            var categories = _categoryRepo.GetAllCategories();
            return View(categories);
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Category model)
        {
            _categoryRepo.Add(model); //formdan gelen Category nesnesini veritabanına ekler.
            return RedirectToAction("Index"); //Listeleme action'a geri döner.
        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var category = _categoryRepo.GetById(id);
            return View(category);
        }
        [HttpPost]
        public IActionResult Edit(Category model)
        {
            _categoryRepo.Update(model); //formdan gelen Category nesnesini kullanarak veritabanındaki category bilgilerini günceller.
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult Delete(int id)
        {
            //var category = _categoryRepo.GetById(id);
            //return View(category);
            var category = _categoryRepo.GetById(id);
            _categoryRepo.Delete(category);
            return RedirectToAction("Index");
        }
        //[HttpPost]
        //public IActionResult Delete(Category model)
        //{
        //    _categoryRepo.Delete(model); 
        //    return RedirectToAction("Index");
        //}
    }
}
