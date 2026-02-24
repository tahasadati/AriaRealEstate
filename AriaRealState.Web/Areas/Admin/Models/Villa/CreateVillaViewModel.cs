using AriaRealState.Data.Enums;
using AriaRealState.Data.Enums.Villa;
using System.ComponentModel.DataAnnotations;

namespace AriaRealState.Web.Areas.Admin.Models.Villa;

public class CreateVillaViewModel
{
    [Display(Name = "کد ویلا")]
    [Required(ErrorMessage = "مقدار {0} را وارد کنید")]
    public string Code { get; set; }

    [Display(Name = "عنوان")]
    [Required(ErrorMessage = "مقدار {0} را وارد کنید")]
    public string Title { get; set; }

    [Display(Name = "قیمت نمایشی")]
    [Required(ErrorMessage = "مقدار {0} را وارد کنید")]
    public decimal ShowPrice { get; set; }

    [Display(Name = "حداقل قیمت فروش")]
    [Required(ErrorMessage = "مقدار {0} را وارد کنید")]
    public decimal MinPrice { get; set; }
    public bool IsShow { get; set; } = true;

    [Display(Name = "متراژ زیربنا")]
    [Required(ErrorMessage = "مقدار {0} را وارد کنید")]
    public int InfrastructureSize { get; set; }

    [Display(Name = "متراژ زمین")]
    [Required(ErrorMessage = "مقدار {0} را وارد کنید")]
    public int LandSize { get; set; }

    [Display(Name = "تعداد اتاق")]
    [Required(ErrorMessage = "مقدار {0} را وارد کنید")]
    public int RoomCount { get; set; }

    [Display(Name = "عمر ساخت")]
    [Required(ErrorMessage = "مقدار {0} را وارد کنید")]
    public int BuildingYear { get; set; }

    [Display(Name = "توضیحات")]
    [Required(ErrorMessage = "مقدار {0} را وارد کنید")]
    public string Description { get; set; }
    [Display(Name = "نوع معماری")]
    [Required(ErrorMessage = "مقدار {0} را وارد کنید")]
    public VillaArchitectureType ArchitectureType { get; set; }
    [Display(Name = "کارکرد ویلا")]
    [Required(ErrorMessage = "مقدار {0} را وارد کنید")]
    public VillaOccupancyStatus OccupancyStatus { get; set; }
    [Display(Name = "نوع ویلا")]
    [Required(ErrorMessage = "مقدار {0} را وارد کنید")]
    public PropertyLocationType LocationType { get; set; }
    [Display(Name = "ویدیو")]
    public IFormFile? VideoFile { get; set; }
    public required IFormFile CoverImageFile { get; set; }
    public List<IFormFile>? GalleriesFile { get; set; }

    [Display(Name = "امکانات پیشرفته")]
    public List<AdvanceFacilityEnum> SelectedAdvanceFacilities { get; set; } = new();
    public bool IsImmediate { get; set; }
    public string? NeighborhoodName { get; set; }

}
