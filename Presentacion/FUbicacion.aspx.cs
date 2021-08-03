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
    public partial class FUbicacion : System.Web.UI.Page
    {
        LogUbicacion objLogU = null;
        LogCliente objLogC = null;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack == false)
            {
                objLogU = new LogUbicacion();
                Session["objlogU"] = objLogU;
                objLogC = new LogCliente();
                Session["objlogC"] = objLogC;

            }
            else
            {
                objLogU = (LogUbicacion)Session["objlogU"];
                objLogC = (LogCliente)Session["objlogC"];
            }
            cargaUbicacion();
        }

        protected void cargaUbicacion()
        {
            string m = "";
            List<Ubicacion> ubicaciones = objLogU.Ubicaciones(ref m);
            if (ubicaciones != null)
            {
                gvUbicacion.DataSource = ubicaciones;
                gvUbicacion.DataBind();
                gvUbAct.DataSource = ubicaciones;
                gvUbAct.DataBind();
            }
            else
            {
                gvUbicacion.Visible = false;
            }

            List<Cliente> Clientes = objLogC.Clientes(ref m);
            ddlClientes.Items.Clear();
            if (Clientes != null)
            {
                for (int i = 0; i < Clientes.Count; i++)
                {
                    ddlClientes.Items.Add(new ListItem(Clientes[i].Nombre + " " + Clientes[i].App + " " + Clientes[i].ApM, Convert.ToString(Clientes[i].id_Cliente)));
                }
            }
            else
            {
                ddlClientes.Visible = false;
            }
        }

        protected void btnInsertar_Click(object sender, EventArgs e)
        {
            string m = "";
            Ubicacion tempu = new Ubicacion
            {
                id_ubicacion = 0,
                Colonia = txbColonia.Text,
                Calleynumero = txbCalle.Text,
                Municipio = txbMunicipio.Text,
                Ciudad = txbCiudad.Text,
                Referencia = txbReferencia.Text,
                Caracteristica = txbCaracteristica.Text,
                CP = txbCP.Text,
                F_Cliente = Convert.ToInt32(ddlClientes.Text)
            };

            Boolean conf = false;
            conf = objLogU.InsertU(tempu, ref m);

            if (conf != false)
            {
                lbResp.Text = "Dado de alta Correctamente";
                cargaUbicacion();
            }
            else
            {
                lbResp.Text = "No se pudo dar de alta correctamente: " + m;
            }
            
        }

        protected void gvUbicacion_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        protected void btnEliminar_Click(object sender, EventArgs e)
        {
            string m = "";
            GridViewRow rensel = null;
            rensel = gvUbicacion.SelectedRow;
            int idUE = Convert.ToInt32(rensel.Cells[1].Text);
            Boolean eliminar = false;
            eliminar = objLogU.EliminU(idUE, ref m);

            if (eliminar != false)
            {
                lbResp.Text = "Eliminado Correctamente";
                cargaUbicacion();
            }
            else
            {
                lbResp.Text = "Eliminacion incorrecta";
            }
        }

        protected void gvUbAct_SelectedIndexChanged(object sender, EventArgs e)
        {
            GridViewRow rensel = null;
            rensel = gvUbAct.SelectedRow;
            txbIUbicaAct.Text = rensel.Cells[1].Text;
            txbCAct.Text = rensel.Cells[2].Text;
            txbCaAct.Text = rensel.Cells[3].Text;
            txbMAct.Text = rensel.Cells[4].Text;
            txbCiAct.Text = rensel.Cells[5].Text;
            txbRAct.Text = rensel.Cells[6].Text;
            txbCaraAct.Text = rensel.Cells[7].Text;
            txbCodAct.Text = rensel.Cells[8].Text;
            txbIUbicaAct.Enabled = false;
        }

        protected void btnActUb_Click(object sender, EventArgs e)
        {
            string m = "";
            Ubicacion tempu = new Ubicacion
            {
                id_ubicacion = Convert.ToInt32(txbIUbicaAct.Text),
                Colonia = txbCAct.Text,
                Calleynumero = txbCaAct.Text,
                Municipio = txbMAct.Text,
                Ciudad = txbCiAct.Text,
                Referencia = txbRAct.Text,
                Caracteristica = txbCaraAct.Text,
                CP = txbCodAct.Text,
                F_Cliente = 0
            };

            Boolean act = false;
            act = objLogU.ActUb(tempu, ref m);
            if (act != false) {
                cargaUbicacion();
                lbResp.Text = "Actualizado Correctamente";
            }
            else
            {
                lbResp.Text = "Actulizacion fallida";
            }
        }
    }
}