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
    public partial class EPedido : System.Web.UI.Page
    {
        LogCliente objLogC = null;
        LogPedido objLogPed = null;
        LogProducto objLogProd = null;
        LogEntregaPedido objLogEP = null;
        LogRepartidor objLogRep = null;

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
                objLogRep = new LogRepartidor();
                Session["objlogRep"] = objLogRep;
            }
            else
            {
                objLogC = (LogCliente)Session["objlogC"];
                objLogPed = (LogPedido)Session["objlogP"];
                objLogProd = (LogProducto)Session["objlogPr"];
                objLogEP = (LogEntregaPedido)Session["objlogEP"];
                objLogRep = (LogRepartidor)Session["objlogRep"];
            }
        }

        protected void btnInsertar_Click(object sender, EventArgs e)
        {

            Random idr = new Random();

            string m = "";
            List<Repartidor> repartidores = objLogRep.Repartidores(ref m);
            if (repartidores.Count > 0)
            {
                int idc = idr.Next(1, repartidores.Count + 1);
                DateTime fechahora = DateTime.Now;
                Cliente temp = new Cliente()
                {
                    id_Cliente = 0,
                    Nombre = "",
                    App = "",
                    ApM = "",
                    Celular = txbTel.Text,
                    Correo = ""
                };
                int idE = 0;

                idE = objLogPed.PEncontrado(temp, ref m);
                if (idE > 0)
                {
                    lbResp.Text = "Id encontrado: " + idE;
                    EntregaPedido tempEP = new EntregaPedido()
                    {
                        id_Entrega = 0,
                        F_Pedido = idE,
                        F_Repartidor = repartidores[idc - 1].id_Repartidor,
                        Salida = fechahora,
                        SeEntrego = fechahora,
                        Estado = ""
                    };
                    Boolean insertado = false;
                    insertado = objLogEP.Insert(tempEP, idE, ref m);
                    if (insertado != false)
                    {
                        lbResp.Text = "Envio de Producto exitoso";
                    }
                    else
                    {
                        lbResp.Text = "No solicito el envio";
                    }
                }
                else
                {
                    lbResp.Text = "No solicito el envio";
                }
            }
            else
            {
                lbResp.Text = "Repartidores no disponibles";
            }
        }

        protected void btnActualizar_Click(object sender, EventArgs e)
        {
            Random idr = new Random();
            int idc = idr.Next(1, 3);
            string m = "";
            DateTime fechahora = DateTime.Now;
            Cliente temp = new Cliente()
            {
                id_Cliente = 0,
                Nombre = "",
                App = "",
                ApM = "",
                Celular = txbTel.Text,
                Correo = ""
            };
            int idE = 0;

            idE = objLogPed.PEncontrado(temp, ref m);
            if (idE > 0)
            {
                lbResp.Text = "Id encontrado: " + idE;
                EntregaPedido tempEP = new EntregaPedido()
                {
                    id_Entrega = 0,
                    F_Pedido = idE,
                    F_Repartidor = idc,
                    Salida = fechahora,
                    SeEntrego = fechahora,
                    Estado = ddlEstado.SelectedValue
                };
                Boolean insertado = false;
                insertado = objLogEP.Actualizacion(tempEP, idE, ref m);
                if (insertado != false)
                {
                    lbResp2.Text = "Envio de Producto exitoso";
                }
                else
                {
                    lbResp2.Text = "No solicito el envio";
                }
            }
            else
            {
                lbResp.Text = "No solicito el envio";
            }
        }
    }
}