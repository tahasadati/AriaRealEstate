using AriaRealState.Data.Enums;
using AriaRealState.Data.Enums.Land;
using System.ComponentModel.DataAnnotations;

namespace AriaRealState.Web.Areas.Admin.Models.Land;

public class CreateLandViewModel
{
    [Display(Name = "کد زمین")]
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
    [Display(Name = "متراژ زمین")]
    [Required(ErrorMessage = "مقدار {0} را وارد کنید")]
    public int LandSize { get; set; }
    [Display(Name = "قابلیت زمین")]
    [Required(ErrorMessage = "مقدار {0} را وارد کنید")]
    public AbilityEnum Ability { get; set; }
    [Display(Name = "جهت زمین")]
    [Required(ErrorMessage = "مقدار {0} را وارد کنید")]
    public LandOrientationEnum LandOrientation { get; set; }
    [Display(Name = "کاربری زمین")]
    [Required(ErrorMessage = "مقدار {0} را وارد کنید")]
    public LandUseType UseType { get; set; }
    [Display(Name = "موقعیت زمین")]
    [Required(ErrorMessage = "مقدار {0} را وارد کنید")]
    public PropertyLocationType LocationType { get; set; }
    [Display(Name = "ویدیو")]
    public IFormFile? VideoFile { get; set; }
    [Display(Name = "تصویر کاور")]
    [Required(ErrorMessage = "مقدار {0} را وارد کنید")]
    public IFormFile CoverImageFile { get; set; }
    public List<IFormFile>? GalleriesFile { get; set; }
    public bool IsImmediate { get; set; }
    public string? NeighborhoodName { get; set; }


}
