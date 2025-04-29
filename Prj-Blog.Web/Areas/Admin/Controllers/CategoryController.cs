using Microsoft.AspNetCore.Mvc;
using Prj_Blog.CoreLayer.DTOs.Category;
using Prj_Blog.CoreLayer.Services.Categorys;
using Prj_Blog.CoreLayer.Utilities;
using Prj_Blog.DataLayes.Entities;
using Prj_Blog.Web.Areas.Admin.Models.Categories;
using System.ComponentModel.Design.Serialization;

namespace Prj_Blog.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CategoryController : Controller
    {
        private readonly ICategoryService _catgory;

        public CategoryController(ICategoryService catgory)
        {
            _catgory = catgory;
        }

        public IActionResult Index()
        {
            return View(_catgory.GetAllCategory());
        }
        [Route("/admin/category/add/{parentid?}")]
        public IActionResult Add(int? parentid)
        {
           
            return View();
        }

        [HttpPost("/admin/category/add/{parentid?}")]

        public IActionResult Add(int? parentid, CreateCategoryViewModel createviewmodel)
        {
            createviewmodel.ParentId = parentid;
            var result = _catgory.CreateCategory(createviewmodel.MapToDto());
            if (result.Status != OperationResultStatus.Success)
            {
                ModelState.AddModelError(nameof(createviewmodel.Slug), result.Message);
                return View();
            }
            return RedirectToAction("Index");
        }
        public IActionResult Edit(int id)
        {
            var category = _catgory.GetCategoryBy(id);
            if (category == null) 
                return RedirectToAction("Index");

            var model = new EditCategoryViewModel()
            {
                Title = category.Title,
                Slug = category.Slug.ToSlug(),
                MetaTag = category.MetaTag,
                MetaDescription = category.MetaDescription,
            };
            return View(model);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]

        public  IActionResult Edit(int id,EditCategoryViewModel editmodel)
        {
            var resault = _catgory.EditCategory(new EditCategoryDto()
            {
                Title = editmodel.Title,
                Slug = editmodel.Slug.ToSlug(),
                MetaTag = editmodel.MetaTag,
                MetaDescription = editmodel.MetaDescription,
                 Id = id
            });
           if(resault.Status != OperationResultStatus.Success)
            {
                ModelState.AddModelError(nameof(editmodel.Slug),resault.Message);
                return View();
            }
            return RedirectToAction("Index");
        }

    }
}
