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
    public partial class FProducto : System.Web.UI.Page
    {
        LogProducto objLogProd = null;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack == false)
            {

                objLogProd = new LogProducto();
                Session["objlogPr"] = objLogProd;
            }
            else
            {

                objLogProd = (LogProducto)Session["objlogPr"];

            }
            cargarlista();
        }

        protected void cargarlista()
        {
            string m = "";
            List<Producto> list = objLogProd.ProductoLis(ref m);
            if (list != null)
            {
                gvProductos.DataSource = list;
                gvProductos.DataBind();
            }
            else
            {
                gvProductos.Visible = false;
            }
        }

        protected void gvProductos_SelectedIndexChanged(object sender, EventArgs e)
        {
            string m = "";
            GridViewRow rensel = null;
            
            rensel = gvProductos.SelectedRow;
            txbNotaEspecial.Text = rensel.Cells[6].Text;
            btnActualizar.Visible = true;
            btnEliminar.Visible = true;
        }

        protected void btnActualizar_Click(object sender, EventArgs e)
        {
            string m = "";
            GridViewRow rensel = null;
            
            rensel = gvProductos.SelectedRow;
            int idP = Convert.ToInt32(rensel.Cells[1].Text);

            Producto TemProd = new Producto()
            {
                id_prod = idP,
                NombreProd = "",
                Peso = 0,
                Cantidad = 0,
                PrecioFinal = 0,
                NotaEspecial = txbNotaEspecial.Text,
                F_Pedido = 0
            };

            Boolean act = objLogProd.ActProd(TemProd, ref m);
            if (act != false)
            {
                Label1.Text = "Actualizacion exitosa";
                cargarlista();
            }
            else
            {
                Label1.Text = "Actualizacion incorrecta";
            }
        }

        protected void btnEliminar_Click(object sender, EventArgs e)
        {
            string m = "";
            GridViewRow rensel = null;

            rensel = gvProductos.SelectedRow;
            int idP = Convert.ToInt32(rensel.Cells[1].Text);

            Boolean act = objLogProd.EliminProdID(idP, ref m);
            if (act != false)
            {
                Label1.Text = "eliminacion exitosa";
                cargarlista();
            }
            else
            {
                Label1.Text = "eliminacio incorrecta";
            }
        }
    }
}