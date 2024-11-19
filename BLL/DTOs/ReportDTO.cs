using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTOs
{
    public class ReportDTO
    {
        public int Report_Id { get; set; }
        [Required]
        public DateTime Report_Date { get; set; }
        [Required]
        public string Income { get; set; }
        [Required]
        public string Expense { get; set; }
        [Required]
        public int T_ID { get; set; }
        [Required]
        public int B_ID { get; set; }
    }
}
