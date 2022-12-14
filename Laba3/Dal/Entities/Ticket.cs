using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Laba3.Dal.Entities
{
    [Table("Ticket")]
    public class Ticket
    {
        [Key]
        public string Ticket_Id { get; set; }
        public string Passenger_Id { get; set; }

        [ForeignKey("Passenger_Id")]
        public virtual Passenger Passenger { get; set; }

        public string Airline_Id { get; set; }

        [ForeignKey("Airline_Id")]
        public virtual Airline Airline { get; set; }

        public decimal Cost { get; set; }

        public string Flight_Date { get; set; }
    }
}

