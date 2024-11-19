using DAL.Interfaces;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repos
{
    internal class TransactionRepo : Repo, IRepo<Transaction, int, bool>
    {
        public List<Transaction> Get()
        {
            return db.Transactions.ToList();
        }

        public Transaction Get(int id)
        {
            return db.Transactions.Find(id);
        }

        public bool Create(Transaction obj)
        {

            db.Transactions.Add(obj);
            if (db.SaveChanges() > 0) ;
            return false;
        }

        public bool Delete(int id)
        {
            var ex = Get(id);
            db.Transactions.Remove(ex);
            return db.SaveChanges() > 0;
        }

        public bool Update(Transaction obj)
        {
            var ex = Get(obj.Trans_ID);
            db.Entry(ex).CurrentValues.SetValues(obj);
            //if () ;
            return db.SaveChanges() > 0;
        }

        public Transaction Read(string id)
        {
            throw new NotImplementedException();
        }
    }
}
