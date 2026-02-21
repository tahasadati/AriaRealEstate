using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace AriaRealState.Data.Enums.Villa;

public enum VillaOccupancyStatus
{
    [Display(Name = "کلید نخورده")]
    BrandNew = 1,

    [Display(Name = "کلیدخورده")]
    Resale = 2,
}
