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
    public partial class Consultas : System.Web.UI.Page
    {
        LogPedido objLogPed = null;
        LogRepartidor objLogRep = null;
        LogCarnicero objLogCar = null;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack == false)
            {
                objLogPed = new LogPedido();
                Session["objlogPed"] = objLogPed;
                objLogRep = new LogRepartidor();
                Session["objlogRep"] = objLogRep;
                objLogCar = new LogCarnicero();
                Session["objlogCarn"] = objLogCar;
            }
            else
            {
                objLogPed = (LogPedido)Session["objlogPed"];
                objLogRep = (LogRepartidor)Session["objlogRep"];
                objLogCar = (LogCarnicero)Session["objlogCarn"];
            }
            obtenerIDR();
        }

        public void obtenerIDR()
        {
            string m = "";
            int idRM = objLogPed.OBTENERIDMR(ref m);
            Label1.Text = "ID MAYOR: " + idRM;
            Repartidor temp = new Repartidor()
            {
                id_Repartidor = idRM,
                Nombre = "",
                Celular = "",
                Licencia = ""
            };

            List<Repartidor> RepMayor = objLogRep.ObtenerTodoC(temp, ref m);
                
            if (RepMayor.Count > 0)
            {
                gvPedidos.DataSource = RepMayor;
                gvPedidos.DataBind();
            }
            
            int idRMN = objLogPed.OBTENERIDMN(ref m);
            Repartidor tempRM = new Repartidor()
            {
                id_Repartidor = idRMN,
                Nombre = "",
                Celular = "",
                Licencia = ""
            };
            List<Repartidor> RepMenor = objLogRep.ObtenerTodoC(tempRM, ref m);
            if (RepMenor.Count > 0)
            {
                gvRepMenor.DataSource = RepMenor;
                gvRepMenor.DataBind();
            }

            int idCMX = objLogPed.OBTENERIDCMX(ref m);
            Carnicero tempCar = new Carnicero()
            {
                id_Carnicero = idCMX,
                Nombre = "",
                Celular = "",
                Correo = "",
                Exp_anios = 0
            };
            List<Carnicero> repCMx = objLogCar.ObtenerTodoC(tempCar, ref m);
            if (repCMx.Count > 0)
            {
                gvCarnicero.DataSource = repCMx;
                gvCarnicero.DataBind();
            }

            int idcMN = objLogPed.OBTENERIDCMN(ref m);
            Carnicero tempCarMN = new Carnicero()
            {
                id_Carnicero = idcMN,
                Nombre = "",
                Celular = "",
                Correo = "",
                Exp_anios = 0
            };
            List<Carnicero> repCMN = objLogCar.ObtenerTodoC(tempCarMN, ref m);
            if (repCMx.Count > 0)
            {
                gvCarniceroMN.DataSource = repCMN;
                gvCarniceroMN.DataBind();
            }

        }

        protected void ddlPBuscar_SelectedIndexChanged(object sender, EventArgs e)
        {
            string m = "";
            DateTime fecha = DateTime.Now;
            int idB = Convert.ToInt32(ddlPBuscar.SelectedValue);
            if (idB == 1)
            {
                Pedido idbusc = new Pedido
                {
                    id_Pedido = 0,
                    FechaHora = fecha,
                    F_Cliente = 0,
                    F_Carnicero = 0,
                    Envio = idB,
                    Pago = ""
                };
                int numT = objLogPed.ObtenerTodoPEnvi(idbusc, ref m);

                lbResp.Text = "Numero de pedidos hechos a domicilio: " + numT;

            }
            else
            {
                Pedido idbusc = new Pedido
                {
                    id_Pedido = 0,
                    FechaHora = fecha,
                    F_Cliente = 0,
                    F_Carnicero = 0,
                    Envio = idB,
                    Pago = ""
                };
                int numT = objLogPed.ObtenerTodoPEnvi(idbusc, ref m);
                lbResp.Text = "Pedidos recogidos: " + numT;
            }
        }
    }
}