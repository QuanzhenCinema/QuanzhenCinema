namespace QuanzhenCinema.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("CINEMA_EDITOR.SNACK")]
    public partial class SNACK
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public SNACK()
        {
            ORDER = new HashSet<ORDER>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int SNACK_ID { get; set; }

        [Required]
        [StringLength(1000)]
        public string NAME { get; set; }

        public int PRICE { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ORDER> ORDER { get; set; }
    }
}
