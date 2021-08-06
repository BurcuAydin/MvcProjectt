using BusinessLayer.Concretes;
using BusinessLayer.ValidationRules;
using DataAccessLayer.Abstracts;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concretes;
using FluentValidation;
using FluentValidation.Results;
using System;
using System.Collections.Generic;

using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcProject.Controllers
{
    public class CategoryController : Controller
    {
        CategoryManager categoryManager = new CategoryManager(new EfCategoryDal());
        // GET: Category
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult GetCategoryList()
        {
            var categoryvalues = categoryManager.GetList();
            return View(categoryvalues);
        }
        [HttpGet]
        public ActionResult AddCategory()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddCategory(Category category)
        {
            //  categoryManager.CategoryAddBL(category);
            CategoryValidator categoryValidator = new CategoryValidator();
            //validation results ı tutacak
            ValidationResult results = categoryValidator.Validate(category);
            if (results.IsValid)
            {
                categoryManager.CategoryAddBL(category);
                return RedirectToAction("GetCategoryList");
            }
            else
                foreach (var item in results.Errors)
                {
                    ModelState.AddModelError(item.PropertyName,item.ErrorMessage);
                }
            return View();
        }
         
    }
}