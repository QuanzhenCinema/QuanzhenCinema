namespace QuanzhenCinema.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("CINEMA_EDITOR.DISCOUNT")]
    public partial class DISCOUNT
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public DISCOUNT()
        {
            DISPLAY = new HashSet<DISPLAY>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int DISCOUNT_ID { get; set; }

        public decimal RATE { get; set; }

        public int? NUM { get; set; }

        public DateTime? START_DATE { get; set; }

        public int REMAINING_DAY { get; set; }

        public int? WEEKDAY { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DISPLAY> DISPLAY { get; set; }
    }
}
