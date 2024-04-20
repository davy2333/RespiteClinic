using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace RespiteClinic.Models.DTO
{
    public class Inventario_medico
    {
        [Display(Name = "#")]
        public int id { get; set; }
        [Display(Name = "nombre del producto")]
        public string nombre_producto { get; set; }
        [Display(Name = "descripcion del producto")]
        public string descripcion { get; set; }
        [Display(Name = "stock disponible")]
        public string stock { get; set; }
        [Display(Name = "cantidad minima requerida")]
        public string MOQ { get; set; }
        [Display(Name = "precio asignado")]
        public Nullable<decimal> precio { get; set; }
        [Display(Name = "fecha de caducidad")]
        public Nullable<System.DateTime> fecha_caducidad { get; set; }
        [Display(Name = "proveedor")]
        public string proveedor { get; set; }
    }
}