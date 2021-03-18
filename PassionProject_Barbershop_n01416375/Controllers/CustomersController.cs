using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;
using PassionProject_Barbershop_n01416375.Models;
using HttpPostAttribute = System.Web.Http.HttpPostAttribute;

namespace PassionProject_Barbershop_n01416375.Controllers
{
    public class CustomersController : Controller
    {
        private static readonly HttpClient client;
        private JavaScriptSerializer jss = new JavaScriptSerializer();


        static CustomersController()
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




        // GET: Customers
        public ActionResult Index()
        {
            return View();
        }




        // GET: Team/Details/5
        public ActionResult Details(int id)
        {
            string url = "customersdata/findcustomer/" + id;
            // Send off an HTTP request
            // GET : /api/playerdata/getplayers
            // Retrieve response
            HttpResponseMessage response = client.GetAsync(url).Result;
            // If the response is a success, proceed
            if (response.IsSuccessStatusCode)
            {
                // Fetch the response content into IEnumerable<PlayerDto>
                CustomersDto SelectedCustomer = response.Content.ReadAsAsync<CustomersDto>().Result;
                return View(SelectedCustomer);

            }
            else
            {
                return RedirectToAction("Error");
            }
         
        }
        public ActionResult Customers()
        {
            return View();
        }

        // GET: Customers/Create
        [HttpGet]
        public ActionResult CreateCustomer()
        {
            return View();
        }

        // POST: Customers/Create
        [HttpPost]
        public ActionResult Create(Customers customer)
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
        }



        // GET: Customers/List?{PageNum}
        public ActionResult ListCustomers()
        {
            // Grab all players
            string url = "CustomersData/Getcustomers";
            // Send off an HTTP request
            // GET : /api/playerdata/getplayers
            // Retrieve response
            HttpResponseMessage response = client.GetAsync(url).Result;
            // If the response is a success, proceed
            if (response.IsSuccessStatusCode)
            {
                // Fetch the response content into IEnumerable<PlayerDto>
                IEnumerable<CustomersDto> SelectedCustomers = response.Content.ReadAsAsync<IEnumerable<CustomersDto>>().Result;
                return View(SelectedCustomers);

            }
            else
            {
                return RedirectToAction("Error");
            }
        }

        // POST: Customers/Create
        [HttpPost]
        [ValidateAntiForgeryToken()]
        public ActionResult CreateCustomer(Customers CustomerInfo)
        {
            Debug.WriteLine(CustomerInfo.FirstName);
            string url = "CustomersData/AddCustomer";
            Debug.WriteLine(jss.Serialize(CustomerInfo));
            HttpContent content = new StringContent(jss.Serialize(CustomerInfo));
            content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            HttpResponseMessage response = client.PostAsync(url, content).Result;

            if (response.IsSuccessStatusCode)
            {

                int customerid = response.Content.ReadAsAsync<int>().Result;
           
                // return RedirectToAction("Index");
                return RedirectToAction("Details", new { id = customerid });

            }
            else
            {
                return RedirectToAction("Error");
            }


        }




        [HttpGet]
        public ActionResult Edit(int id)
        {
            string url = "customersdata/findcustomer/" + id;
            HttpResponseMessage response = client.GetAsync(url).Result;
            //Can catch the status code (200 OK, 301 REDIRECT), etc.
            //Debug.WriteLine(response.StatusCode);
            if (response.IsSuccessStatusCode)
            {
                //Put data into Team data transfer object
                CustomersDto SelectedCustomer = response.Content.ReadAsAsync<CustomersDto>().Result;
                return View(SelectedCustomer);
            }
            else
            {
                return RedirectToAction("Error");
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken()]
        public ActionResult Edit(int id, Customers CustomerInfo)
        {
            string url = "customersdata/updatecustomer/" + id;
            Debug.WriteLine(jss.Serialize(CustomerInfo));
            HttpContent content = new StringContent(jss.Serialize(CustomerInfo));
            content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            HttpResponseMessage response = client.PostAsync(url, content).Result;

            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("Details", new { id = id });
            }
            else
            {
                return RedirectToAction("Error");
            }
        }




        // GET: Customer/Delete/5
        [HttpGet]
        public ActionResult DeleteConfirm(int id)
        {
            string url = "customersdata/findcustomer/" + id;
            HttpResponseMessage response = client.GetAsync(url).Result;
            //Can catch the status code (200 OK, 301 REDIRECT), etc.
            //Debug.WriteLine(response.StatusCode);
            if (response.IsSuccessStatusCode)
            {
                //Put data into player data transfer object
                CustomersDto SelectedCustomer = response.Content.ReadAsAsync<CustomersDto>().Result;
                return View(SelectedCustomer);
            }
            else
            {
                return RedirectToAction("Error");
            }
        }

        // POST: Customer/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken()]
        public ActionResult Delete(int id)
        {
            string url = "customersdata/deletecustomers/" + id;
            //post body is empty
            HttpContent content = new StringContent("");
            HttpResponseMessage response = client.PostAsync(url, content).Result;
            //Can catch the status code (200 OK, 301 REDIRECT), etc.
            //Debug.WriteLine(response.StatusCode);
            if (response.IsSuccessStatusCode)
            {

                return RedirectToAction("ListCustomers");
            }
            else
            {
                return RedirectToAction("Error");
            }
        }
        public ActionResult Error()
        {
            return View();
        }


    }
}
