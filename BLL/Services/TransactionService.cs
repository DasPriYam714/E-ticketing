using BLL.DTOs;
using DAL;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class TransactionService
    {
        public static List<TransactionDTO> Get()
        {

            var data = DataAccessFactory.TransactionData().Get();
            return Convert(data);

        }

        public static TransactionDTO Get(int id)
        {
            return Convert(DataAccessFactory.TransactionData().Get(id));
        }
        public static bool Create(TransactionDTO transaction)
        {
            var data = Convert(transaction);
            var res = DataAccessFactory.TransactionData().Create(data);

            if (res != null) return true;
            return false;
        }

        public static bool Update(TransactionDTO transaction)
        {
            var data = Convert(transaction);
            var res = DataAccessFactory.TransactionData().Update(data);

            if (res != null) return true;
            return false;
        }
        public static bool Delete(int id)
        {
            return DataAccessFactory.TransactionData().Delete(id);
        }

        static List<TransactionDTO> Convert(List<Transaction> transactions)
        {
            var data = new List<TransactionDTO>();
            foreach (var transaction in transactions)
            {
                data.Add(Convert(transaction));
            }
            return data;

        }
        static Transaction Convert(TransactionDTO transaction)
        {
            return new Transaction()
            {
                Trans_ID = transaction.Trans_ID,
                Trans_name = transaction.Trans_name,
                Trans_Date = transaction.Trans_Date,
                Ticket_ID = transaction.Ticket_ID,
                Res_ID = transaction.Res_ID,
                User_ID = transaction.User_ID
            };
        }
        static TransactionDTO Convert(Transaction transaction)
        {
            return new TransactionDTO()
            {
                Trans_ID = transaction.Trans_ID,
                Trans_name = transaction.Trans_name,
                Trans_Date = transaction.Trans_Date,
                Ticket_ID = transaction.Ticket_ID,
                Res_ID = transaction.Res_ID,
                User_ID = transaction.User_ID
            };
        }
    }
}
