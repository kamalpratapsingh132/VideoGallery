using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Video_Gallery.Areas.Admin.Models;

namespace Video_Gallery.Repository.Contract
{
    public interface ICategory
    {
        Category CreateCategory(Category category);
        List<Category> GetCategories();
        Category GetCategoryById(int id);
        Category UpdateCategory(Category category);
        bool DeleteCategory(int id);
        public void UploadFile(IFormFile file, string path);
    }
} 
