using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Dotnet.Models.Generic;
using Newtonsoft.Json;

namespace Dotnet.Models.Identity {

    [ToString]
    [Table("Identity_User")]
    public class User : GenericEntity {

        [Required, MaxLength(10)]
        public string Account;

        [Required, MaxLength(30)]
        public string Name;

        [Required, MaxLength(30)]
        public string Password;

        [MaxLength(100)]
        public string PasswordHash;

        [MaxLength(50)]
        public string Email;

        [MaxLength(30)]
        public string FirstName;

        [MaxLength(30)]
        public string LastName;

        [MaxLength(1)]
        public string Status;

        public List<UserRole> UserRoles;

        // 畫面上使用, 不儲存DB
        [NotMapped]
        public string ConfirmPassword;

        [NotMapped]
        public List<string> Roles;
    }
}