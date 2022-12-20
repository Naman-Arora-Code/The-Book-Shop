using BookShopping_Project_130.DataAccess.Repository.IRepository;
using BookShopping_Project_130.Model;
using BookShopping_Project_130.Utility;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookShopping_Project_130.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles =SD.Role_User_Admin)]
    public class CategoryController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        public CategoryController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Upsert(int? id)
        {
            Category category = new Category();
            if(id==null)           
                return View(category); 
                var categoryInDb = _unitOfWork.Category.Get(id.GetValueOrDefault());
                return View(categoryInDb);                
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Upsert(Category category)
        {
            if (category == null)
                return NotFound();
            if(ModelState.IsValid)
            {
                if (category.Id == 0)
                    _unitOfWork.Category.Add(category);
                else
                    _unitOfWork.Category.Update(category);
                _unitOfWork.Save();
                return RedirectToAction(nameof(Index));
            }
            return View(category);
        }
        #region APIs
        [HttpGet]
        public IActionResult GetAll()
        {
         var categoryList= _unitOfWork.Category.GetAll();
            return Json(new {data=categoryList });
        }
        [HttpDelete]
        public IActionResult Delete(int id)
        {
         var categoryInDb=_unitOfWork.Category.Get(id);
            if (categoryInDb == null)
                return Json(new { success = false, message = "Error while delete data !!" });
            _unitOfWork.Category.Remove(categoryInDb);
            _unitOfWork.Save();
            return Json(new { success = true, message = "Data successfully deleted !!" });
        }
        #endregion

    }
}
