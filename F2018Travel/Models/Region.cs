namespace F2018Travel.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Region
    {
        public Region()
        {
            Destinations = new HashSet<Destination>();
        }
        public int RegionId { get; set; }

        [Column("Region")]
        [StringLength(50)]
        [Display(Name = "Region")]
        public string Region1 { get; set; }

        public virtual ICollection<Destination> Destinations { get; set; }
    }
}
