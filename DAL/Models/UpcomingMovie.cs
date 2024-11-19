using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models
{
    public class UpcomingMovie
    {
        [Key]
        public int UM_Id { get; set; }
        [Required]
        public string UM_Name { get; set; }
        [Required]
        public DateTime Date { get; set; }
    }
}
