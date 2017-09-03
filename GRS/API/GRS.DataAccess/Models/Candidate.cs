namespace GRS.DataAccess.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Candidate")]
    public partial class Candidate
    {
        public long Id { get; set; }

        [Required]
        [StringLength(2147483647)]
        public string FirstName { get; set; }

        [Required]
        [StringLength(2147483647)]
        public string LastName { get; set; }
    }
}
