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
    public class CustomersDataController : ApiController
    {

        //This variable is our database access point
        private ApplicationDbContext db = new ApplicationDbContext();



        /// <summary>
        /// Gets a list or customers in the database alongside a status code (200 OK).
        /// </summary>
        /// <returns>A list of customers including their details.</returns>
        /// <example>
        /// GET : api/customersdata/getcustomers
        /// </example>
        [ResponseType(typeof(IEnumerable<CustomersDto>))]
        [Route("api/customersdata/getcustomers")]
        public IHttpActionResult GetCustomers()
        {
            List<Customers> Customers = db.Customers.ToList();
            List<CustomersDto> CustomersDtos = new List<CustomersDto> { };

            //Here you can choose which information is exposed to the API
            foreach (var Customer in Customers)
            {
                CustomersDto NewCustomer = new CustomersDto
                {
                    CustomerId = Customer.CustomerId,
                    FirstName = Customer.FirstName,
                    LastName = Customer.LastName,
                    Email = Customer.Email,
                    ContactNo = Customer.ContactNo,
                    AppointmentDate = Customer.AppointmentDate

                };
                CustomersDtos.Add(NewCustomer);
            }

            return Ok(CustomersDtos);
        }


        /// <summary>
        /// Finds a particular Team in the database with a 200 status code. If the Team is not found, return 404.
        /// </summary>
        /// <param name="id">The Team id</param>
        /// <returns>Information about the Team, including Team id, bio, first and last name, and teamid</returns>
        // <example>
        // GET: api/TeamData/FindTeam/5
        // </example>
        [HttpGet]
        [ResponseType(typeof(CustomersDto))]
        public IHttpActionResult FindCustomer(int id)
        {
            //Find the data
            Customers customer = db.Customers.Find(id);
            //if not found, return 404 status code.
            if (customer == null)
            {
                return NotFound();
            }

            //put into a 'friendly object format'
            CustomersDto CustomersDto = new CustomersDto
            {
                CustomerId = customer.CustomerId,
                FirstName = customer.FirstName,
                LastName = customer.LastName,
                Email = customer.Email,
                ContactNo = customer.ContactNo,
                AppointmentDate = customer.AppointmentDate
            };


            //pass along data as 200 status code OK response
            return Ok(CustomersDto);
        }



        // POST: api/CustomersData
        [ResponseType(typeof(Customers))]
        public IHttpActionResult PostCustomers(Customers customers)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Customers.Add(customers);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = customers.CustomerId }, customers);
        }

        // DELETE: api/CustomersData/5
        /// <summary>
        /// Deletes a Team in the database
        /// </summary>
        /// <param name="id">The id of the Team to delete.</param>
        /// <returns>200 if successful. 404 if not successful.</returns>
        /// <example>
        /// POST: api/TeamData/DeleteTeam/5
        /// </example>
        [HttpPost]
        public IHttpActionResult DeleteCustomers(int id)
        {
            Customers customers = db.Customers.Find(id);
            if (customers == null)
            {
                return NotFound();
            }

            db.Customers.Remove(customers);
            db.SaveChanges();

            return Ok(customers);
        }


        /// <summary>
        /// Updates a Team in the database given information about the Team.
        /// </summary>
        /// <param name="id">The Team id</param>
        /// <param name="Team">A Team object. Received as POST data.</param>
        /// <returns></returns>
        /// <example>
        /// POST: api/TeamData/UpdateTeam/5
        /// FORM DATA: Team JSON Object
        /// </example>
        [ResponseType(typeof(void))]
        [HttpPost]
        public IHttpActionResult UpdateCustomer(int id, [FromBody] Customers Customer)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != Customer.CustomerId)
            {
                return BadRequest();
            }

            db.Entry(Customer).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CustomersExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }



        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool CustomersExists(int id)
        {
            return db.Customers.Count(e => e.CustomerId == id) > 0;
        }



        /// <summary>
        /// Adds a customer to the database.
        /// </summary>
        /// <param name="customer">A player object. Sent as POST form data.</param>
        /// <returns>status code 200 if successful. 400 if unsuccessful</returns>
        /// <example>
        /// POST: api/CustomersData/AddCustomer
        ///  FORM DATA: Player JSON Object
        /// </example>
        [ResponseType(typeof(Customers))]
        [HttpPost]
        public IHttpActionResult AddCustomer([FromBody] Customers customer)
        {
            //Will Validate according to data annotations specified on model
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Customers.Add(customer);
            db.SaveChanges();

            return Ok(customer.CustomerId);
        }
    }
}