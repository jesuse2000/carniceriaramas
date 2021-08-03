using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ClassEntidades;
using ClassLogicaNegocios;

namespace Presentacion
{
    public partial class PRepatidor : System.Web.UI.Page
    {
        LogRepartidor objLogRep = null;
        LogEntregaPedido objLogEP = null;
        LogPedido objLogPed = null;


        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack == false)
            {
                objLogEP = new LogEntregaPedido();
                Session["objlogEP"] = objLogEP;
                objLogPed = new LogPedido();
                Session["objlogPed"] = objLogPed;
                objLogRep = new LogRepartidor();
                Session["objlogRep"] = objLogRep;
            }
            else
            {
                objLogEP = (LogEntregaPedido)Session["objlogEP"];
                objLogPed = (LogPedido)Session["objlogPed"];
                objLogRep = (LogRepartidor)Session["objlogRep"];
            }
            CargaRepartidor();
        }

        protected void CargaRepartidor()
        {
            string m = "";
            List<Repartidor> todos = objLogRep.Repartidores(ref m);
            gvRepartidores.DataSource = todos;
            gvRepartidores.DataBind();
        }

        protected void gvRepartidores_SelectedIndexChanged(object sender, EventArgs e)
        {
            string m = "";
            GridViewRow rensel = null;
            rensel = gvRepartidores.SelectedRow;
            int idR = Convert.ToInt32(rensel.Cells[1].Text);
            Repartidor temp = new Repartidor()
            {
                id_Repartidor = idR,
                Nombre = "",
                Celular = "",
                Licencia = ""
            };

            List<EntregaPedido> cachados = objLogEP.ObtenerTodosR(temp, ref m);

            if (cachados != null)
            {
                gvEntrega.DataSource = cachados;
                gvEntrega.DataBind();
            }
            else
            {
                gvEntrega.Visible = false;
            }

        }

        protected void gvEntrega_SelectedIndexChanged(object sender, EventArgs e)
        {
            string m = "";
            DateTime fechahora = DateTime.Now;
            GridViewRow rensel = null;
            rensel = gvRepartidores.SelectedRow;

            int idR = Convert.ToInt32(rensel.Cells[1].Text);
            Pedido temp = new Pedido()
            {
                id_Pedido = idR,
                FechaHora = fechahora,
                F_Cliente = 0,
                F_Carnicero = 0,
                Envio = 0,
                Pago = ""
            };
            List<Pedido> pedidos = objLogPed.ObtenerTodoPe(temp, ref m);

            gvPedidos.DataSource = pedidos;
            gvPedidos.DataBind();
        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string m = "";
            GridViewRow rensel = null;
            DateTime fecha = DateTime.Now;
            rensel = gvPedidos.SelectedRow;
            int idP = Convert.ToInt32(rensel.Cells[1].Text);

            Pedido tempP = new Pedido()
            {
                id_Pedido = idP,
                FechaHora = fecha,
                F_Cliente = 0,
                F_Carnicero = 0,
                Envio = 0,
                Pago = ""
            };

            List<Producto> productos = objLogPed.ObtenerTodoP(tempP, ref m);
            gvProducto.DataSource = productos;
            gvProducto.DataBind();
        }
    }
}