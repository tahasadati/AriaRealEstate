using System;
using System.Collections.Generic;
using System.Text;

namespace AriaRealState.Data.Entities
{
    public class UserActivity : BaseEntity
    {
        public long UserId { get; set; }
        public long CustomerId { get; set; }
        public required string Description { get; set; }
        public DateTime? RemindDate { get; set; }
        public required string ActivityTitle { get; set; }
        public required bool IsDone { get; set; } = true;
    }
}
