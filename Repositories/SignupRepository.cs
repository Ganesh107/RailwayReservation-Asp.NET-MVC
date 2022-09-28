using RailwayReservationUsingMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RailwayReservationUsingMVC.Repositories
{
    public class SignupRepository
    {
        RailwayContext railwayContext = new RailwayContext(); //object to access context class properties

        public void AddPassenger(Passengers passenger)
        {
            try
            {
                railwayContext.Passengers.Add(passenger);
                railwayContext.SaveChanges();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public List<Passengers> GetAllPassengers()
        {
            try
            {
                return railwayContext.Passengers.ToList();
            }
            catch (Exception)
            {
                throw;
            }
        }

        //Function to get passenger id
        public int GetPassengerId(Passengers passenger)
        {
            try
            {
                int userid = (from p in railwayContext.Passengers
                              where p.Phonenumber == passenger.Phonenumber
                              select p.Userid).First();

                if (userid != 0)
                {
                    return userid;
                }
                else
                {
                    return 0;
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}