using Dotnet.Models.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CAD.Models.Setting {

    [ToString]
    [Table("Teaching_Aid")]
    public class TeachingAid : GenericEntity {

        [MaxLength(5)]
        [Display(Name = "序號")]
        public string Seq;


        [MaxLength(20)]
        [Display(Name = "說明")]
        public string Description;

        [Required]
        [MaxLength(30)]
        [Display(Name = "檔名")]
        public string FileName;
        
        public Lesson Lesson;
    }
}
