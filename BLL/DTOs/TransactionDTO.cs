using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTOs
{
    public class TransactionDTO
    {
        public int Trans_ID { get; set; }
        [Required]
        public string Trans_name { get; set; }
        [Required]
        public DateTime Trans_Date { get; set; }
        [Required]
        public int Ticket_ID { get; set; }
        [Required]
        public int Res_ID { get; set; }
        [Required]
        public int User_ID { get; set; }
    }
}
