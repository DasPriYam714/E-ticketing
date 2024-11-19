using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTOs
{
    public class ManagerDTO
    {
        public int Manager_Id { get; set; }
        [Required]
        public string Manager_Name { get; set; }
        [Required]
        public string Movie { get; set; }
        [Required]
        public DateTime Movie_Time { get; set; }
    }
}
