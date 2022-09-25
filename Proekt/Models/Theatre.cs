using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Proekt.Models
{
    public class Theatre
    {
        [Key]
        public int TheatreId { get; set; }
        [Display(Name ="Театар")]
        [Required]
        public string Name { get; set; }
        [Display(Name ="Претстава")]
        [Required]
        public string Play { get; set; }
        [Display(Name = "Број на Сала")]
        [Required]
        public int Room { get; set; }
        [Display(Name ="Цена за карта")]
        [Required]
        public float Price { get; set; }
        [Display(Name = "Датум на претставата")]
        [Required]
        public string playDate { get; set; }
        [Display(Name = "Почеток на претставата")]
        [Required]
        public string startTime { get; set; }
        [Display(Name = "Времетраење на претставата")]
        [Required]
        public string Duration { get; set; }
    }
}