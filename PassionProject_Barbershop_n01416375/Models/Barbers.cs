using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace PassionProject_Barbershop_n01416375.Models
{
    public class Barbers
    {
        [Key]
        public int barberId { get; set; }

        public string bFirstName { get; set; }

        public string bLastName { get; set; }

        public string bEmail { get; set; }

        public string bContactNo { get; set; }

        //A barber can have many appointments
        public ICollection<Appointments> Appointments { get; set; }
    }
}