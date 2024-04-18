using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace RespiteClinic.Models.DTO
{
    public class Horario_laboral
    {
        [Display(Name = "#")]
        public int id { get; set; }
        [Display(Name = "personal asignado")]
        public Nullable<int> id_personal { get; set; }
        [Display(Name = "fecha")]
        public Nullable<System.DateTime> fecha { get; set; }
        [Display(Name = "hora de entrada")]
        public Nullable<System.TimeSpan> hora_entrada { get; set; }
        [Display(Name = "hora de salida")]
        public Nullable<System.TimeSpan> hora_salida { get; set; }
    }
}