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
    public partial class FPedidos : System.Web.UI.Page
    {
        LogPedido objLogPed = null;
        LogEntregaPedido objLogEP = null;
        LogProducto objLogProd = null;


        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack == false)
            {
                
                objLogPed = new LogPedido();
                Session["objlogPed"] = objLogPed;
                objLogEP = new LogEntregaPedido();
                Session["objlogEP"] = objLogEP;
                objLogProd = new LogProducto();
                Session["objlogProd"] = objLogProd;

            }
            else
            {
                
                objLogPed = (LogPedido)Session["objlogPed"];
                objLogProd = (LogProducto)Session["objlogProd"];
                objLogEP = (LogEntregaPedido)Session["objlogEP"];
                
            }
            LISTPEDIDOS();
        }

        protected void LISTPEDIDOS()
        {
            string m = "";
            List<Pedido> pedidos = new List<Pedido>();
            pedidos = objLogPed.LISTPEDIDO(ref m);

            if (pedidos.Count != 0)
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
            int idC = Convert.ToInt32(rensel.Cells[5].Text);
            if (idC == 1)
            {
                ddlActPedido.Visible = true;
                ddlActPS.Visible = false;
            }
            else
            {
                ddlActPS.Visible = true;
                ddlActPedido.Visible = false;
            }

        }

        protected void btnEliminar_Click(object sender, EventArgs e)
        {
            string m = "";
            GridViewRow rensel = null;
            rensel = gvPedidos.SelectedRow;
            int idC = Convert.ToInt32(rensel.Cells[1].Text);
            
            Boolean eliminpprd = objLogProd.EliminProd(idC, ref m);
            if (eliminpprd != false)
            {
                Boolean eliminarEPP = objLogEP.EliminEnv(idC, ref m);
                if (eliminarEPP != false)
                {
                    Boolean eliminarP = objLogPed.EliminPedido(idC, ref m);
                    if (eliminarP != false)
                    {
                        Label1.Text = "Eliminacion Exitosa";
                    }
                }
            }
            else
            {
                Label1.Text = "Eliminacion fallida";
            }
            LISTPEDIDOS();
        }

        protected void btnActPedido_Click(object sender, EventArgs e)
        {
            string m = "";
            GridViewRow rensel = null;
            DateTime fechahora = DateTime.Now;
            rensel = gvPedidos.SelectedRow;
            int idC = Convert.ToInt32(rensel.Cells[1].Text);
            string envio = "";
            if (ddlActPedido.Visible != false)
            {
                envio = ddlActPedido.SelectedValue.ToString();
            }
            else
            {
                envio = ddlActPS.SelectedValue.ToString();
            }

            Pedido temP = new Pedido()
            {
                id_Pedido = idC,
                FechaHora = fechahora,
                F_Cliente = 0,
                F_Carnicero = 0,
                Envio = 0,
                Pago = envio
            };

            Boolean actualizado = objLogPed.ActPedido(temP, ref m);

            if (actualizado != false)
            {
                Label1.Text = "Actualizado correcto";
                LISTPEDIDOS();
            }
            else
            {
                Label1.Text = "Actualizacion incorrecta";
            }
        }
    }
}