﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Gaming_Store.Models
{
    public class Plataforma
    {

        // representa os dados da tabela da plataforma

        // criar o construtor desta classe
        // e carregar a lista de Jogos na respetiva plataforma
        public Plataforma()
        {
            ListaDeJogos = new HashSet<Jogos>();
        }
        [Key]
        public int Id { get; set; }

        [Required]
        public string Nome { get; set; }


        // especificar que um Jogo pode pertecer a uma ou mais plataformas
        public ICollection<Jogos> ListaDeJogos { get; set; }
    }
}