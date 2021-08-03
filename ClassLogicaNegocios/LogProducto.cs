using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using ClassEntidades;
using ClassAccesoSQL;

namespace ClassLogicaNegocios
{
    public class LogProducto
    {
        private ClaseConeccion objacceso =
           new ClaseConeccion(@"Data Source=DESKTOP-20LP090; Initial Catalog=PedidosCarniceria; Integrated Security = true;");
        public Boolean Insert(Producto pd, int idC, ref string mens_salida)
        {
            SqlParameter[] params1 = new SqlParameter[7];
            params1[0] = new SqlParameter
            {
                ParameterName = "idP",
                SqlDbType = SqlDbType.Int,
                Direction = ParameterDirection.Input,
                Value = pd.id_prod
            };
            params1[1] = new SqlParameter
            {
                ParameterName = "NomP",
                SqlDbType = SqlDbType.VarChar,
                Size = 90,
                Direction = ParameterDirection.Input,
                Value = pd.NombreProd
            };
            params1[2] = new SqlParameter
            {
                ParameterName = "Peso",
                SqlDbType = SqlDbType.Int,
                Direction = ParameterDirection.Input,
                Value = pd.Peso
            };
            params1[3] = new SqlParameter
            {
                ParameterName = "Cantidad",
                SqlDbType = SqlDbType.SmallInt,
                Direction = ParameterDirection.Input,
                Value = pd.Cantidad
            };
            params1[4] = new SqlParameter
            {
                ParameterName = "Pre",
                SqlDbType = SqlDbType.Float,
                Direction = ParameterDirection.Input,
                Value = pd.PrecioFinal
            };
            params1[5] = new SqlParameter
            {
                ParameterName = "NEsp",
                SqlDbType = SqlDbType.VarChar,
                Size = 120,
                Direction = ParameterDirection.Input,
                Value = pd.NotaEspecial
            };
            params1[6] = new SqlParameter
            {
                ParameterName = "FPed",
                SqlDbType = SqlDbType.VarChar,
                Size = 100,
                Direction = ParameterDirection.Input,
                Value = pd.F_Pedido
            };

            string sentencia = "Insert into Producto values(@NomP,@Peso,@Cantidad,(@Cantidad*@Peso),@NEsp,@FPed);";

            Boolean salida = false;

            salida = objacceso.ModificaBDunPocoMasSegura(sentencia, objacceso.AbrirConexion(ref mens_salida), ref mens_salida, params1);

            return salida;
        }
        //-------------------------------------------------------------------
        public Boolean EliminProd(int idE, ref string mens_salida)
        {
            SqlParameter[] params1 = new SqlParameter[1];
            params1[0] = new SqlParameter
            {
                ParameterName = "idE",
                SqlDbType = SqlDbType.Int,
                Direction = ParameterDirection.Input,
                Value = idE
            };


            string sentencia = "DELETE FROM Producto WHERE F_Pedido = @idE; ";

            Boolean salida = false;

            salida = objacceso.ModificaBDunPocoMasSegura(sentencia, objacceso.AbrirConexion(ref mens_salida), ref mens_salida, params1);

            return salida;
        }

        public List<Producto> ProductoLis(ref string mens_salida)
        {
            List<Producto> envP = new List<Producto>();

            string query = @"select * from Producto;";

            SqlDataReader cont_atrapa = null;

            cont_atrapa = objacceso.ConsultarReader(query, objacceso.AbrirConexion(ref mens_salida),
                ref mens_salida);

            Producto devu = null;

            if (cont_atrapa.HasRows == true)
            {
                while (cont_atrapa.Read())
                {
                    devu = new Producto
                    {
                        id_prod = Convert.ToInt32(cont_atrapa["id_prod"]),
                        NombreProd = Convert.ToString(cont_atrapa["NombreProd"]),
                        Peso = Convert.ToInt32(cont_atrapa["Peso"]),
                        Cantidad = Convert.ToInt32(cont_atrapa["Cantidad"]),
                        PrecioFinal = Convert.ToDouble(cont_atrapa["PrecioFinal"]),
                        NotaEspecial = Convert.ToString(cont_atrapa["NotaEspecial"]),
                        F_Pedido = Convert.ToInt32(cont_atrapa["F_Pedido"])
                    };
                    envP.Add(devu);
                }
            }
            else
            {
                envP = null;
            }
            return envP;
        }

        public Boolean ActProd(Producto Prod, ref string mens_salida)
        {
            SqlParameter[] params1 = new SqlParameter[7];
            params1[0] = new SqlParameter
            {
                ParameterName = "id_prod",
                SqlDbType = SqlDbType.Int,
                Direction = ParameterDirection.Input,
                Value = Prod.id_prod
            };
            params1[1] = new SqlParameter
            {
                ParameterName = "Nombre",
                SqlDbType = SqlDbType.VarChar,
                Size = 90,
                Direction = ParameterDirection.Input,
                Value = Prod.NombreProd
            };
            params1[2] = new SqlParameter
            {
                ParameterName = "Peso",
                SqlDbType = SqlDbType.Int,
                Direction = ParameterDirection.Input,
                Value = Prod.Peso
            };
            params1[3] = new SqlParameter
            {
                ParameterName = "Cantidad",
                SqlDbType = SqlDbType.Int,
                Direction = ParameterDirection.Input,
                Value = Prod.Cantidad
            };
            params1[4] = new SqlParameter
            {
                ParameterName = "PrecioFinal",
                SqlDbType = SqlDbType.Float,
                Direction = ParameterDirection.Input,
                Value = Prod.PrecioFinal
            };
            params1[5] = new SqlParameter
            {
                ParameterName = "NotaEspecial",
                SqlDbType = SqlDbType.VarChar,
                Size = 150,
                Direction = ParameterDirection.Input,
                Value = Prod.NotaEspecial
            };
            params1[6] = new SqlParameter
            {
                ParameterName = "F_Pedido",
                SqlDbType = SqlDbType.Int,
                Direction = ParameterDirection.Input,
                Value = Prod.F_Pedido
            };

            string sentencia = @"update Producto
                                 set NotaEspecial = @NotaEspecial
                                 where id_prod = @id_prod;";

            Boolean salida = false;

            salida = objacceso.ModificaBDunPocoMasSegura(sentencia, objacceso.AbrirConexion(ref mens_salida), ref mens_salida, params1);

            return salida;
        }

        public Boolean EliminProdID(int idProd, ref string mens_salida)
        {
            SqlParameter[] params1 = new SqlParameter[1];
            params1[0] = new SqlParameter
            {
                ParameterName = "id_rod",
                SqlDbType = SqlDbType.Int,
                Direction = ParameterDirection.Input,
                Value = idProd
            };


            string sentencia = "DELETE FROM Producto WHERE id_prod = @id_rod; ";

            Boolean salida = false;

            salida = objacceso.ModificaBDunPocoMasSegura(sentencia, objacceso.AbrirConexion(ref mens_salida), ref mens_salida, params1);

            return salida;
        }
    }
}
