using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models
{
    public class Transaction
    {
        [Key]
        public int Trans_ID { get; set; }
        [Required]
        [StringLength(25)]
        public string Trans_name { get; set; }
        public DateTime Trans_Date { get; set; }
        [ForeignKey("Tickets")]
        public int Ticket_ID { get; set; }
        [ForeignKey("Bookings")]
        public int Res_ID { get; set; }
        [ForeignKey("Users")]
         public int User_ID { get; set; }

        public virtual Ticket Tickets { get; set; }

        public virtual Booking Bookings { get; set; }
        public virtual User Users { get; set; }
        public virtual ICollection<Admin> Admins { get; set; }

        public virtual ICollection<Report> Reports { get; set; }

        public Transaction()
        {
            Admins = new List<Admin>();
            Reports = new List<Report>();
        }
    }
}
