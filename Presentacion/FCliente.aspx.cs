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
    public partial class FCliente : System.Web.UI.Page
    {
        LogCliente objLogC = null;
        LogPedido objLogPed = null;
        LogProducto objLogProd = null;
        LogEntregaPedido objLogEP = null;
        LogUbicacion objLogU = null;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack == false)
            {
                objLogC = new LogCliente();
                Session["objlogC"] = objLogC;
                objLogPed = new LogPedido();
                Session["objlogP"] = objLogPed;
                objLogProd = new LogProducto();
                Session["objlogPr"] = objLogProd;
                objLogEP = new LogEntregaPedido();
                Session["objlogEP"] = objLogEP;
                objLogU = new LogUbicacion();
                Session["objlogUB"] = objLogU;
            }
            else
            {
                objLogC = (LogCliente)Session["objlogC"];
                objLogPed = (LogPedido)Session["objlogP"];
                objLogProd = (LogProducto)Session["objlogPr"];
                objLogEP = (LogEntregaPedido)Session["objlogEP"];
                objLogU = (LogUbicacion)Session["objlogUB"];
            }
            TODOSCLIENTES();

        }

        protected void TODOSCLIENTES()
        {
            string m = "";
            List<Cliente> Clientes = objLogC.Clientes(ref m);
            if (Clientes != null)
            {
                gvClientes.DataSource = Clientes;
                gvClientes.DataBind();
            }
            else
            {
                gvClientes.Visible = false;
            }
        }

        protected void btnInsertarCliente_Click(object sender, EventArgs e)
        {
            string m = "";
            Cliente tempc = new Cliente
            {
                id_Cliente = 0,
                Nombre = txbNombre.Text,
                App = txbApp.Text,
                ApM = txbApM.Text,
                Celular = txbCelular.Text,
                Correo = txbCorreo.Text
            };
            int idC = 0;
            idC = objLogC.idd(tempc, ref m);

            if (idC > 0) {
                lbResp.Text = "Agregado correctamente";
                TODOSCLIENTES();
            }
            else
            {
                lbResp.Text = "Agregado incorrectamente";
            }
        }

        protected void gvClientes_SelectedIndexChanged(object sender, EventArgs e)
        {
            string m = "";
            GridViewRow rensel = null;
            DateTime fecha = DateTime.Now;
            rensel = gvClientes.SelectedRow;
            int idP = Convert.ToInt32(rensel.Cells[1].Text);

            txbNombre.Text = (rensel.Cells[2].Text);
            txbApp.Text = (rensel.Cells[3].Text);
            txbApM.Text = (rensel.Cells[4].Text);
            txbNombre.Enabled = false;
            txbApp.Enabled = false;
            txbApM.Enabled = false;

            txbCelular.Text = (rensel.Cells[5].Text);
            txbCorreo.Text = (rensel.Cells[6].Text);

            btnEliminar.Visible = true;
            btnActualizar.Visible = true;
        }

        protected void btnActualizar_Click(object sender, EventArgs e)
        {
            string m = "";
            GridViewRow rensel = null;
            DateTime fecha = DateTime.Now;
            rensel = gvClientes.SelectedRow;

            int idP = Convert.ToInt32(rensel.Cells[1].Text);
            string corre = txbCorreo.Text;
            string cel = txbCelular.Text;
            Boolean Act = false;
            Act = objLogC.ActClient(corre, cel, idP, ref m);
            if (Act != false)
            {
                lbResp.Text = "Actualizacion exitosa";
                TODOSCLIENTES();
            }
            else
            {
                lbResp.Text = "Actualizacion incorrecta";
            }
        }

        protected void btnEliminar_Click(object sender, EventArgs e)
        {
            string m = "";
            GridViewRow rensel = null;
            rensel = gvClientes.SelectedRow;

            int idP = Convert.ToInt32(rensel.Cells[1].Text);
            List<Pedido> Pedidos = objLogPed.EliminarPedidos(idP, ref m);
            Boolean eliminaciones = false;
            Boolean eliminaciones2 = false;
            Boolean eliminaciones3 = false;
            Boolean eliminaciones4 = false;
            Boolean eliminaciones5 = false;

            eliminaciones5 = objLogU.EliminUC(idP, ref m);

            if (eliminaciones5 != false)
            {
                lbResp.Text = "Eliminacion correcta";
            }

            for (int i = 0; i < Pedidos.Count; i++)
            {
                eliminaciones2 = objLogProd.EliminProd(Pedidos[i].id_Pedido, ref m);
                //eliminaciones = objLogPed.EliminPS(Pedidos[i].id_Pedido, ref m);

                if (eliminaciones != false)
                {
                    lbResp.Text = "Eliminacion correcta";
                }
                else
                {
                    lbResp.Text = "Eliminacion incorrecta";
                }
            }

            for (int i = 0; i < Pedidos.Count; i++)
            {
                //eliminaciones2 = objLogProd.EliminProd(Pedidos[i].id_Pedido, ref m);
                eliminaciones3 = objLogEP.EliminEnv(Pedidos[i].id_Pedido, ref m);

                if (eliminaciones3 != false)
                {
                    lbResp.Text = "Eliminacion correcta";
                }
                else
                {
                    lbResp.Text = "Eliminacion incorrecta";
                }
            }


            for (int i = 0; i < Pedidos.Count; i++)
            {
                //eliminaciones2 = objLogProd.EliminProd(Pedidos[i].id_Pedido, ref m);
                eliminaciones2 = objLogPed.EliminPS(Pedidos[i].id_Pedido, ref m);

                if (eliminaciones2 != false)
                {
                    lbResp.Text = "Eliminacion correcta";
                }
                else
                {
                    lbResp.Text = "Eliminacion incorrecta";
                }
            }

            eliminaciones4 = objLogC.ElimCli(idP, ref m);
            if (eliminaciones4 != false)
            {
                TODOSCLIENTES();
            }
            else
            {
                lbResp.Text = "algo fallo";
            }
        }
    }
}