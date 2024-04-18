using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace RespiteClinic.Models.DTO
{
    public class Pagos
    {
        [Display(Name = "#")]
        public int id { get; set; }
        [Display(Name = "personal asignado")]
        public Nullable<int> id_personal { get; set; }
        [Display(Name = "fecha del pago")]
        public Nullable<System.DateTime> fecha_pago { get; set; }
        [Display(Name = "monto")]
        public Nullable<decimal> monto { get; set; }
    }
}