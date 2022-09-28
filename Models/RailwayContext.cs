using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace RailwayReservationUsingMVC.Models
{
    public class RailwayContext : DbContext
    {
        public RailwayContext() : base("name=Railwayconn")
        {

        }
        public DbSet<Passengers> Passengers { get; set; }
        public DbSet<Admins> Admins { get; set; }
        public DbSet<Traininfo> Traininfo { get; set; }
        public DbSet<Ticket> Tickets { get; set; }
    }
}