using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Proekt.Models
{
    public class Museum
    {
        [Key]
        public int MusesumId { get; set; }
        [Display(Name = "Музеј")]
        [Required]
        public string Name { get; set; }
        [Display(Name ="Цена за карта")]
        [Required]
        public int Price { get; set; }
        [Display(Name ="Број за контакт")]
        [Required]
        public string Contact { get; set; }
        [Display(Name ="Работно Време")]
        [Required]
        public string WorkTime { get; set; }
    }
}