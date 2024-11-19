using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models
{
    public class Comment
    {
        [Key]
        public int Comment_Id { get; set; }

        [Required]
        public string Comment_Text { get; set; }

        [Required]
        public DateTime Comment_Time { get; set; }

        [ForeignKey("Users")]
        public int Comment_By { get; set; }

        public virtual User Users { get; set; }

        [ForeignKey("Posts")]
        public int Post_Id { get; set; }

        public virtual Post Posts { get; set; }

       


    }
}
