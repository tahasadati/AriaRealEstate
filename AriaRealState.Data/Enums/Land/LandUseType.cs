using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace AriaRealState.Data.Enums.Land;

public enum LandUseType
{
    [Display(Name = "باغی")]
    Orchard = 1,

    [Display(Name = "زراعی")]
    Agricultural = 2,
    
    [Display(Name = "مسکونی")]
    Residential = 3,
    
    [Display(Name = "جنگلی")]
    Forest = 4,

}
