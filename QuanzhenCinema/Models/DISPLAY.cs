namespace QuanzhenCinema.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("CINEMA_EDITOR.DISPLAY")]
    public partial class DISPLAY
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public DISPLAY()
        {
            SCHEDULE = new HashSet<SCHEDULE>();
            DISCOUNT = new HashSet<DISCOUNT>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int DISPLAY_ID { get; set; }

        public int MOVIE_ID { get; set; }

        public bool IS_3D { get; set; }

        public bool IS_IMAX { get; set; }

        [Required]
        [StringLength(30)]
        public string LANGUAGE { get; set; }

        public int LOWEST_PRICE { get; set; }

        public int LENGTH { get; set; }

        public virtual MOVIE MOVIE { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SCHEDULE> SCHEDULE { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DISCOUNT> DISCOUNT { get; set; }
    }
}
