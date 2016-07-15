namespace QuanzhenCinema.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("CINEMA_EDITOR.TICKET")]
    public partial class TICKET
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int TICKET_ID { get; set; }

        public int SCHEDULE_ID { get; set; }

        public int PRICE { get; set; }

        public int ORDER_ID { get; set; }

        public int SEAT_COLUMN_ID { get; set; }

        public int SEAT_ROW_ID { get; set; }

        public int SEAT_HALL_ID { get; set; }

        public virtual ORDER ORDER { get; set; }

        public virtual SCHEDULE SCHEDULE { get; set; }

        public virtual SEAT SEAT { get; set; }
    }
}
