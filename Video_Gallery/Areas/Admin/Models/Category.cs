using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Video_Gallery.Areas.Admin.Models
{
    public class Category
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Image { get; set; }

        public DateTime? Created_On { get; set; }

        public DateTime? Updated_On { get; set; }

        public bool IsActive { get; set; }
    }
}
