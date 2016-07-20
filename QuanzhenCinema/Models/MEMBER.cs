namespace QuanzhenCinema.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("CINEMA_EDITOR.MEMBER")]
    public partial class MEMBER
    {
        [Key]
        [StringLength(1000)]
        public string PHONE_NUMBER { get; set; }

        [StringLength(30)]
        public string NAME { get; set; }

        public DateTime REGISTER_DATE { get; set; }

        public int REMAINING_DAY { get; set; }

        public int CREDIT { get; set; }
    }
}
