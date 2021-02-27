using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace PassionProject_Barbershop_n01416375.Models
{
    public class Customers
    {
        [Key]
        public int customerId { get; set; }

        public string firstName { get; set; }

        public string lastName { get; set; }

        public string email { get; set; }

        public string contactNo { get; set; }

        //A customer can have many appointments
        public ICollection<Appointments> Appointments { get; set; }
    }
}