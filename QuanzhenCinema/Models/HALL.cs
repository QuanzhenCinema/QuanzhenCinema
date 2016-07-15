namespace QuanzhenCinema.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("CINEMA_EDITOR.HALL")]
    public partial class HALL
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public HALL()
        {
            SCHEDULE = new HashSet<SCHEDULE>();
            SEAT = new HashSet<SEAT>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int HALL_ID { get; set; }

        public int CAPACITY { get; set; }

        public bool IS_3D { get; set; }

        public bool IS_DOLAB { get; set; }

        public bool IS_IMAX { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SCHEDULE> SCHEDULE { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SEAT> SEAT { get; set; }
    }
}
