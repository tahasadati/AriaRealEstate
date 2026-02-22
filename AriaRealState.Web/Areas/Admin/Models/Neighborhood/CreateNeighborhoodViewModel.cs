using System.ComponentModel.DataAnnotations;

namespace AriaRealState.Web.Areas.Admin.Models.Neighborhood;

public class CreateNeighborhoodViewModel
{
    [Display(Name = "نام محله")]
    [Required(ErrorMessage = "مقدار {0} را وارد کنید")]
    [MaxLength(100, ErrorMessage = "مقدار {0} نمی تواند بیش از {1} کارکتر باشد")]
    [MinLength(3, ErrorMessage = "مقدار {0} نمی تواند کمتر از {1} کارکتر باشد")]
    public required string NeighborhoodName { get; set; }
}
