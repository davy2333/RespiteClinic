using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace RespiteClinic.Models.DTO
{
    public class Pacientes
    {
            [Display(Name = "#")]
            public int id { get; set; }
            [Display(Name = "nombre del paciente")]
            public string nombre { get; set; }
            [Display(Name = "fecha de nacimiento")]
            public byte[] fecha_nacimiento { get; set; }
            [Display(Name = "genero")]
            public string genero { get; set; }
            [Display(Name = "direccion")]
            public string direccion { get; set; }
            [Display(Name = "telefono")]
            public string telefono { get; set; } 
    }
}