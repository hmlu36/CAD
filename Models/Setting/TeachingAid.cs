using Dotnet.Models.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CAD.Models.Setting {

    [ToString]
    [Table("Teaching_Aid")]
    public class TeachingAid : GenericEntity {

        [Required]
        [MaxLength(20)]
        [Display(Name = "名稱")]
        public string Name;

        [MaxLength(5)]
        [Display(Name = "序號")]
        public string Seq;

        [MaxLength(30)]
        [Display(Name = "路徑")]
        public string Path;

        public Lesson Lesson;
    }
}
