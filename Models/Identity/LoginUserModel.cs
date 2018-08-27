using System.ComponentModel.DataAnnotations;

namespace Dotnet.Models.Identity {
    public class LoginModel {
        [Required]
        [Display(Name = "帳號")]
        public string Account { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "密碼")]
        public string Password { get; set; }
    }

    public class ChangePasswordModel {
        [Display(Name = "帳號")]
        public string Account { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "舊密碼")]
        public string OldPassword { get; set; }

        [Required]
        [StringLength(30, ErrorMessage = "{0} 至少長度必須{2}個字元, 最多{1}個字元", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "新密碼")]
        public string NewPassword { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "確認密碼")]
        [Compare("NewPassword", ErrorMessage = "確認密碼 與 新密碼不合")] // 跟新密碼做比對
        public string ConfirmPassword { get; set; }
    }

    public class ForgotPasswordModel {
        [Required]
        [Display(Name = "帳號")]
        public string Account { get; set; }

        [Required]
        [Display(Name = "姓名")]
        public string Name { get; set; }
    }
}