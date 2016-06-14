using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Business.DomainModel;

namespace MvcApplication.Controllers
{
    public class RestaurantController : Controller
    {
        //
        // GET: /Restaurant/

        private DataRow LoadRestaurant(int id)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["DatabaseConnection"].ConnectionString;
            SqlConnection connection = new SqlConnection(connectionString);
            SqlCommand command = new SqlCommand("SELECT Id, Title, PhoneNumberText FROM Restaurant WHERE Id = " + id) { Connection = connection };
            SqlDataAdapter adapter = new SqlDataAdapter(command);

            using (connection)
            {
                DataSet dataSet = new DataSet();
                adapter.Fill(dataSet);

                return dataSet.Tables[0].Rows[0];
            }
        }

        public ActionResult Edit(int id)
        {
            ViewBag.Restaurant = LoadRestaurant(id);

            return View();
        }

        [HttpPost]
        public ActionResult Edit(int id, Restaurant restaurant)
        {
            ViewBag.Restaurant = LoadRestaurant(id);

            ViewBag.Message = String.Format("Saved '{0}'.", restaurant.Title);

            return View();
        }
    }
}
