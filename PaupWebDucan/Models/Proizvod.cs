using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PaupWebDucan.Models
{
    public class Proizvod
    {
        [Display(Name ="Skladišni broj")]
        public int SkladisniBroj { get; set; }


        [Display(Name ="Ime proizvoda")]
        [Required(ErrorMessage = "{0} je obavezno")]
        [StringLength(30, MinimumLength =2, ErrorMessage = "{0} mora biti duljine minimalno {2} i maksimalno {1} znakova")]
        public string ImeProizvoda{ get; set; }


        [Display(Name ="Boja proizvoda")]
        [Required(ErrorMessage = "{0} je obavezna")]
        [StringLength(30, MinimumLength = 2, ErrorMessage = "{0} mora biti duljine minimalno {2} i maksimalno {1} znakova")]
        public string BojaProizvoda { get; set; }


        [Display(Name ="Oštećen")]
        public char Ostecen { get; set; }


        [Display(Name ="Kontrolni broj")]
        [Required(ErrorMessage = "{0} je obavezan")]
        [StringLength(11, MinimumLength = 11, ErrorMessage = "{0} mora biti duljine {2} znakova")]
        public string KontrolniBroj{ get; set; }


        [Display(Name = "Datum proizvodnje")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode =true)]
        [Required(ErrorMessage ="{0} je obavezan")]
        [DataType(DataType.Date)]
        public DateTime DatumProizvodnje { get; set; }


        [Display(Name = "Godina modela")]
        public GodinaModela GodinaModela { get; set; }


        [Display(Name = "Dostupnost")]
        public bool Dostupnost { get; set; }

        [Display(Name = "Dana za nabavu")]
        public int DanaZaNabavu { get; set; }
    }
}