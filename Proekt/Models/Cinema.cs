using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Proekt.Models
{
    public class Cinema
    {
        [Key]
        public int Id { get; set; }
        [Display(Name ="Име на кино")]
        [Required]
        public string CinemaName { get; set; }
        [Display(Name ="Време на започнување")]
        [Required]
        public string StartTime { get; set; }
        [Display(Name ="Дата")]
        [Required]
        public string Date { get; set; }
        [Display(Name ="Име на филм")]
        [Required]
        public string Name { get; set; }
        [Display(Name ="Цена")]
        [Required]
        public int Price { get; set; }
    }
}