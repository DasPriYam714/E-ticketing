using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models
{
    public class Rating
    {
        [Key]
        public int R_Id { get; set; }
        [Required]
        public float ratings { get; set; }

        [ForeignKey("Users")]
        public int U_ID { get; set; }

        [ForeignKey("Movies")]
        public int M_Id { get; set; }

        public virtual User Users { get; set; }
        public virtual Movie Movies { get; set; }


    }
}
