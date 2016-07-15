namespace QuanzhenCinema.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("CINEMA_EDITOR.MOVIE")]
    public partial class MOVIE
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public MOVIE()
        {
            DISPLAY = new HashSet<DISPLAY>();
            IMAGE = new HashSet<IMAGE>();
            CATEGORY = new HashSet<CATEGORY>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int MOVIE_ID { get; set; }

        [StringLength(1000)]
        public string NAME { get; set; }

        [StringLength(1000)]
        public string DESCRIPTION { get; set; }

        public DateTime? EXPIRE_DATE { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DISPLAY> DISPLAY { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<IMAGE> IMAGE { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CATEGORY> CATEGORY { get; set; }
    }
}
