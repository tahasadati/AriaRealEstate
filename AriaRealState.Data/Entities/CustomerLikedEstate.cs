using AriaRealState.Data.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace AriaRealState.Data.Entities
{
    public class CustomerLikedEstate : BaseEntity
    {
        public long? VillaId { get; set; }
        public long? LandId { get; set; }
        public long CustomerId { get; set; }
        public string CreatedByUserId { get; set; }

        public Villa? Villa { get; set; }
        public Land? Land { get; set; }
        public Customer Customer { get; set; }
        public iUser iUser { get; set; }
    }
}
