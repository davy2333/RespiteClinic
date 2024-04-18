using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace RespiteClinic.Models.DTO
{
    public class Historial_clinico
    {
        [Display(Name = "#")]
        public int id { get; set; }
        [Display(Name = "paciente asignado")]
        public Nullable<int> id_paciente { get; set; }
        [Display(Name = "fecha de registro del historial clinico")]
        public byte[] fecha_registro_historial { get; set; }
        [Display(Name = "historial de enfermedades")]
        public string historial_enfermedades { get; set; }
        [Display(Name = "motivos de la consulta")]
        public string motivo_consulta { get; set; }
        [Display(Name = "diagnostico final")]
        public string diagnostico { get; set; }
        [Display(Name = "tratamiento recomendado")]
        public string tratamiento { get; set; }
    }
}