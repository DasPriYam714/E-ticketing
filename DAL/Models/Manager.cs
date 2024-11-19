using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models
{
    public class Manager
    {
        [Key]
        public int Manager_Id { get; set; }

        [Required]
        [StringLength(50)]
        public string Manager_Name { get; set; }

        [Required]
        [StringLength(50)]
        public string Movie { get; set; }

        [Required]
        public DateTime Movie_Time { get; set; }


    }
}
