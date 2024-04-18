using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace RespiteClinic.Models.DTO
{
    public class Personal
    {
        [Display(Name = "#")]
        public int id { get; set; }
        [Display(Name = "nombre")]
        public string nombre { get; set; }
        [Display(Name = "funcion en el hospital")]
        public string especialidad { get; set; }
        [Display(Name = "direccion")]
        public string direccion { get; set; }
        [Display(Name = "telefono")]
        public string telefono { get; set; }
        [Display(Name = "email")]
        public string email { get; set; }
    }
}