using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace RespiteClinic.Models.DTO
{
    public class Citas_inventario
    {
        [Display(Name = "id")]
        public int id { get; set; }
        [Display(Name = "cita asignada")]
        public Nullable<int> id_citas { get; set; }
        [Display(Name = "producto asignado")]
        public Nullable<int> id_inventario { get; set; }
        [Display(Name = "cantidad utilizada")]
        public Nullable<int> cantidad_utilizada { get; set; }
    }
}