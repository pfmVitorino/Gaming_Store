﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Gaming_Store.Models
{
    public class Cliente
    {
        // vai representar os dados da tabela dos Clientes

        // criar o construtor desta classe
        // e carregar a lista dos Jogos

         public Cliente() { 
        ListaDeJogos = new HashSet<Jogos>();
            }
        [Key]
        public int Id { get; set; }

        [Required]
        public string Nome { get; set; }

        [Required]
        public string NIF{ get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        public string Morada { get; set; }

        // Um  Cliente  pode comprar 1 ou mais Jogos
        public ICollection<Jogos> ListaDeJogos { get; set; }


    }
}