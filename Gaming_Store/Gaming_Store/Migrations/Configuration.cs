namespace Gaming_Store.Migrations
{
    using Gaming_Store.Models;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<Gaming_Store.Models.JogosDB>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(Gaming_Store.Models.JogosDB context)
        {
            //  This method will be called after migrating to the latest version.

            //#############################################################
            // criação das classes Cliente, Plataforma, Jogos e Compra
            //#############################################################

            // Configuration --- SEED
            //=============================================================

            // ############################################################################################
            // adiciona Clientes
            var cliente = new System.Collections.Generic.List<Gaming_Store.Models.Cliente> {
                new Cliente  {Id = 1,Nome = "Pedro Vitorino", NIF ="23343434", Email="pedro@hotmail.com", Morada="Rua Mota Lima" },

         };
            cliente.ForEach(dd => context.Cliente.AddOrUpdate(d => d.Nome, dd));
            context.SaveChanges();

            // ############################################################################################
            // adiciona Jogos
            var jogos = new List<Gaming_Store.Models.Jogos> {
              new Jogos  {Id=1, Nome = "Hitman2", Plataforma ="XBOX ONE", Preco= 55, ClienteFK=""},
              new Jogos  {Id=2, Nome = "Red Dead Redemptiom 2", Plataforma ="PS4", Preco= 70, ClienteFK=""},
              new Jogos  {Id=3, Nome = "Fifa 19", Plataforma ="PS4", Preco= 70, ClienteFK=""},
              new Jogos  {Id=4, Nome = "Resident Evil 7", Plataforma ="PC", Preco= 70, ClienteFK=""},
              new Jogos  {Id=5, Nome = "Call of Duty Black OPS4", Plataforma ="PS4", Preco= 70, ClienteFK=""},




};

            jogos.ForEach(aa => context.Jogos.AddOrUpdate(a => a.Nome, aa));
            context.SaveChanges();


            // ############################################################################################
            // adiciona Plataformas
            var plataforma = new List<Gaming_Store.Models.Plataforma> {
                             new Plataforma  {Id=1, Nome = "Playstation4" },
                             new Plataforma  {Id=2, Nome = "PC" },
                             new Plataforma  {Id=3, Nome = "XBOX ONE" },

};

            plataforma.ForEach(vv => context.Plataforma.AddOrUpdate(v => v.Nome, vv));
            context.SaveChanges();

            // ############################################################################################
            // adiciona Compra
            var compra = new List<Gaming_Store.Models.Compra> {
                         new Compra  { Data = new DateTime(), Preco ="" , ClienteFK = "", JogoFK = ""},

};

            compra.ForEach(cc => context.Compra.Add(cc));
            context.SaveChanges();
        }

              

    }
    }


        
    

  
       
    




        
    

