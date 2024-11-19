using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models
{
    public class Booking
    {
        [Key]
        public int Booking_ID { get; set; }

        [ForeignKey("Users")]
        public int User_ID { get; set; }

        public virtual User Users { get; set; }

        [ForeignKey("Tickets")]
        public int Ticket_ID { get; set; }

        public virtual Ticket Tickets { get; set; }

        [Required]
        public DateTime Booking_Date { get; set; }

        [Required]
        public int Payment { get; set; }
        
        public virtual ICollection<Transaction> Transactions { get; set; }

        public Booking()
        {

            Transactions = new List<Transaction>();
        }
    }
}
