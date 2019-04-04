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
        public string Preco { get; set; }

        [ForeignKey("Clientes")]
        public string ClienteFK { get; set; }
        public virtual Cliente Clientes { get; set; }


        [ForeignKey("Jogo")]
        public string JogoFK { get; set; }
        public virtual Jogos Jogo { get; set; }
    }
}