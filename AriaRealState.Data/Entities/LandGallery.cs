using System;
using System.Collections.Generic;
using System.Text;

namespace AriaRealState.Data.Entities;

public class LandGallery : BaseEntity
{
    public long LandId { get; set; }
    public required string FilePath { get; set; }

    public Land Land { get; set; }
}
