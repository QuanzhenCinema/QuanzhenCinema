namespace QuanzhenCinema.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("CINEMA_EDITOR.SCHEDULE")]
    public partial class SCHEDULE
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public SCHEDULE()
        {
            TICKET = new HashSet<TICKET>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int SCHEDULE_ID { get; set; }

        public int DISPLAY_ID { get; set; }

        public int DAY { get; set; }

        public int HALL_ID { get; set; }

        public int ORIGINAL_PRICE { get; set; }

        public DateTime? START_TIME { get; set; }

        public DateTime? END_TIME { get; set; }

        public decimal? END_SLOT { get; set; }

        public decimal? START_SLOT { get; set; }

        public virtual DISPLAY DISPLAY { get; set; }

        public virtual HALL HALL { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TICKET> TICKET { get; set; }
    }
}
