using AriaRealState.Data.Enums;
using AriaRealState.Data.Enums.Land;
using System.ComponentModel.DataAnnotations;

namespace AriaRealState.Web.Areas.Admin.Models.Land
{
    public class EditLandViewModel
    {
        public long Id { get; set; }

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

        // فایل‌های جدید (اختیاری)
        public IFormFile? VideoFile { get; set; }
        public IFormFile? CoverImageFile { get; set; }
        public List<IFormFile>? GalleriesFile { get; set; }

        // فایل‌های موجود برای نمایش
        public string? CurrentCoverImage { get; set; }
        public string? CurrentVideoLink { get; set; }
        public List<ExistingGalleryItemVm> ExistingGalleries { get; set; } = new();

        // حذف‌ها
        public bool RemoveVideo { get; set; }
        public bool RemoveCover { get; set; }
        public List<long> RemoveGalleryIds { get; set; } = new();
        public bool IsImmediate { get; set; }
        public string? NeighborhoodName { get; set; }


    }

    public class ExistingGalleryItemVm
    {
        public long Id { get; set; }
        public string FilePath { get; set; }
    }
}