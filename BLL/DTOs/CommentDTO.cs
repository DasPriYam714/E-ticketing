using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTOs
{
    public class CommentDTO
    {
        public int Comment_Id { get; set; }
        [Required]
        public string Comment_Text { get; set; }
        [Required]
        public DateTime Comment_Time { get; set; }
        [Required]
        public int Comment_By { get; set; }
        [Required]
        public int Post_Id { get; set; }
    }
}
