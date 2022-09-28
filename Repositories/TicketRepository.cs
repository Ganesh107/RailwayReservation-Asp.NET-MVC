using RailwayReservationUsingMVC.Models;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web;

namespace RailwayReservationUsingMVC.Repositories
{
    public class TicketRepository
    {
        RailwayContext railwayContext = new RailwayContext(); //object to access context class properties

        public void NewTicket(Ticket ticket)
        {
			try
			{
                railwayContext.Tickets.Add(ticket);
                railwayContext.SaveChanges();
			}
			catch (Exception)
			{
				throw;
			}
        }

        public List<Ticket> GetTicketDetail(int userid,String date)
        {
            var ticket = railwayContext.Tickets.Where(i=>i.pid==userid && i.Bookingdate.Equals(date)).ToList();
            return ticket;
        }
    }
}