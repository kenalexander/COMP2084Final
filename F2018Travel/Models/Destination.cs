namespace F2018Travel.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Destination
    {
        public int DestinationId { get; set; }

        [Required]
        [StringLength(200)]
        public string Name { get; set; }

        [Required]
        [StringLength(100)]
        public string Location { get; set; }

        [StringLength(5000)]
        public string Description { get; set; }

        [StringLength(200)]
        public string Photo { get; set; }

        [Display(Name = "Region")]
        public int RegionId { get; set; }

        public virtual Region Region { get; set; }
    }
}
