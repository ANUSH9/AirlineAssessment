using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibraryAirline.Model
{
    public class AirlineModel
    {
        [Key]
        public int ID { get; set; }
        [Required]
        public string? AirlineName { get; set; }
        [Required]
        public string? AirlinesFromCity { get; set; }
        [Required]
        public string? AirlinesToCity { get; set; }
        [Required]
        public int? AirlinesFare { get; set; }
    }
}
