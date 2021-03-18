using PassionProject_Barbershop_n01416375.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;

namespace PassionProject_Barbershop_n01416375.Controllers
{
    public class AppointmentsController : Controller
    {

        private static readonly HttpClient client;
        private JavaScriptSerializer jss = new JavaScriptSerializer();


        static AppointmentsController()
        {
            HttpClientHandler handler = new HttpClientHandler()
            {
                AllowAutoRedirect = false
            };
            client = new HttpClient(handler);
            //change this to match your own local port number
            client.BaseAddress = new Uri("https://localhost:44327/api/");
            client.DefaultRequestHeaders.Accept.Add(
            new MediaTypeWithQualityHeaderValue("application/json"));

        }
        // GET: Appointments
        public ActionResult Index()
        {
            return View();
        }

        // GET: Appointments/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Appointments/Create
        [HttpGet]
        public ActionResult CreateAppointment()
        {
            return View();
        }

        /*       // POST: Appointments/Create
               [HttpPost]
               public ActionResult Create(FormCollection collection)
               {
                   try
                   {
                       // TODO: Add insert logic here

                       return RedirectToAction("Index");
                   }
                   catch
                   {
                       return View();
                   }
               }*/


        // POST: Player/Create
        [HttpPost]
        [ValidateAntiForgeryToken()]
        public ActionResult CreateAppointment(Appointments AppointmentInfo)
        {
            string url = "AppointmentsData/AddAppointment";
            HttpContent content = new StringContent(jss.Serialize(AppointmentInfo));
            content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            HttpResponseMessage response = client.PostAsync(url, content).Result;

            if (response.IsSuccessStatusCode)
            {

                int appointmentid = response.Content.ReadAsAsync<int>().Result;
                return View();
                // return RedirectToAction("Index");
                /*                return RedirectToAction("Details", new { id = customerid });
                */
            }
            else
            {
                return RedirectToAction("Error");
            }


        }

        // GET: Appointments/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Appointments/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Appointments/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Appointments/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
