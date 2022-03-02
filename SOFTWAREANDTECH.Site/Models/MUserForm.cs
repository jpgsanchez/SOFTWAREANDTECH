using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using System.ComponentModel.DataAnnotations;

namespace SOFTWAREANDTECH.Site.Models
{
    public class MUserForm
    {
        public int? tuid { get; set; }

        [Required]
        [Display(Name = "Sexo")]
        public int? tgid { get; set; }

        [Required]
        [EmailAddress]
        [Display(Name = "E-mail")]
        public string email { get; set; }

        [Required]
        [MaxLength(7)]
        [Display(Name = "Usuario")]
        public string uname { get; set; }

        [Required]
        [MaxLength(8)]
        [RegularExpression("([a-z]|[A-Z]|[0-9]|[\\W])")]
        [Display(Name = "Contraseña")]
        public string upwd { get; set; }

        [Required]
        [Display(Name = "Estatus")]
        public int? ustatus { get; set; }
    }
}