using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace AriaRealState.Data.Entities
{
    public class BlogCategory : BaseEntity
    {
        [Display(Name = "")]
        [Required(ErrorMessage = "مقدار {0} را وارد کنید")]
        [MaxLength(100,ErrorMessage = "مقدار {0} نمی تواند بیش از {1} کارکتر باشد")]
        [MinLength(3, ErrorMessage = "مقدار {0} نمی تواند کمتر از {1} کارکتر باشد")]
        public required string CategoryName { get; set; }
        [Display(Name = "")]
        [Required(ErrorMessage = "مقدار {0} را وارد کنید")]
        [MaxLength(550, ErrorMessage = "مقدار {0} نمی تواند بیش از {1} کارکتر باشد")]
        public required string CategoryDescription { get; set; } = string.Empty;

        public ICollection<Blog> Blogs { get; set; }
    }
}
