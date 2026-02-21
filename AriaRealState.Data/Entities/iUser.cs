using AriaRealState.Data.Entities;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace AriaRealState.Data.Entities
{
    public class iUser : IdentityUser
    {
        public required string FullName { get; set; }
        public required string UserImage { get; set; } = "Admin.png";
        public required DateTime RegisterDate { get; set; } = DateTime.Now;

        public ICollection<CustomerLikedEstate> CustomerLikedEstates { get; set; }
        public ICollection<Land> Lands { get; set; }
        public ICollection<Villa> Villas { get; set; }
    }
}
