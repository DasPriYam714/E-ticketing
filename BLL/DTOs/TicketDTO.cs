using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTOs
{
    public class TicketDTO
    {
        public int T_Id { get; set; }
        [Required]
        public int User_Id { get; set; }
        [Required]
        public int Event_Id { get; set; }
        [Required]
        public DateTime Purchase_Date { get; set; }
        [Required]
        public float Price { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public int Posted_by { get; set; }
    }
}
