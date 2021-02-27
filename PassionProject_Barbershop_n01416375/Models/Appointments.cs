using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace PassionProject_Barbershop_n01416375.Models
{
    public class Appointments
    {

        [Key]
        public int appointmentId { get; set; }

        public DateTime appointmentDay { get; set; }

        //An appointment belongs to one customer.
        [ForeignKey("Customers")]
        public int customerId { get; set; }
        public virtual Customers Customers { get; set; }

        //An appointment belongs to one barber.
        [ForeignKey("Barbers")]
        public int barberId { get; set; }
        public virtual Barbers Barbers { get; set; }
    }
}