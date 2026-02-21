using AriaRealState.Data.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace AriaRealState.Data.Entities
{
    public class CallRequest : BaseEntity
    {
        public required string Code { get; set; }  
        public required DateTime ReqDate { get; set; }
        public string? FullName { get; set; }
        public required string Phone { get; set; }
        public long? VillaId { get; set; }
        public long? LandId { get; set; }
        public required bool IsSeen { get; set; } = false;

        public Villa Villa { get; set; }
        public Land Land { get; set; }
    }
}
