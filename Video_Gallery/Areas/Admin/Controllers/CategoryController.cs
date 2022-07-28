using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Video_Gallery.Areas.Admin.Models;
using Video_Gallery.Areas.Admin.Models.ViewModel;
using Video_Gallery.Repository;
using Video_Gallery.Repository.Contract;

namespace Video_Gallery.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CategoryController : Controller
    {
        public readonly ICategory CategoryServices;


        private readonly IHostingEnvironment environment;

        
        public CategoryController(ICategory _category,
            IHostingEnvironment _environment)
        {
            CategoryServices = _category;
            environment = _environment;
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]       
        public IActionResult Create(CategoryViewModel model)
        {
            var path = environment.WebRootPath;
            var filepath = "Content/Images/" + model.Image.FileName;
            var fullpath = Path.Combine(path, filepath);
            CategoryServices.UploadFile(model.Image,fullpath);
            var category = new Category()
            {
                Name = model.Name,
                IsActive = model.IsActive,
                Created_On = DateTime.Now,
                Image = filepath

            };
            CategoryServices.CreateCategory(category);
            return RedirectToAction("ShowAllCategory"); ;
        }

        [Area("Admin")]
        public IActionResult ShowAllCategory()
        {
            var cats = CategoryServices.GetCategories();
            return View(cats);
        }

        public IActionResult Delete(int id)
        {
            var result = CategoryServices.DeleteCategory(id);
            if (result)
            {
                return RedirectToAction("ShowCategory");
            }
            else
            {
                ViewBag.message = "Category not found !";
                return RedirectToAction("ShowCategory");
            }

        }

        public IActionResult Edit(int id)
        {
            var cats = CategoryServices.GetCategoryById(id);
            var cat2 = new CategoryViewModel()
            {
                Id = cats.Id,
                OldImage = cats.Image,
                IsActive = cats.IsActive,
                Name = cats.Name
            };

            return View(cat2);
        }

        [HttpPost]
        public IActionResult Edit(CategoryViewModel model)
        {
            var cat = CategoryServices.GetCategoryById
                (model.Id);
            var path = environment.WebRootPath;
            var filepath = "Content/Images/" + model.Image.FileName;
            var fullpath = Path.Combine(path, filepath);
            CategoryServices.UploadFile(model.Image, fullpath);
            if (cat != null)
            {
                  //update
                cat.Name = model.Name;
                cat.IsActive = model.IsActive;
                cat.Updated_On = DateTime.Now;
                cat.Image = filepath;

                CategoryServices.UpdateCategory(cat);
                return RedirectToAction("ShowAllCategory");

            }
            else
            {
                //do not update
                ViewBag.message = "Category not found!";
                return View();
            }
        }
    }
}
