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
    public partial class FCarnicero : System.Web.UI.Page
    {

        LogCliente objLogC = null;
        LogPedido objLogPed = null;
        LogProducto objLogProd = null;
        LogEntregaPedido objLogEP = null;
        LogUbicacion objLogU = null;
        LogCarnicero objLogCar = null;
        
            

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
                objLogCar = new LogCarnicero();
                Session["objlogCarn"] = objLogCar;
            }
            else
            {
                objLogC = (LogCliente)Session["objlogC"];
                objLogPed = (LogPedido)Session["objlogP"];
                objLogProd = (LogProducto)Session["objlogPr"];
                objLogCar = (LogCarnicero)Session["objlogCarn"];
                objLogEP = (LogEntregaPedido)Session["objlogEP"];
                objLogU = (LogUbicacion)Session["objlogUB"];
            }
            CargaCarniceros();
        }

        protected void CargaCarniceros()
        {
            string m = "";
            List<Carnicero> carniceros = objLogCar.CarniceroLis(ref m);

            if (carniceros != null)
            {
                gvCarnicero.DataSource = carniceros;
                gvCarnicero.DataBind();
            }
            else
            {
                gvCarnicero.Visible = false;
            }

        }

        protected void btnActualizar_Click(object sender, EventArgs e)
        {
            string m = "";
            GridViewRow rensel = null;
            rensel = gvCarnicero.SelectedRow;
            int idc = Convert.ToInt32(rensel.Cells[1].Text);


            Carnicero tempC = new Carnicero()
            {
                id_Carnicero = idc,
                Nombre = "",
                Celular = txbCelular.Text,
                Correo = txbCorreo.Text,
                Exp_anios = 0
            };

            Boolean act = objLogCar.ActCar(tempC, ref m);
            if (act != false)
            {
                Label1.Text = "Actualizacion correcta";
                CargaCarniceros();
            }
            else
            {
                Label1.Text = "Actualizacion incorrecta";
            }
        }

        protected void gvCarnicero_SelectedIndexChanged(object sender, EventArgs e)
        {
            GridViewRow rensel = null;
            rensel = gvCarnicero.SelectedRow;
            txbCelular.Text = rensel.Cells[3].Text;
            txbCorreo.Text = rensel.Cells[4].Text;
            btnActualizar.Visible = true;
            btnEliminar.Visible = true;
        }

        protected void btnEliminar_Click(object sender, EventArgs e)
        {
            GridViewRow rensel = null;
            rensel = gvCarnicero.SelectedRow;
            string m = "";
            Boolean eliminados = false;
            Boolean eliminados2 = false;
            Boolean eliminaciones = false;
            Boolean eliminaciones3 = false;
            int idc = Convert.ToInt32(rensel.Cells[1].Text);
            List<Pedido> Pedidos = objLogPed.EliminarProductosCar(idc, ref m);

            for (int i = 0; i < Pedidos.Count; i++)
            {
                eliminados2 = objLogProd.EliminProd(Pedidos[i].id_Pedido, ref m);
                
            }

            for (int i = 0; i < Pedidos.Count; i++)
            {
                //eliminaciones2 = objLogProd.EliminProd(Pedidos[i].id_Pedido, ref m);
                eliminaciones3 = objLogEP.EliminEnv(Pedidos[i].id_Pedido, ref m);

                if (eliminaciones3 != false)
                {
                    Label1.Text = "Eliminacion correcta";
                }
                else
                {
                    Label1.Text = "Eliminacion incorrecta";
                }
            }

            eliminaciones = objLogPed.EliminCarP(idc, ref m);

            eliminados = objLogCar.EliminCar(idc, ref m);

            if (eliminados != false)
            {
                Label1.Text = "Eliminado correcto";
            }
            else
            {
                Label1.Text = "Eliminado incorrecto";
            }
            CargaCarniceros();
        }
    }
}