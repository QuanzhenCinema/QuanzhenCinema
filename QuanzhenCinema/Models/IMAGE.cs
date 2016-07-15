namespace QuanzhenCinema.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("CINEMA_EDITOR.IMAGE")]
    public partial class IMAGE
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int IMAGE_ID { get; set; }

        [Required]
        [StringLength(1000)]
        public string IMAGE_PATH { get; set; }

        public int? WIDTH { get; set; }

        public int? HEIGHT { get; set; }

        public int MOVIE_ID { get; set; }

        public virtual MOVIE MOVIE { get; set; }
    }
}
