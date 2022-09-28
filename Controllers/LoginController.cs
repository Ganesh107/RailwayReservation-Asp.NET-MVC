using RailwayReservationUsingMVC.Models;
using RailwayReservationUsingMVC.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RailwayReservationUsingMVC.Controllers
{
    public class LoginController : Controller
    {
        LoginRepository loginRepository = new LoginRepository();
        public ActionResult Login()
        {
            try
            {
                return View();
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(Passengers passenger)
        {
            try
            {
                var user = loginRepository.ValidateLogin(passenger);
                if (user != null)
                {
                    Session["userid"] = passenger.Userid;
                    return RedirectToAction("SearchTrains", "Trains");
                }
                else
                {
                    TempData["invalid"] = "Invalid Details!";
                    return View();
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        public ActionResult AdminLogin()
        {
            try
            {
                return View();
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AdminLogin(Admins admin)
        {
            try
            {
                var details = loginRepository.ValidateAdminLogin(admin);
                if (details != null)
                {
                    return RedirectToAction("GetAllTrains", "Trains");
                }
                else
                {
                    TempData["invalid"] = "Invalid Details!";
                    return View();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}