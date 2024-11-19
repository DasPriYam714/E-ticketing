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
    public class BookingService
    {
        public static List<BookingDTO> Get()
        {

            var data = DataAccessFactory.BookingData().Get();
            return Convert(data);

        }

        public static BookingDTO Get(int id)
        {
            return Convert(DataAccessFactory.BookingData().Get(id));
        }
        public static bool Create(BookingDTO booking)
        {
            var data = Convert(booking);
            var res = DataAccessFactory.BookingData().Create(data);

            if (res != null) return true;
            return false;
        }

        public static bool Update(BookingDTO booking)
        {
            var data = Convert(booking);
            var res = DataAccessFactory.BookingData().Update(data);

            if (res != null) return true;
            return false;
        }
        public static bool Delete(int id)
        {
            return DataAccessFactory.BookingData().Delete(id);
        }

        static List<BookingDTO> Convert(List<Booking> bookings)
        {
            var data = new List<BookingDTO>();
            foreach (var booking in bookings)
            {
                data.Add(Convert(booking));
            }
            return data;

        }
        static Booking Convert(BookingDTO booking)
        {
            return new Booking()
            {
                Booking_ID = booking.Booking_ID,
                User_ID = booking.User_ID,
                Ticket_ID = booking.Ticket_ID,
                Booking_Date = booking.Booking_Date,
                Payment = booking.Payment
            };
        }
        static BookingDTO Convert(Booking booking)
        {
            return new BookingDTO()
            {
                Booking_ID = booking.Booking_ID,
                User_ID = booking.User_ID,
                Ticket_ID = booking.Ticket_ID,
                Booking_Date = booking.Booking_Date,
                Payment = booking.Payment
            };
        }
    }
}
