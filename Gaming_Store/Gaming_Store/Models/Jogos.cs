using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Gaming_Store.Models
{
    public class Jogos
    {

        public Jogos()
        {
            // inicialização da lista de Vendas de um jogo
            Compras = new HashSet<Compras>();
       
        }

        [Key]
        public int Id { get; set; }

        [Required]
        public string Fotografia { get; set; }

        [Required]
        [StringLength(30)]
        public string Nome { get; set; }

        [Required]
        public decimal Preco { get; set; }

      

        [Required]
        [StringLength(30)]
        public string Plataforma { get; set; }

       

        // um Jogo pode ser várias vezes comprado
        public virtual ICollection<Compras> Compras { get; set; }
      

    }
}