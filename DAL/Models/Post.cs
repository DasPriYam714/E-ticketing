using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models
{
    public class Post
    {
        [Key]
        public int Post_Id { get; set; }
        [Required]
        public string Post_Title { get; set; }
        [Required]
        public string Post_Description { get; set; }
        [ForeignKey("Users")]
        public int Posted_By { get; set; }

        public DateTime Post_Date { get; set; }

        public virtual User Users { get; set; }

        public virtual ICollection<Comment> Comments { get; set; }

        public Post()
        {
            Comments = new List<Comment>();
        }

    }
}
