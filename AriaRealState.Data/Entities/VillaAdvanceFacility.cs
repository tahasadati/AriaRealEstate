
using AriaRealState.Data.Enums.Villa;
using System;
using System.Collections.Generic;
using System.Text;

namespace AriaRealState.Data.Entities;

public class VillaAdvanceFacility : BaseEntity
{
    public long VillaId { get; set; }
    public AdvanceFacilityEnum AdvanceFacility { get; set; }

    public Villa Villa { get; set; }
}
