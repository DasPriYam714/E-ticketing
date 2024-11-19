using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models
{
    public class Accountant
    {
        [Key]
        public int A_Id { get; set; }
        [Required]
        [StringLength(30)]

        public string A_Name { get; set; }
        [Required]
        [StringLength(20)]
        public string Password { get; set; }
        [Required]
        [StringLength(30)]
        public string Name { get; set; }
        [Required]
        public string Email { get; set; }
    }
}
