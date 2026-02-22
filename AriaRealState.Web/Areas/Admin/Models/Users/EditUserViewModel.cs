using System.ComponentModel.DataAnnotations;

namespace AriaRealState.Web.Areas.Admin.Models.Users;

public class EditUserViewModel
{
    public string Id { get; set; } = null!;
    public string UserName { get; set; } = "";
    public string? Email { get; set; } = "";
    public string? PhoneNumber { get; set; } = "";
    public string FullName { get; set; }
    public bool IsActive { get; set; } 
    [MinLength(6, ErrorMessage = "حداقل 6 کاراکتر")]
    public string? NewPassword { get; set; }
    [Compare(nameof(NewPassword), ErrorMessage = "تکرار رمز صحیح نیست.")]
    public string? ConfirmNewPassword { get; set; }
}
