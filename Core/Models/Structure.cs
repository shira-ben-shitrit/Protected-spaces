using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Models
{
    public class Structure
    {
        public enum ProtectionLevel
        {
            ממד = 1,
            מקלט = 2,
            מקלט_ציבורי = 3,
            שטח_ציבורי_מוגן = 4,
            חדר_מדרגות = 5,
            מחוזק = 6
        }
        public int Id { get; set; }
        public String Name { get; set; }
        public ProtectionLevel Level { get; set; }
    }
}
