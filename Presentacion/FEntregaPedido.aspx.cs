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
    public partial class FEntregaPedido : System.Web.UI.Page
    {
        LogCliente objLogC = null;
        LogPedido objLogPed = null;
        LogCarnicero objLogCar = null;
        LogEntregaPedido objLogEP = null;
        LogRepartidor objLogRep = null;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack == false)
            {
                objLogC = new LogCliente();
                Session["objlogC"] = objLogC;
                objLogPed = new LogPedido();
                Session["objlogPed"] = objLogPed;
                objLogCar = new LogCarnicero();
                Session["objlogCarn"] = objLogCar;
                objLogEP = new LogEntregaPedido();
                Session["objlogEP"] = objLogEP;
                objLogRep = new LogRepartidor();
                Session["objlogRep"] = objLogRep;
            }
            else
            {
                objLogC = (LogCliente)Session["objlogC"];
                objLogPed = (LogPedido)Session["objlogPed"];
                objLogCar = (LogCarnicero)Session["objlogCarn"];
                objLogEP = (LogEntregaPedido)Session["objlogEP"];
                objLogRep = (LogRepartidor)Session["objlogRep"];
            }
            CARGAENP();
        }

        protected void CARGAENP() {
            string m = "";
            List<EntregaPedido> pedidos = objLogEP.EntregaLis(ref m);
            if (pedidos != null)
            {
                gvPedidos.DataSource = pedidos;
                gvPedidos.DataBind();
            }
            else
            {
                gvPedidos.Visible = false;
            }
        }

        protected void gvPedidos_SelectedIndexChanged(object sender, EventArgs e)
        {
            string m = "";
            GridViewRow rensel = null;
            rensel = gvPedidos.SelectedRow;
            DateTime fechahora = DateTime.Now;
            int idC = Convert.ToInt32(rensel.Cells[1].Text);


        }

        protected void btnEliminar_Click(object sender, EventArgs e)
        {
            string m = "";
            GridViewRow rensel = null;
            rensel = gvPedidos.SelectedRow;
            DateTime fechahora = DateTime.Now;
            int idC = Convert.ToInt32(rensel.Cells[1].Text);

            Boolean elim = objLogEP.EliminEnt(idC, ref m);

            if (elim != false)
            {
                Label1.Text = "Eliminacion correcta";
                CARGAENP();
            }
            else
            {
                Label1.Text = "Eliminacion incorrecta";
            }
        }

        protected void btnActualizar_Click(object sender, EventArgs e)
        {
            string m = "";
            GridViewRow rensel = null;
            rensel = gvPedidos.SelectedRow;
            DateTime fechahora = DateTime.Now;
            int idC = Convert.ToInt32(rensel.Cells[1].Text);
            EntregaPedido tempP = new EntregaPedido()
            {
                id_Entrega = idC,
                F_Pedido = 0,
                F_Repartidor = 0,
                Salida = fechahora,
                SeEntrego = fechahora,
                Estado = txbActEnt.Text
            };
            Boolean elim = objLogEP.ActEnt(tempP, ref m);

            if (elim != false)
            {
                Label1.Text = "Actualizacion correcta";
                CARGAENP();
            }
            else
            {
                Label1.Text = "Actualizacion incorrecta";
            }

            
        }
    }
}