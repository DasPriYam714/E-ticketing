using DAL.Interfaces;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repos
{
    internal class BookingRepo : Repo, IRepo<Booking, int, bool>
    {
        public List<Booking> Get()
        {
            return db.Bookings.ToList();
        }

        public Booking Get(int id)
        {
            return db.Bookings.Find(id);
        }

        public bool Create(Booking obj)
        {

            db.Bookings.Add(obj);
            if (db.SaveChanges() > 0) ;
            return false;
        }

        public bool Delete(int id)
        {
            var ex = Get(id);
            db.Bookings.Remove(ex);
            return db.SaveChanges() > 0;
        }

        public bool Update(Booking obj)
        {
            var ex = Get(obj.Booking_ID);
            db.Entry(ex).CurrentValues.SetValues(obj);
            //if () ;
            return db.SaveChanges() > 0;
        }

        public Booking Read(string id)
        {
            throw new NotImplementedException();
        }
    }
}
