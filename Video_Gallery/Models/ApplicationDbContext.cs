using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Video_Gallery.Areas.Admin.Models;

namespace Video_Gallery.Models
{
    public class ApplicationDbContext : IdentityDbContext<IdentityCustomerUser>
    {
        public ApplicationDbContext
         (DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<Category> Categories { get; set; }
    }
}
