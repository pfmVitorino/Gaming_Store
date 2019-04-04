using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Gaming_Store.Models
{
    public class JogosDB : DbContext
    {
        // representa a Base de Dados
        // descrever as tabelas 

        // representar o 'construtor' desta classe
        // identificar onde se encontra a Base de Dados
        public JogosDB() : base("Database1") { }

        // descrever todas as tabelas
        public DbSet<Cliente> Cliente { get; set; }
        public DbSet<Jogos> Jogos { get; set; }
        public DbSet<Plataforma> Plataforma { get; set; }
        public DbSet<Compra> Compra { get; set; }

    }
}