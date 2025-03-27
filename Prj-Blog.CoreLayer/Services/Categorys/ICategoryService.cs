using Prj_Blog.CoreLayer.DTOs.Category;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prj_Blog.CoreLayer.Services.Categorys
{
    public interface ICategoryService
    {
        void CreateCategory(CreateCategoryDto createdto);
        void EditCategory(EditCategoryDto createdto);
        List<CategoryDto> GetAllCategory();
        CategoryDto GetCategoryBy(int id);
        CategoryDto GetCategoryBy(string slug);
    }
}
