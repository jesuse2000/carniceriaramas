using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassEntidades
{
    public class Pedido
    {
        public int id_Pedido { get; set; }
        public DateTime FechaHora { get; set; }
        public int F_Cliente { get; set; }
        public int F_Carnicero { get; set; }
        public int Envio { get; set; }
        public string Pago { get; set; }
    }
}
