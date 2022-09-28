using RailwayReservationUsingMVC.Models;
using RailwayReservationUsingMVC.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RailwayReservationUsingMVC.Controllers
{
    public class SignupController : Controller
    {
        SignupRepository SignupRepository = new SignupRepository();
        public ActionResult AddPassenger()
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
        public ActionResult AddPassenger(Passengers passenger)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    SignupRepository.AddPassenger(passenger);
                    TempData["userid"] = SignupRepository.GetPassengerId(passenger);
                    ModelState.Clear();
                    return View();
                }
                else
                {
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