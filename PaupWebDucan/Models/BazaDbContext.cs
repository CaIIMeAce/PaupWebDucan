using MySql.Data.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace PaupWebDucan.Models
{
    [DbConfigurationType(typeof(MySqlEFConfiguration))]
    public class BazaDbContext : DbContext
    {
        public DbSet<Proizvod> PopisProizvodaBaze { get; set; }

        

        public DbSet<Kategorije> PopisKategorija { get; set;}
    }
}