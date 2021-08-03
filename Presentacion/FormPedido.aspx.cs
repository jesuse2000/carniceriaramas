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
    public partial class FormPedido : System.Web.UI.Page
    {
        LogCliente objLogC = null;
        LogPedido objLogPed = null;
        LogProducto objLogProd = null;
        LogCarnicero objLogCarn = null;
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
                objLogCarn = new LogCarnicero();
                Session["objlogCr"] = objLogCarn;
                objLogRep = new LogRepartidor();
                Session["objlogRep"] = objLogRep;
            }
            else
            {
                objLogC = (LogCliente)Session["objlogC"];
                objLogPed = (LogPedido)Session["objlogP"];
                objLogProd = (LogProducto)Session["objlogPr"];
                objLogCarn = (LogCarnicero)Session["objlogCr"];
                objLogRep = (LogRepartidor)Session["objlogRep"];
            }

            if (Session["Telefono"] != null)
            {
                string tel = Session["Telefono"].ToString();
                txbTelefono.Text = tel;

            }
            else
            {
                txbTelefono.Enabled = true;
            }

        }

        protected void btnInsertPedido_Click(object sender, EventArgs e)
        {

            Cliente tempC = new Cliente()
            {
                id_Cliente = 0,
                Nombre = "0",
                App = "0",
                ApM = "0",
                Celular = txbTelefono.Text,
                Correo = "0"
            };

            Cliente cachar = null;

            string m = "";

            cachar = objLogC.EncontradoT(tempC, ref m);

            //-----------------------------------------------
            DateTime fechahora = DateTime.Now;
            List<Carnicero> carniceros = objLogCarn.CarniceroLis(ref m);
            if (carniceros != null)
            {
                Random idr = new Random();
                int idc = idr.Next(1, carniceros.Count + 1);
                string fpago = "";
                if (ddlSucursal.Visible == false)
                {
                    fpago = ddlRepartidor.SelectedValue;
                }
                else
                {
                    fpago = ddlSucursal.SelectedValue;
                }
                Pedido temP = new Pedido()
                {
                    id_Pedido = 0,
                    FechaHora = fechahora,
                    F_Cliente = cachar.id_Cliente,
                    F_Carnicero = carniceros[idc - 1].id_Carnicero,
                    Envio = Convert.ToInt32(ddlEnvio.SelectedValue),
                    Pago = fpago
                };
                int idP = 0;
                idP = objLogPed.idd(temP, ref m);
                int peso = Convert.ToInt32(txbPeso.Text);
                int cant = Convert.ToInt32(txbCantidad.Text);
                float pf = peso * cant;
                if (idP > 0)
                {
                    Producto TemProd = new Producto()
                    {
                        id_prod = 0,
                        NombreProd = txbNomP.Text,
                        Peso = Convert.ToInt32(txbPeso.Text),
                        Cantidad = Convert.ToInt32(txbCantidad.Text),
                        PrecioFinal = pf,
                        NotaEspecial = txbNotaFinal.Text,
                        F_Pedido = idP
                    };
                    Boolean ProductoAlto = false;
                    ProductoAlto = objLogProd.Insert(TemProd, idP, ref m);

                    if (ProductoAlto != false)
                    {
                        lbResp.Text = "Pedido realizado corretamente";
                        txbPFinal.Text = Convert.ToString(pf);
                    }
                    else
                    {
                        lbResp.Text = "NO SE REALIZO CORRECTAMENTE EL PEDIDO";
                    }

                }
                else
                {
                    lbResp.Text = "NO SE REALIZO CORRECTAMENTE EL PEDIDO";
                }
                Session["Telefono"] = null;
            }
            else
            {
                lbResp.Text = "Carniceros no disponibles";
            }

        }

        protected void ddlEnvio_SelectedIndexChanged(object sender, EventArgs e)
        {
            int selec = Convert.ToInt32(ddlEnvio.SelectedValue);

            if (selec == 1)
            {
                ddlRepartidor.Visible = true;
                ddlSucursal.Visible = false;
            }
            else
            {
                ddlSucursal.Visible = true;
                ddlRepartidor.Visible = false;
            }

        }
    }
}