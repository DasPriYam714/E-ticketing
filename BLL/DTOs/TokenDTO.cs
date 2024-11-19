using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTOs
{
    public class TokenDTO
    {
        public int Id { get; set; }
        [Required]
        public string TKey { get; set; }
        [Required]
        public DateTime CreatedAt { get; set; }
        [Required]
        public DateTime DeletedAt { get; set; }
        [Required]
        public string UserId { get; set; }
    }
}
