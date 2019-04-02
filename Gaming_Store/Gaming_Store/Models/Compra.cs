using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Gaming_Store.Models
{
    public class Compra
    {

        public int Id { get; set; }

        public DateTime Data { get; set; }

        public decimal Valor { get; set; }
    }
}