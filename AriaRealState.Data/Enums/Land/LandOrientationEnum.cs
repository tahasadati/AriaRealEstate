using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace AriaRealState.Data.Enums.Land;

public enum LandOrientationEnum
{
    [Display(Name = "شمالی")]
    NorthFacing = 1,

    [Display(Name = "جنوبی")]
    SouthFacing = 2,
    
    [Display(Name = "شرقی")] 
    EastFacing = 3,

    [Display(Name = "غربی")] 
    WestFacing = 4,
}
