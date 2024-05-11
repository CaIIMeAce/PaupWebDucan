using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PaupWebDucan.Models
{
    [Table("proizvod")]
    public class Proizvod
    {
        [Key]
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
        public string Ostecen { get; set; }


        [Display(Name ="Kontrolni broj")]
        [Required(ErrorMessage = "{0} je obavezan")]
        [StringLength(30, MinimumLength = 11, ErrorMessage = "{0} mora biti duljine {2} znakova")]
        public string KontrolniBroj{ get; set; }


        public string ImeKontrolniBroj
        {
            get
            {
                return KontrolniBroj + " ---->" + ImeProizvoda;
            }
        }



        [Display(Name = "Datum proizvodnje")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode =true)]
        [Required(ErrorMessage ="{0} je obavezan")]
        [DataType(DataType.Date)]
        public DateTime DatumProizvodnje { get; set; }


        [Display(Name = "Godina modela")]
        [Range(1980,2024,ErrorMessage ="Godina {0} mora biti između {1} i {2}")]
        public int GodinaModela { get; set; }


        [Display(Name = "Dostupnost")]
        public bool Dostupnost { get; set; }

        [Display(Name = "Dana za nabavu")]
        public int DanaZaNabavu { get; set; }

        [Display(Name = "Kategorija")]
        [Column("KategorijeSifra")]
        [ForeignKey("KategorijaProizvoda")]
        public string KategorijeSifra { get; set; }

        public virtual Kategorije KategorijaProizvoda { get; set; }


        [Display(Name ="Fotografija")]
        [Column("slika")]
        public string SlikaPutanja {  get; set; }

        [NotMapped]
        public HttpPostedFileBase ImageFile { get; set; }
    }
}