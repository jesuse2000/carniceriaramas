using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassEntidades
{
    public class Producto
    {
        public int id_prod { get; set; }
        public string NombreProd { get; set; }
        public int Peso { get; set; }
        public int Cantidad { get; set; }
        public double PrecioFinal { get; set; }
        public string NotaEspecial { get; set; }
        public int F_Pedido { get; set; }
    }
}
