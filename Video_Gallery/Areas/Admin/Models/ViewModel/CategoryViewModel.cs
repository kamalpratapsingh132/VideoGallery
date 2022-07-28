using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Video_Gallery.Areas.Admin.Models.ViewModel
{
    public class CategoryViewModel
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }

        public IFormFile Image { get; set; }

        public string OldImage { get; set; }

        public bool IsActive { get; set; }
    }
}

