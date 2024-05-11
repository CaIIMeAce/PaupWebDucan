using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace PaupWebDucan.Models
{
    [Table("kategorije")]
    public class Kategorije
    {
        [Key]
        [Display(Name ="Materijal izrade")]
        [Required(ErrorMessage ="{0} je obavezan")]
        [StringLength(40,ErrorMessage ="{0} smije biti duljine maksimalno {1} znakova")]
        public string MaterijalIzrade { get; set; }

        [Display(Name ="Kategorija")]
        [Required(ErrorMessage ="{0} je obavezna")]
        [StringLength(255,ErrorMessage ="{0} smije biti duljine maksimalno {1} znakova")]
        public string NazivKategorije { get; set; }

        [Display(Name ="Zastarijeli model")]
        [Required(ErrorMessage ="{0} je obavezan detalj")]
        public bool ZastarjeliModel { get; set; }
    }
}