using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace AriaRealState.Data.Enums.Villa;

public enum VillaArchitectureType
{
    [Display(Name = "فلت")]
    Flat = 1,

    [Display(Name = "نیم پلوت")]
    SplitLevel = 2,
    
    [Display(Name = "دوبلکس")]
    Duplex = 3,
    
    [Display(Name = "تریپلکس")]
    Triplex = 4,
    
    [Display(Name = "سایر موارد")]
    Other = 5,
}
