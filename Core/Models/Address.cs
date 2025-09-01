using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Core.Models
{
    public class Address
    {
        public int Id { get; set; }
        public decimal MapLocation_point1 { get; set; }
        public decimal MapLocation_point2 { get; set; }
        public int StructureId { get; set; }

        [ForeignKey("StructureId")]
        public Structure Structure { get; set; }
        public bool IsOpen24_7 { get; set; }
        public int ConstructionYear { get; set; }
        public string ContactPerson { get; set; }
        public string PhoneNumber { get; set; }
        public String Sms { get; set; }
        public int Capacity { get; set; }
        public int CurrentOccupancy { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        [JsonIgnore]
        public List<opinion> Opinions { get; set; } = new();
    }
}
