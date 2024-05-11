using iTextSharp.text;
using iTextSharp.text.pdf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PaupWebDucan.Models;
using System.IO;
using System.Web.Hosting;
using PaupWebDucan.Misc;
using System.ComponentModel;

namespace PaupWebDucan.Reports
{
    public class ProizvodiReport
    {
        public byte[] Podaci { get; private set; }
        //vraca formatirani izgled celije

        private PdfPCell GenerirajCeliju(string sadrzaj, Font font, BaseColor boja, bool wrap)
        {
            PdfPCell c1= new PdfPCell(new Phrase(sadrzaj, font));
            c1.BackgroundColor = boja;
            c1.HorizontalAlignment = PdfPCell.ALIGN_LEFT;
            c1.Padding = 5;
            c1.NoWrap = wrap;
            c1.Border = Rectangle.BOTTOM_BORDER;
            c1.BorderColor = BaseColor.LIGHT_GRAY;
            return c1;
        }
        public void ListaProizvoda(List<Proizvod> proizvodi)
        {
            //definiranje fontova
            BaseFont bfontZaglavlje = BaseFont.CreateFont(BaseFont.HELVETICA, BaseFont.CP1250, false);
            BaseFont bfontText = BaseFont.CreateFont(BaseFont.TIMES_ROMAN, BaseFont.CP1250, BaseFont.EMBEDDED);
            BaseFont bfontPodnozje = BaseFont.CreateFont(BaseFont.TIMES_ITALIC, BaseFont.CP1250, false);

            Font fontZaglavlje = new Font(bfontZaglavlje, 12, Font.NORMAL, BaseColor.DARK_GRAY);
            Font fontZaglavljeBold = new Font(bfontZaglavlje, 12, Font.BOLD, BaseColor.DARK_GRAY);
            Font fontNaslov = new Font(bfontText,14,Font.BOLDITALIC, BaseColor.DARK_GRAY);
            Font fontTablicaZaglavlje = new Font(bfontText,10, Font.BOLD,BaseColor.WHITE);
            Font fontTekst = new Font(bfontText,10,Font.NORMAL,BaseColor.BLACK);

            //Boja header tablice
            BaseColor tPozadinaZaglavlje = new BaseColor(255, 50, 50);
            //Pozadina celije
            BaseColor tPozadinaSadrzaj =BaseColor.WHITE;

            using (MemoryStream mstream = new MemoryStream())
            {
                using (Document pdfDokument = new Document(PageSize.A4, 50, 50, 20, 50))
                {
                    PdfWriter.GetInstance(pdfDokument, mstream).CloseStream = false;

                    pdfDokument.Open();

                    //Tablica za ispis zaglavlja - 1. kolona logo, 2. tekst
                    PdfPTable tZaglavlje = new PdfPTable(2);
                    tZaglavlje.HorizontalAlignment = Element.ALIGN_LEFT;
                    tZaglavlje.DefaultCell.Border = Rectangle.NO_BORDER;
                    tZaglavlje.WidthPercentage= 100f;
                    float[] sirinaKolonaZaglavlja = new float[] { 1f, 3f };
                    tZaglavlje.SetWidths(sirinaKolonaZaglavlja);

                    //ucitavanje slike
                    var logo = iTextSharp.text.Image.GetInstance(HostingEnvironment.MapPath("~/Images/Lego.png"));
                    logo.Alignment= Element.ALIGN_LEFT;
                    logo.ScaleAbsoluteWidth(50);
                    logo.ScaleAbsoluteHeight(50);

                    //mjesto za logo
                    PdfPCell cLogo = new PdfPCell(logo);
                    cLogo.Border= Rectangle.NO_BORDER;
                    tZaglavlje.AddCell(cLogo);

                    //header
                    Paragraph info = new Paragraph();
                    info.Alignment = Element.ALIGN_RIGHT;
                    //prored
                    info.SetLeading(0, 1.2f);
                    info.Add(new Chunk("Međimursko Veleučilište u Čakovcu \n", fontZaglavljeBold));
                    info.Add(new Chunk("Bana Josipa Jelačića 22a \n" + "Čakovec \n", fontZaglavlje));

                    PdfPCell cInfo = new PdfPCell();
                    cInfo.AddElement(info);
                    cInfo.HorizontalAlignment = Element.ALIGN_RIGHT;
                    cInfo.Border=Rectangle.NO_BORDER;
                    tZaglavlje.AddCell(info);

                    //dodavanje tablice zaglavlja
                    pdfDokument.Add(tZaglavlje);

                    //naslov
                    Paragraph pNaslov = new Paragraph("Popis proizvoda", fontNaslov);
                    pNaslov.Alignment = Element.ALIGN_CENTER;
                    pNaslov.SpacingBefore = 20;
                    pNaslov.SpacingAfter = 20;
                    pdfDokument.Add(pNaslov);

                    //tablica za proizvode
                    PdfPTable t = new PdfPTable(5); //broj kolona
                    t.WidthPercentage = 100;
                    t.SetWidths(new float[] { 1, 3, 2, 1, 4 });

                    //zaglavlje tablice
                    t.AddCell(GenerirajCeliju("R.Br.", fontTablicaZaglavlje, tPozadinaZaglavlje, true));
                    t.AddCell(GenerirajCeliju("Ime i kontrolni broj ", fontTablicaZaglavlje, tPozadinaZaglavlje, true));
                    t.AddCell(GenerirajCeliju("Boja", fontTablicaZaglavlje, tPozadinaZaglavlje, true));
                    t.AddCell(GenerirajCeliju("Dostupnost", fontTablicaZaglavlje, tPozadinaZaglavlje, true));
                    t.AddCell(GenerirajCeliju("Kategorija", fontTablicaZaglavlje, tPozadinaZaglavlje, true));

                    //redovi
                    int i = 1;
                    foreach (Proizvod p in proizvodi)
                    {
                        t.AddCell(GenerirajCeliju(i.ToString() + ".", fontTekst, tPozadinaSadrzaj, false));
                        t.AddCell(GenerirajCeliju(p.ImeKontrolniBroj, fontTekst, tPozadinaSadrzaj, false));
                        t.AddCell(GenerirajCeliju(p.BojaProizvoda, fontTekst, tPozadinaSadrzaj, false));
                        t.AddCell(GenerirajCeliju(p.Dostupnost ? "Da" : "Ne", fontTekst, tPozadinaSadrzaj, false));
                        t.AddCell(GenerirajCeliju(p.KategorijaProizvoda?.NazivKategorije, fontTekst, tPozadinaSadrzaj, false));
                        i++;
                    }

                    //dodavanje tablice na dokument
                    pdfDokument.Add(t);
                    //mjesto i vrijeme
                    pNaslov = new Paragraph("Čakovec, " + System.DateTime.Now.ToString("dd.MM.yyyy"), fontTekst);
                    pNaslov.Alignment = Element.ALIGN_RIGHT;
                    pNaslov.SpacingBefore = 30;
                    pdfDokument.Add(pNaslov);
                }

                Podaci = mstream.ToArray();

                //pisanje broja stranice u podnozje PDFa
                using (var reader = new PdfReader(Podaci))
                {
                    using (var ms = new MemoryStream())
                    {
                        using (var stamper = new PdfStamper(reader, ms))
                        {
                            int PageCount = reader.NumberOfPages;
                            for (int i = 1;i <= PageCount;i++)
                            {
                                Rectangle pageSize = reader.GetPageSize(i);
                                PdfContentByte canvas = stamper.GetOverContent(i);

                                canvas.BeginText();
                                canvas.SetFontAndSize(bfontPodnozje, 10);

                                canvas.ShowTextAligned(PdfContentByte.ALIGN_RIGHT, $"Stranica {i} / {PageCount}", pageSize.Right - 50, 30, 0);
                                canvas.EndText();
                            }
                        }
                        Podaci = ms.ToArray();
                    }
                }
            }
        }
    }
}