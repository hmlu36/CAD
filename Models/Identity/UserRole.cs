using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Dotnet.Models.Generic;
using Newtonsoft.Json;

namespace Dotnet.Models.Identity {

    [ToString]
    [Table("UserRole")]
    public class UserRole : IEntity {

        public UserRole() { }

        public UserRole(string userId, string roleId) {
            this.UserId = userId;
            this.RoleId = roleId;
        }

        // Primary Key
        /*
        [Required]
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string Id;
        */

        [Required, ForeignKey(nameof(User))]
        public string UserId;

        [Required, ForeignKey(nameof(Role))]
        public string RoleId;

    }
}