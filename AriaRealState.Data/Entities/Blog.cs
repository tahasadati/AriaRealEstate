using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace AriaRealState.Data.Entities
{
    public class Blog : BaseEntity
    {
        [Display(Name = "")]
        public long BlogCategoryId { get; set; }
        [Display(Name = "")]
        [Required(ErrorMessage = "مقدار {0} را وارد کنید")]
        [MaxLength(100, ErrorMessage = "مقدار {0} نمی تواند بیش از {1} کارکتر باشد")]
        [MinLength(3, ErrorMessage = "مقدار {0} نمی تواند کمتر از {1} کارکتر باشد")]
        public required string BlogTitle { get; set; }
        [Display(Name = "")]
        [Required(ErrorMessage = "مقدار {0} را وارد کنید")]
        [MaxLength(100, ErrorMessage = "مقدار {0} نمی تواند بیش از {1} کارکتر باشد")]
        [MinLength(3, ErrorMessage = "مقدار {0} نمی تواند کمتر از {1} کارکتر باشد")]
        public required string BlogDescription { get; set; }
        [Display(Name = "")][Required(ErrorMessage = "مقدار {0} را وارد کنید")]
        public required string BlogText { get; set; }
        [Display(Name = "")]
        [Required(ErrorMessage = "مقدار {0} را وارد کنید")]
        [MaxLength(100, ErrorMessage = "مقدار {0} نمی تواند بیش از {1} کارکتر باشد")]
        [MinLength(3, ErrorMessage = "مقدار {0} نمی تواند کمتر از {1} کارکتر باشد")]
        public required string Keyword { get; set; }
        
        [Display(Name = "آماده نمایش")]
        public bool IsReadyShow { get; set; } = true;
        [Display(Name = "تصویر شاخص")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        public required string BlogImage { get; set; }


        public BlogCategory BlogCategory { get; set; }
    }
}
