using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using PassionProject_Barbershop_n01416375.Models;

namespace PassionProject_Barbershop_n01416375.Controllers
{
    public class AppointmentsDataController : ApiController
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: api/AppointmentsData
        public IQueryable<Appointments> GetAppointments()
        {
            return db.Appointments;
        }

        // GET: api/AppointmentsData/5
        [ResponseType(typeof(Appointments))]
        public IHttpActionResult GetAppointments(int id)
        {
            Appointments appointments = db.Appointments.Find(id);
            if (appointments == null)
            {
                return NotFound();
            }

            return Ok(appointments);
        }

       

        // POST: api/AppointmentsData
        [ResponseType(typeof(Appointments))]
        public IHttpActionResult PostAppointments(Appointments appointments)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Appointments.Add(appointments);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = appointments.AppointmentId }, appointments);
        }

        // DELETE: api/AppointmentsData/5
        [ResponseType(typeof(Appointments))]
        public IHttpActionResult DeleteAppointments(int id)
        {
            Appointments appointments = db.Appointments.Find(id);
            if (appointments == null)
            {
                return NotFound();
            }

            db.Appointments.Remove(appointments);
            db.SaveChanges();

            return Ok(appointments);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool AppointmentsExists(int id)
        {
            return db.Appointments.Count(e => e.AppointmentId == id) > 0;
        }


        /// <summary>
        /// Adds a customer to the database.
        /// </summary>
        /// <param name="customer">A customer object. Sent as POST form data.</param>
        /// <returns>status code 200 if successful. 400 if unsuccessful</returns>
        /// <example>
        /// POST: api/CustomersData/AddCustomer
        ///  FORM DATA: Player JSON Object
        /// </example>
        [ResponseType(typeof(Appointments))]
        [HttpPost]
        public IHttpActionResult AddAppointment([FromBody] Appointments appointment)
        {
            //Will Validate according to data annotations specified on model
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Appointments.Add(appointment);
            db.SaveChanges();

            return Ok(appointment.AppointmentId);
        }
    }
}