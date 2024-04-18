using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace RespiteClinic.Models.DTO
{
    public class Departamento
    {
        [Display(Name = "#")]
        public int id { get; set; }
        [Display(Name = "personal asignado")]
        public Nullable<int> id_personal { get; set; }
        [Display(Name = "paciente asignado")]
        public Nullable<int> id_paciente { get; set; }
        [Display(Name = "nombre del departamento")]
        public string nombre_departamento { get; set; }
        [Display(Name = "desripcion del departamento")]
        public string descripcion { get; set; }
    }
}