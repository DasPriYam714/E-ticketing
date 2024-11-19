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
    public class TicketService
    {
        public static List<TicketDTO> Get()
        {

            var data = DataAccessFactory.TicketData().Get();
            return Convert(data);

        }

        public static TicketDTO Get(int id)
        {
            return Convert(DataAccessFactory.TicketData().Get(id));
        }
        public static bool Create(TicketDTO ticket)
        {
            var data = Convert(ticket);
            var res = DataAccessFactory.TicketData().Create(data);

            if (res != null) return true;
            return false;
        }

        public static bool Update(TicketDTO ticket)
        {
            var data = Convert(ticket);
            var res = DataAccessFactory.TicketData().Update(data);

            if (res != null) return true;
            return false;
        }
        public static bool Delete(int id)
        {
            return DataAccessFactory.TicketData().Delete(id);
        }

        static List<TicketDTO> Convert(List<Ticket> tickets)
        {
            var data = new List<TicketDTO>();
            foreach (var ticket in tickets)
            {
                data.Add(Convert(ticket));
            }
            return data;

        }
        static Ticket Convert(TicketDTO ticket)
        {
            return new Ticket()
            {
                T_Id = ticket.T_Id,
                User_Id = ticket.User_Id,
                Event_Id = ticket.Event_Id,
                Purchase_Date = ticket.Purchase_Date,
                Price = ticket.Price,
                Description = ticket.Description,
                Posted_by = ticket.Posted_by
            };
        }
        static TicketDTO Convert(Ticket ticket)
        {
            return new TicketDTO()
            {
                T_Id = ticket.T_Id,
                User_Id = ticket.User_Id,
                Event_Id = ticket.Event_Id,
                Purchase_Date = ticket.Purchase_Date,
                Price = ticket.Price,
                Description = ticket.Description,
                Posted_by = ticket.Posted_by
            };
        }
    }
}
