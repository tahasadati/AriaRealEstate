using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace AriaRealState.Data.Enums.Villa;

public enum AdvanceFacilityEnum
{
    [Display(Name = "استخر")]
    SwimmingPool = 1,
    

    [Display(Name = "جکوزی")]
    Jacuzzi = 2,
    

    [Display(Name = "پارکینگ")]
    Parking = 3,
    

    [Display(Name = "خواب مستردار")]
    MasterBedroom = 4,


    [Display(Name = "اسپلیت")] 
    SplitAirConditioning = 5,
    

    [Display(Name = "انباری")]
    StorageRoom = 6,
    

    [Display(Name = "تراس")]
    Terrace = 7,
    

    [Display(Name = "پارکت")]
    ParquetFlooring = 8,
    

    [Display(Name = "گرمایش از کف")]
    UnderfloorHeating = 9,
    

    [Display(Name = "سونا")]
    Sauna = 10,
    

    [Display(Name = "آسانسور")]
    Elevator = 11,
    

    [Display(Name = "شومینه")]
    Fireplace = 12,
    

    [Display(Name = "باربیکیو")]
    BBQArea = 13,
    

    [Display(Name = "روف گاردن")]
    RoofGarden = 14,
    

    [Display(Name = "گرمایش پکیج رادیاتور")]
    RadiatorHeating = 15,
    

    [Display(Name = "جاروبرقی مرکزی")]
    CentralVacuumSystem = 16,
    

    [Display(Name = "نگهبانی")]
    Security = 17


}
