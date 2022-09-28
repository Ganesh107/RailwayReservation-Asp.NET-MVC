using RailwayReservationUsingMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RailwayReservationUsingMVC.Repositories
{
    public class LoginRepository
    {
        RailwayContext railwayContext = new RailwayContext(); //object to access context class properties

        public Passengers ValidateLogin(Passengers passenger)
        {
            try
            {
                var user = railwayContext.Passengers.Where(p => p.Userid.Equals(passenger.Userid) && p.Password.Equals(passenger.Password)).FirstOrDefault();
                return user;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public Admins ValidateAdminLogin(Admins admin)
        {
            try
            {
                var user = railwayContext.Admins.Where(a => a.Adminid.Equals(admin.Adminid) && a.Password.Equals(admin.Password)).FirstOrDefault();
                return user;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}