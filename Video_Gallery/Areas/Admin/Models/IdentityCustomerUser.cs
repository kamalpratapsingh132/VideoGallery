using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Video_Gallery.Areas.Admin.Models
{
    public class IdentityCustomerUser: IdentityUser
    {

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Gender { get; set; }

        public string Photo { get; set; }
    }
}
