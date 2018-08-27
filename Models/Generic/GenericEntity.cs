using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Dotnet.Models.Generic {
    // Reference: https://techbrij.com/generic-repository-unit-of-work-entity-framework-unit-testing-asp-net-mvc
    public class GenericEntity : IEntity {

        /* Auditable Column */
        [Required]
        [ScaffoldColumn(false)] // ASP.NET MVC Scaffolding will NOT generate controls for this in Views
        [Column("Created_Time")]
        public DateTime CreatedTime;

        [Required]
        [ScaffoldColumn(false)]
        [Column("Modified_Time")]
        public DateTime ModifiedTime;

        [Required, MaxLength(10)]
        [Column("Created_User")] // ASP.NET MVC Scaffolding will NOT generate controls for this in Views
        public string CreatedUser;

        [Required, MaxLength(10)]
        [Column("Modified_User")]
        public string ModifiedUser;
    }
}