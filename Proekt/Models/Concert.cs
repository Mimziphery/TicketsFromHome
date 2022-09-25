using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Proekt.Models
{
    public class Concert
    {
        [Key]
        public int Id { get; set; }
        [Display(Name ="Артист")]
        [Required]
        public string Artist { get; set; }
        [Display(Name ="Дата")]
        [Required]
        public string Date { get; set; }
        [Display(Name ="Цена")]
        [Required]
        public int price { get; set; }
        [Display(Name ="Локација")]
        [Required]
        public string Location { get; set; }
    }
}