using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTOs
{
    public class BookingDTO
    {
        public int Booking_ID { get; set; }
        [Required]
        public int User_ID { get; set; }
        [Required]
        public int Ticket_ID { get; set; }
        [Required]
        public DateTime Booking_Date { get; set; }
        [Required]
        public int Payment { get; set; }
    }
}
