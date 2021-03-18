using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel;

namespace PassionProject_Barbershop_n01416375.Models
{
    public class Appointments
    {

        [Key]
        public int AppointmentId { get; set; }

        public string AppointmentDay { get; set; }

        //An appointment belongs to one customer.
        [ForeignKey("Customers")]
        public int? CustomerId { get; set; }
        public virtual Customers Customers { get; set; }

        //An appointment belongs to one barber.
        [ForeignKey("Barbers")]
        public int? BarberId { get; set; }
        public virtual Barbers Barbers { get; set; }
    }

    public class AppointmentsDto
    {
        public int AppointmentId { get; set; }

        [DisplayName("Appointment Day")]
        public string AppointmentDay { get; set; }

 
    }
}