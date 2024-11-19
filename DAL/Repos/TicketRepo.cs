using DAL.Interfaces;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repos
{
    internal class TicketRepo : Repo, IRepo<Ticket, int, bool>
    {
        public List<Ticket> Get()
        {
            return db.Tickets.ToList();
        }

        public Ticket Get(int id)
        {
            return db.Tickets.Find(id);
        }

        public bool Create(Ticket obj)
        {

            db.Tickets.Add(obj);
            if (db.SaveChanges() > 0) ;
            return false;
        }

        public bool Delete(int id)
        {
            var ex = Get(id);
            db.Tickets.Remove(ex);
            return db.SaveChanges() > 0;
        }

        public bool Update(Ticket obj)
        {
            var ex = Get(obj.T_Id);
            db.Entry(ex).CurrentValues.SetValues(obj);
            //if () ;
            return db.SaveChanges() > 0;
        }

        public Ticket Read(string id)
        {
            throw new NotImplementedException();
        }
    }
}
