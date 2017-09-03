namespace GRS.DataAccess.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Skill")]
    public partial class Skill
    {
        public long Id { get; set; }

        [Required]
        [StringLength(2147483647)]
        public string Name { get; set; }
    }
}
