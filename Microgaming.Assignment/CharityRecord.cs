namespace Microgaming.Assignment
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class CharityRecord
    {
        public long Id { get; set; }

        [Required]
        public string Title { get; set; }

        public string Description { get; set; }

        public string Charity { get; set; }

        public bool PlayItForward { get; set; }

        public float Currency { get; set; }

        [Required]
        [StringLength(128)]
        public string UserId { get; set; }

        [Column(TypeName = "image")]
        public byte[] FileInfo { get; set; }

        public virtual AspNetUser AspNetUser { get; set; }
    }
}
