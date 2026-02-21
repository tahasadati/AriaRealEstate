using AriaRealState.Data.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace AriaRealState.Data.Entities
{
    public class Customer : BaseEntity
    {
        public required string FullName { get; set; }
        public required string Phone { get; set; }
        public string? Address { get; set; }
        public string? Phone2 { get; set; }
        public string? Note { get; set; }
        public required long CreateByUserId { get; set; }

        public ICollection<CallRequest> CallRequests { get; set; }
        public ICollection<CustomerLikedEstate> CustomerLikedEstates { get; set; }
    }
}
