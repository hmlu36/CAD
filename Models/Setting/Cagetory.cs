using Dotnet.Models.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CAD.Models.Setting {

    [ToString]
    [Table("Category")]
    public class Category : GenericEntity {

        [Required]
        [MaxLength(10)]
        [Display(Name = "代碼")]
        public string Code;

        [MaxLength(30)]
        [Display(Name = "說明")]
        public string Description;
    }
}
