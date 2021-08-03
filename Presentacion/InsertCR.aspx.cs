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
    public partial class InsertCR : System.Web.UI.Page
    {
        LogCarnicero objLogCar = null;
        LogRepartidor objLogRep = null;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack == false)
            {
                
                objLogCar = new LogCarnicero();
                Session["objlogCarn"] = objLogCar;
                objLogRep = new LogRepartidor();
                Session["objlogRep"] = objLogRep;
            }
            else
            {
                
                objLogCar = (LogCarnicero)Session["objlogCarn"];
                objLogRep = (LogRepartidor)Session["objlogRep"];
            }
        }

        protected void ddlRCarni_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlRCarni.SelectedValue == "Carnicero")
            {
                txbCelular.Enabled = true;
                txbCorreo.Enabled = true;
                txbAnios.Enabled = true;
                txbLicencia.Enabled = false;
            }
            else
            {
                txbCorreo.Enabled = false;
                txbAnios.Enabled = false;
                txbLicencia.Enabled = true;
            }
        
        }

        protected void btnInsertCR_Click(object sender, EventArgs e)
        {
            string m = "";
            if (ddlRCarni.SelectedValue == "Carnicero")
            {
                Carnicero tempC = new Carnicero()
                {
                    id_Carnicero = 0,
                    Nombre = txbNombre.Text,
                    Celular = txbCelular.Text,
                    Correo = txbCorreo.Text,
                    Exp_anios = Convert.ToInt32(txbAnios.Text)
                };
                Boolean insert = false;
                insert = objLogCar.Insert(tempC, ref m);
                if (insert != false)
                {
                    lbResp.Text = "Carnicero dado de alta";
                }
                else
                {
                    lbResp.Text = "Alta no exitosa";
                }
            }
            else
            {
                Repartidor tempR = new Repartidor()
                {
                    id_Repartidor = 0,
                    Nombre = txbNombre.Text,
                    Celular = txbCelular.Text,
                    Licencia = txbLicencia.Text
                };
                Boolean insert = false;
                insert = objLogRep.Insert(tempR, ref m);
                if (insert != false)
                {
                    lbResp.Text = "Repartidor dado de alta";
                }
                else
                {
                    lbResp.Text = "Alta no exitosa";
                }
            }
        }
    }
}