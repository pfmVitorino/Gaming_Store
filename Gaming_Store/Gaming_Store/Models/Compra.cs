using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Gaming_Store.Models
{
    public class Compra
    {

        public int Id { get; set; }

        public DateTime data { get; set; }

        public decimal valor { get; set; }
    }
}