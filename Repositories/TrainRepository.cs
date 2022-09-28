using RailwayReservationUsingMVC.Models;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web;

namespace RailwayReservationUsingMVC.Repositories
{
    public class TrainRepository
    {
        RailwayContext railwayContext = new RailwayContext(); //object to access context class properties
        
        public void AddTrain(Traininfo train)
        {
            try
            {
                railwayContext.Traininfo.Add(train);
                railwayContext.SaveChanges();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public List<Traininfo> GetAllTrains()
        {
            try
            {
                return railwayContext.Traininfo.ToList();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void DeleteTrain(int trainid)
        {
            try
            {
                Traininfo train =  railwayContext.Traininfo.Find(trainid);
                railwayContext.Traininfo.Remove(train);
                railwayContext.SaveChanges();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void EditTrain(Traininfo train)
        {
            try
            {
                railwayContext.Entry<Traininfo>(train).State = System.Data.Entity.EntityState.Modified;
                railwayContext.SaveChanges();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public Traininfo GetTrainInfo(int trainid)
        {
            try
            {
                return railwayContext.Traininfo.Find(trainid);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public int GetAc2tierCount(string trainname)
        {
            try
            {
                var train = railwayContext.Traininfo.First(t => t.Trainname.Equals(trainname));
                int count = train.Ac2tier;
                return count;
            }
            catch (Exception)
            {
                throw;
            }
        }
        public void UpdateAc2tierCount(String trainname)
        {
            try
            {
                var train = railwayContext.Traininfo.First(t => t.Trainname.Equals(trainname));
                train.Ac2tier -= 1;
                railwayContext.SaveChanges();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public int GetAc3tierCount(string trainname)
        {
            try
            {
                var train = railwayContext.Traininfo.First(t => t.Trainname.Equals(trainname));
                int count = train.Ac3tier;
                return count;
            }
            catch (Exception)
            {
                throw;
            }
        }
        public void UpdateAc3tierCount(String trainname)
        {
            try
            {
                var train = railwayContext.Traininfo.First(t => t.Trainname.Equals(trainname));
                train.Ac3tier -= 1;
                railwayContext.SaveChanges();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public int GetSleeperCount(string trainname)
        {
            try
            {
                var train = railwayContext.Traininfo.First(t => t.Trainname.Equals(trainname));
                int count = train.Sleeper;
                return count;
            }
            catch (Exception)
            {
                throw;
            }
        }
        public void UpdateSleeperCount(String trainname)
        {
            try
            {
                var train = railwayContext.Traininfo.First(t => t.Trainname.Equals(trainname));
                train.Sleeper -= 1;
                railwayContext.SaveChanges();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public int GetTatkalCount(string trainname)
        {
            try
            {
                var train = railwayContext.Traininfo.First(t => t.Trainname.Equals(trainname));
                int count = train.Tatkal;
                return count;
            }
            catch (Exception)
            {
                throw;
            }
        }
        public void UpdateTatkalCount(String trainname)
        {
            try
            {
                var train = railwayContext.Traininfo.First(t => t.Trainname.Equals(trainname));
                train.Ac2tier -= 1;
                railwayContext.SaveChanges();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public int GetLadiesCount(string trainname)
        {
            try
            {
                var train = railwayContext.Traininfo.First(t => t.Trainname.Equals(trainname));
                int count = train.Ladies;
                return count;
            }
            catch (Exception)
            {
                throw;
            }
        }
        public void UpdateLadiesCount(String trainname)
        {
            try
            {
                var train = railwayContext.Traininfo.First(t => t.Trainname.Equals(trainname));
                train.Ladies -= 1;
                railwayContext.SaveChanges();
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}