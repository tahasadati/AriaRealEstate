using System.ComponentModel.DataAnnotations;

namespace AriaRealState.Web.Areas.Admin.Models.Users;

public class CreateUserViewModel
{
    [Display(Name = "نام و نام خانوادگی")]
    public string FullName { get; set; }

    [Required, Display(Name = "نام کاربری")]
    public string UserName { get; set; } = null!;

    [Display(Name = "ایمیل")]
    public string Email { get; set; } = null!;

    [Phone, Display(Name = "موبایل")]
    public string? PhoneNumber { get; set; }

    [Required, MinLength(6), Display(Name = "رمز عبور")]
    public string Password { get; set; } = null!;

    [Compare(nameof(Password)), Display(Name = "تکرار رمز عبور")]
    public string ConfirmPassword { get; set; } = null!;
}
