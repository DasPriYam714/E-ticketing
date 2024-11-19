using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTOs
{
    public class RatingDTO
    {
        [Key]
        public int R_Id { get; set; }
        [Required]
        public float ratings { get; set; }
        [Required]
        public int U_ID { get; set; }

        [Required]
        public int M_Id { get; set; }
    }
}
