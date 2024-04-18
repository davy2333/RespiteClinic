using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace RespiteClinic.Models.DTO
{
    public class Citas
    {
            [Display(Name = "id")]
            public int id { get; set; }
            [Display(Name = "personal asignado")]
            public Nullable<int> id_personal { get; set; }
            [Display(Name = "historial clinico asignado")]
            public Nullable<int> id_historial_clinico { get; set; }
            [Display(Name = "estado de la cita")]
            public string estado { get; set; }
            [Display(Name = "fecha y hora de la cita")]
            public byte[] fecha_hora { get; set; }
    }
}