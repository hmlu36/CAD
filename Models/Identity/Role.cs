using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Dotnet.Models.Generic;

namespace Dotnet.Models.Identity {

    [ToString]
    [Table("Identity_Role")]
    public class Role : GenericEntity {

        [Required]
        [MaxLength(30)]
        [Display(Name = "¥N½X")]
        public string Code;

        [MaxLength(30)]
        public string Description;

        public List<UserRole> UserRoles;
    }
}