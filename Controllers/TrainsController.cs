using RailwayReservationUsingMVC.Models;
using RailwayReservationUsingMVC.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;
using System.Web.WebPages;

namespace RailwayReservationUsingMVC.Controllers
{
    public class TrainsController : Controller
    {
        RailwayContext db = new RailwayContext();
        TrainRepository trainRepository = new TrainRepository();
        TicketRepository ticketRepository = new TicketRepository();
        public ActionResult GetAllTrains()
        {
            try
            {
                List<Traininfo> trains = trainRepository.GetAllTrains();
                return View(trains);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public ActionResult AddTrain()
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
        public ActionResult AddTrain(Traininfo train)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    trainRepository.AddTrain(train);
                    return RedirectToAction("GetAllTrains", "Trains");
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

        public ActionResult EditTrain(int trainid)
        {
            try
            {
                Traininfo train = trainRepository.GetTrainInfo(trainid);
                return View(train);
                
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditTrain(Traininfo train)
        {
            try
            {
                trainRepository.EditTrain(train);
                return RedirectToAction("GetAllTrains", "Trains");
            }
            catch (Exception)
            {
                throw;
            }
        }

        public ActionResult DeleteTrain(int trainid)
        {
            try
            {
                trainRepository.DeleteTrain(trainid);
                return RedirectToAction("GetAllTrains", "Trains");
            }
            catch (Exception)
            {
                throw;
            }
        }

        public ActionResult GetTrainDetails(int trainid)
        {
            try
            {
                Traininfo train = trainRepository.GetTrainInfo(trainid);
                return View(train);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public ActionResult SearchTrains()
        {
            try
            {
                List<Traininfo> trains = trainRepository.GetAllTrains();
                return View(trains);
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpGet]
        public ActionResult SearchTrains(string startloc,string endloc,string date)
        {
            try
            {
                if (Session["userid"] != null)
                {
                    var trainslist = db.Traininfo.ToList();
                    if (startloc != null && endloc != null && date != null)
                    {
                        var trains = trainslist.Where(t => t.Startloc.Contains(startloc) && t.Endloc.Contains(endloc) && t.Arrivaldate.Contains(date));
                        return View(trains);
                    }
                    else
                    {
                        return View(trainslist);
                    }
                }
                else
                {
                    return RedirectToAction("Login", "Login");
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        public ActionResult BookTicket(int trainid)
        {
            try
            {
                Traininfo train = trainRepository.GetTrainInfo(trainid);
                Session["trainname"] = train.Trainname;
                Session["startloc"] = train.Startloc;
                Session["endloc"] = train.Endloc;
                Session["arrivaltime"] = train.Arrivaltime;
                Session["departuretime"] = train.Departuretime;
                Session["arrivaldate"] = train.Arrivaldate;

                List<SelectListItem> lst = new List<SelectListItem>();
                lst.Add(new SelectListItem { Text = "AC-2 Tier", Value = "Ac2tier" });
                lst.Add(new SelectListItem { Text = "AC-3 Tier", Value = "Ac3tier" });
                lst.Add(new SelectListItem { Text = "Sleeper", Value = "Sleeper" });
                lst.Add(new SelectListItem { Text = "Tatkal", Value = "Tatkal" });
                lst.Add(new SelectListItem { Text = "Ladies", Value = "Ladies" });
                ViewBag.TrainClasses = lst;

                List<SelectListItem> Gender = new List<SelectListItem>();
                Gender.Add(new SelectListItem { Text = "Male", Value = "Male" });
                Gender.Add(new SelectListItem { Text = "Female", Value = "Female" });
                ViewBag.Genders = Gender;
                return View();
            }
            catch (Exception)
            {

                throw;
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult BookTicket(Ticket ticket,FormCollection form)
        {
            string trainname = Session["trainname"].ToString();
            if(ticket!=null)
            {
                Ticket ticket1 = new Ticket();
                ticket1.Bookingstatus = null;
                ticket1.Trainname = trainname;
                ticket1.Ticketclass = form["TrainClasses"].ToString();   
                ticket1.Gender = form["Genders"].ToString();
                ticket1.Pname = ticket.Pname;
                ticket1.Berthnumber = ticket.Berthnumber;
                ticket1.Coachnumber = ticket.Coachnumber;
                ticket1.Arrivaldate = Session["arrivaldate"].ToString();
                ticket1.Bookingdate = DateTime.Now.Date.ToString();
                ticket1.pid = (int)Session["Userid"];

                if (ticket1.Ticketclass == "Ac2tier")
                {
                    if (trainRepository.GetAc2tierCount(trainname)>0)
                    {
                        ticket1.Bookingstatus = "Confirmed";
                        ticketRepository.NewTicket(ticket1);
                        trainRepository.UpdateAc2tierCount(trainname);
                    }
                    else
                    {
                        ticket1.Bookingstatus = "Waitlist";
                        ticketRepository.NewTicket(ticket1);
                        trainRepository.UpdateAc2tierCount(trainname);
                    }

                }
                else if (ticket1.Ticketclass == "Ac3tier")
                {
                    if (trainRepository.GetAc3tierCount(trainname) > 0)
                    {
                        ticket1.Bookingstatus = "Confirmed";
                        ticketRepository.NewTicket(ticket1);
                        trainRepository.UpdateAc3tierCount(trainname);
                    }
                    else
                    {
                        ticket1.Bookingstatus = "Waitlist";
                        ticketRepository.NewTicket(ticket1);
                        trainRepository.UpdateAc3tierCount(trainname);
                    }
                }
                else if (ticket1.Ticketclass == "Sleeper")
                {
                    if (trainRepository.GetSleeperCount(trainname) > 0)
                    {
                        ticket1.Bookingstatus = "Confirmed";
                        ticketRepository.NewTicket(ticket1);
                        trainRepository.UpdateSleeperCount(trainname);
                    }
                    else
                    {
                        ticket1.Bookingstatus = "Waitlist";
                        ticketRepository.NewTicket(ticket1);
                        trainRepository.UpdateSleeperCount(trainname);
                    }
                }
                else if (ticket1.Ticketclass == "Tatkal")
                {
                    if (trainRepository.GetTatkalCount(trainname) > 0)
                    {
                        ticket1.Bookingstatus = "Confirmed";
                        ticketRepository.NewTicket(ticket1);
                        trainRepository.UpdateTatkalCount(trainname);
                    }
                    else
                    {
                        ticket1.Bookingstatus = "Waitlist";
                        ticketRepository.NewTicket(ticket1);
                        trainRepository.UpdateTatkalCount(trainname);
                    }
                }
                else
                {
                    if (trainRepository.GetLadiesCount(trainname) > 0)
                    {
                        ticket1.Bookingstatus = "Confirmed";
                        ticketRepository.NewTicket(ticket1);
                        trainRepository.UpdateLadiesCount(trainname);
                    }
                    else
                    {
                        ticket1.Bookingstatus = "Waitlist";
                        ticketRepository.NewTicket(ticket1);
                        trainRepository.UpdateLadiesCount(trainname);
                    }
                }
                return RedirectToAction("ViewTicket", "Ticket");
            }
            else
            {
                return View();
            }
        }

        public ActionResult Logout()
        {
            Session.Abandon();
            return RedirectToAction("Index", "Home");
        }
    }
}