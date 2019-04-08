﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Gaming_Store.Models
{
    public class Plataforma_Jogos
    {

        [Key]
        public int Id { get; set; }

        public int PlataformasFK { get; set; }
        [ForeignKey("PlataformasFK")]
        public virtual Plataformas Plataformas { get; set; }

       
        public int JogosFK { get; set; }
        [ForeignKey("JogosFK")]
        public virtual Jogos Jogos { get; set; }
    }

   

}