using RailwayReservationUsingMVC.Models;
using RailwayReservationUsingMVC.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RailwayReservationUsingMVC.Controllers
{
    public class TicketController : Controller
    {
        TicketRepository ticketRepository = new TicketRepository();
        public ActionResult ViewTicket()
        {
            int userid = (int)Session["Userid"];
            string booking_date = DateTime.Now.Date.ToString();
            List<Ticket> ticket =  ticketRepository.GetTicketDetail(userid,booking_date);
            return View(ticket);
        }

        public ActionResult Logout()
        {
            Session.Abandon();
            return RedirectToAction("Index", "Home");
        }
    }
}