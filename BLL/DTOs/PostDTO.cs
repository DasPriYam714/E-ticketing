using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTOs
{
    public class PostDTO
    {
        public int Post_Id { get; set; }
        [Required]
        public string Post_Title { get; set; }
        [Required]
        public string Post_Description { get; set; }
        [Required]
        public int Posted_By { get; set; }
        [Required]
        public DateTime Post_Date { get; set; }
    }
}
