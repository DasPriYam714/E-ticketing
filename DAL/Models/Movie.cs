using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models
{
    public class Movie
    {
        [Key]
        public int M_Id { get; set; }
        [Required]
        public string M_Name { get; set; }
        [Required]
        public float Time { get; set; }
        [Required]
        public int Showtime { get; set; }
    }
}
