using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Dotnet.Models.Generic {
    public class IEntity {

        // Primary Key
        [Required]
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string Id;
    }
}
