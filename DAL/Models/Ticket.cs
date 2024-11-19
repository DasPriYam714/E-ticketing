using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models
{
    public class Ticket
    {
        [Key]
        public int T_Id { get; set; }

        [Required]
        public int User_Id { get; set; }

        [Required]
        public int Event_Id { get; set; }

        [Required]
        public DateTime Purchase_Date { get; set; }

        [Required]
        public float Price { get; set; }

        public string Description { get; set; }

        [ForeignKey("Users")]
        public int Posted_by { get; set; }

        public virtual User Users { get; set; }

    }
}
