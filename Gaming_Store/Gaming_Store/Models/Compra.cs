using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Gaming_Store.Models
{
    public class Compra
    {

        [Key]
        public int Id { get; set; }

        [Column(TypeName = "date")] //só regista 'datas', não 'horas'.
        public DateTime Data { get; set; }

        [Required]
        public decimal Valor { get; set; }

        [ForeignKey("Cliente")]
        public int ClienteFK { get; set; }
        public virtual Cliente Cliente { get; set; }


        [ForeignKey("Jogo")]
        public int JogoFK { get; set; }
        public virtual Jogos Jogo { get; set; }
    }
}