using Dotnet.Models.Generic;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CAD.Models.Setting {

    [ToString]
    [Table("Lesson")]
    public class Lesson : GenericEntity {

        [Required]
        [MaxLength(20)]
        [Display(Name = "名稱")]
        public string Name;

        [MaxLength(30)]
        [Display(Name = "說明")]
        public string Description;

        public List<TeachingAid> TeachingAids;
    }
}
