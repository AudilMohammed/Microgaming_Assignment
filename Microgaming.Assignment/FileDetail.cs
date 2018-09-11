namespace Microgaming.Assignment
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class FileDetail
    {
        public int Id { get; set; }

        [Column(TypeName = "image")]
        [Required]
        public byte[] FileInfo { get; set; }

        public long CharityId { get; set; }

        [Required]
        public string FileName { get; set; }

        public virtual CharityRecord CharityRecord { get; set; }
    }
}
