using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Models
{
    public class opinionDTO
    {
        [Key]
        public int Id { get; set; }
        public int AddressId { get; set; } 
        public int Rating { get; set; } 
        public string Text { get; set; }
        
    }
}
