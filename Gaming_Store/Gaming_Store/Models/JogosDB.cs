﻿using System;
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
        public JogosDB() : base("Gaming_Store.Models.JogosDB") { }

        // descrever todas as tabelas
        public DbSet<Clientes> Clientes { get; set; }
        public DbSet<Jogos> Jogos { get; set; }
        public DbSet<Plataformas> Plataformas { get; set; }
        public DbSet<Compras> Compras { get; set; }
        public DbSet<Plataforma_Jogos> Plataforma_Jogos { get; set; }
        public DbSet<Detalhes_Compra> Detalhes_Compra { get; set; }

    }
}