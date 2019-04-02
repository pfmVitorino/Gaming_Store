using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Gaming_Store.Models
{
    public class JogosDB : DbContext
    {
        public DbSet<Cliente> Cliente { get; set; }
        public DbSet<Jogos> Jogos { get; set; }
        public DbSet<Plataforma> Plataforma { get; set; }
        public DbSet<Compra> Compra { get; set; }

    }
}