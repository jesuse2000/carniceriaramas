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
    public partial class FRepartidor : System.Web.UI.Page
    {
        LogRepartidor objLogRep = null;
        LogEntregaPedido objLogEP = null;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack == false)
            {
                objLogEP = new LogEntregaPedido();
                Session["objlogEP"] = objLogEP;
                objLogRep = new LogRepartidor();
                Session["objlogRep"] = objLogRep;

            }
            else
            {
                objLogEP = (LogEntregaPedido)Session["objlogEP"];
                objLogRep = (LogRepartidor)Session["objlogRep"];

            }
            CargarRepartidores();
        }
        protected void CargarRepartidores()
        {
            string m = "";
            List<Repartidor> todos = objLogRep.Repartidores(ref m);
            if (todos.Count > 0)
            {
                gvRepartidor.DataSource = todos;
                gvRepartidor.DataBind();
            }
            else
            {
                gvRepartidor.Visible = false;
            }
        }

        protected void btnEliminar_Click(object sender, EventArgs e)
        {
            string m = "";
            GridViewRow rensel = null;
            rensel = gvRepartidor.SelectedRow;
            int idUE = Convert.ToInt32(rensel.Cells[1].Text);
            Boolean eliminar = objLogRep.EliminRepEP(idUE, ref m);
            if (eliminar != false)
            {
                Boolean eliminar2 = objLogRep.EliminRep(idUE, ref m);
                if (eliminar2 != false)
                {
                    Label1.Text = "Eliminacion Completa";
                    CargarRepartidores();
                }
                else { Label1.Text = "Eliminacion incompleta"; }
            }
            else { Label1.Text = "Eliminacion incompleta"; }
        }

        protected void gvRepartidor_SelectedIndexChanged(object sender, EventArgs e)
        {
            string m = "";
            GridViewRow rensel = null;
            rensel = gvRepartidor.SelectedRow;
            int idUE = Convert.ToInt32(rensel.Cells[1].Text);

            txbCelular.Text = (rensel.Cells[3].Text);
        }

        protected void btnActualizar_Click(object sender, EventArgs e)
        {
            string m = "";
            GridViewRow rensel = null;
            rensel = gvRepartidor.SelectedRow;
            int idUE = Convert.ToInt32(rensel.Cells[1].Text);

            Repartidor tempR = new Repartidor()
            {
                id_Repartidor = idUE,
                Nombre = "",
                Celular = txbCelular.Text,
                Licencia = ""
            };

            Boolean repartidorACT = objLogRep.ActRep(tempR, ref m);

            if (repartidorACT != false)
            {
                Label1.Text = "Actualizacion correcta";
                CargarRepartidores();
            }
            else
            {
                Label1.Text = "Actualizacion incorrecta";
            }
        }
    }
}