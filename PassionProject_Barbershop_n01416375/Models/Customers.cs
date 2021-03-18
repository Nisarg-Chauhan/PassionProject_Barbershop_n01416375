using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel;

namespace PassionProject_Barbershop_n01416375.Models
{
    public class Customers
    {
        [Key]
        public int CustomerId { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }

        public string ContactNo { get; set; }

        public string AppointmentDate { get; set; }


        //A customer can have many appointments
        public ICollection<Appointments> Appointments { get; set; }
    }


    public class CustomersDto
    {
        public int CustomerId { get; set; }
        [DisplayName("First Name")]
        public string FirstName { get; set; }
        [DisplayName("Last Name")]
        public string LastName { get; set; }
        public string Email { get; set; }
        [DisplayName("Contact No.")]
        public string ContactNo { get; set; }
        [DisplayName("Appointment Date")]

        public string AppointmentDate { get; set; }

    }
}