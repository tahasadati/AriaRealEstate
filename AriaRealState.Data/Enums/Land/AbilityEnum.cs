using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace AriaRealState.Data.Enums.Land;

public enum AbilityEnum
{
    [Display(Name = "قابل تفکیک")]
    Subdividable = 1,
    
    [Display(Name = "قابل آپارتمان سازی")]
    ApartmentDevelopment = 2,

    [Display(Name = "قابل شهرک سازی")]
    TownshipDevelopment = 3
}
