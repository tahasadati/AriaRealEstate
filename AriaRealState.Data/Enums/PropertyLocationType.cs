using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace AriaRealState.Data.Enums;

public enum PropertyLocationType
{
    [Display(Name = "شهرکی")]
    GatedCommunity = 1,
    
    [Display(Name = "مستقل")]
    Detached = 2
}
