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
    public partial class PClientes : System.Web.UI.Page
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

            CargarClientes();
        }

        protected void CargarClientes()
        {
            string m = "";
            List<Cliente> listado = objLogC.ObtenerTodo(ref m);
            gvClientes.DataSource = listado;
            gvClientes.DataBind();
        }

        protected void btnConsulta_Click(object sender, EventArgs e)
        {



        }

        protected void gvClientes_SelectedIndexChanged(object sender, EventArgs e)
        {
            string m = "";
            GridViewRow rensel = null;
            rensel = gvClientes.SelectedRow;
            string tel = rensel.Cells[5].Text;
            int idC = Convert.ToInt32(rensel.Cells[1].Text);
            txbTel.Text = rensel.Cells[5].Text;

            Cliente tempC = new Cliente()
            {
                id_Cliente = idC,
                Nombre = "",
                App = "",
                ApM = "",
                Celular = tel,
                Correo = ""
            };

            List<Pedido> pedidos = objLogC.ObtenerTodoP(tempC, ref m);
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
            DateTime fecha = DateTime.Now;
            rensel = gvPedidos.SelectedRow;
            int idP = Convert.ToInt32(rensel.Cells[1].Text);
            int idCar = Convert.ToInt32(rensel.Cells[4].Text);

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

            Carnicero tempCar = new Carnicero()
            {
                id_Carnicero = idCar,
                Nombre = "",
                Celular = "",
                Correo = "",
                Exp_anios = 0,
            };

            List<Carnicero> carnicero = objLogCar.ObtenerTodoC(tempCar, ref m);
            gvCarnicero.DataSource = carnicero;
            gvCarnicero.DataBind();
            DateTime fechahora = DateTime.Now;


            List<EntregaPedido> EntPedido = objLogEP.ObtenerTodoC(tempP, ref m);
            if (EntPedido != null)
            {
                gvEPedidos.DataSource = EntPedido;
                gvEPedidos.DataBind();

            }
            else
            {
                gvEPedidos.Visible = false;
            }
        }

        protected void gvEPedidos_SelectedIndexChanged(object sender, EventArgs e)
        {
            GridViewRow rensel = null;
            rensel = gvEPedidos.SelectedRow;
            int idR = Convert.ToInt32(rensel.Cells[3].Text);
            Repartidor tempR = new Repartidor()
            {
                id_Repartidor = idR,
                Nombre = "",
                Celular = "",
                Licencia = "",
            };
            string m = "";
            List<Repartidor> rep = objLogRep.ObtenerTodoC(tempR, ref m);
            if (rep != null)
            {
                gvRepartidor.DataSource = rep;
                gvRepartidor.DataBind();
            }
            else
            {
                gvRepartidor.Visible = false;
            }
        }
    }
}