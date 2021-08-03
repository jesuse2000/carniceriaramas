using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassEntidades
{
    public class EntregaPedido
    {
        public int id_Entrega { get; set; }
        public int F_Pedido { get; set; }
        public int F_Repartidor { get; set; }
        public DateTime Salida { get; set; }
        public DateTime SeEntrego { get; set; }
        public string Estado { get; set; }
    }
}
