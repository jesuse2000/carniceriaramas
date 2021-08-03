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
    public class LogRepartidor
    {
        private ClaseConeccion objacceso =
          new ClaseConeccion(@"Data Source=DESKTOP-20LP090; Initial Catalog=PedidosCarniceria; Integrated Security = true;");

        public List<Repartidor> ObtenerTodoC(Repartidor CRepatidor, ref string mens_salida)
        {
            List<Repartidor> envR = new List<Repartidor>();
            SqlParameter[] params1 = new SqlParameter[4];
            params1[0] = new SqlParameter
            {
                ParameterName = "id_R",
                SqlDbType = SqlDbType.Int,
                Direction = ParameterDirection.Input,
                Value = CRepatidor.id_Repartidor
            };
            params1[1] = new SqlParameter
            {
                ParameterName = "Nombre",
                SqlDbType = SqlDbType.VarChar,
                Size = 200,
                Direction = ParameterDirection.Input,
                Value = CRepatidor.Nombre
            };
            params1[2] = new SqlParameter
            {
                ParameterName = "Celular",
                SqlDbType = SqlDbType.VarChar,
                Size = 20,
                Direction = ParameterDirection.Input,
                Value = CRepatidor.Celular
            };
            params1[3] = new SqlParameter
            {
                ParameterName = "Licencia",
                SqlDbType = SqlDbType.VarChar,
                Size = 40,
                Direction = ParameterDirection.Input,
                Value = CRepatidor.Licencia
            };

            string query = @"select * from Repartidor where id_Repartidor=@Id_R";

            SqlDataReader cont_atrapa = null;

            cont_atrapa = objacceso.ModificaBDunPocoMasSeguraDS(query, objacceso.AbrirConexion(ref mens_salida),
                ref mens_salida, params1);
            Repartidor devR = null;
            while (cont_atrapa.Read())
            {
                devR = new Repartidor
                {
                    id_Repartidor = Convert.ToInt32(cont_atrapa["id_Repartidor"]),
                    Nombre = Convert.ToString(cont_atrapa["Nombre"]),
                    Celular = Convert.ToString(cont_atrapa["Celular"]),
                    Licencia = Convert.ToString(cont_atrapa["Licencia"])
                };
                envR.Add(devR);
            }
            return envR;
        }

        public Boolean Insert(Repartidor CRepatidor, ref string mens_salida)
        {
            SqlParameter[] params1 = new SqlParameter[4];
            params1[0] = new SqlParameter
            {
                ParameterName = "id_R",
                SqlDbType = SqlDbType.Int,
                Direction = ParameterDirection.Input,
                Value = CRepatidor.id_Repartidor
            };
            params1[1] = new SqlParameter
            {
                ParameterName = "Nombre",
                SqlDbType = SqlDbType.VarChar,
                Size = 200,
                Direction = ParameterDirection.Input,
                Value = CRepatidor.Nombre
            };
            params1[2] = new SqlParameter
            {
                ParameterName = "Celular",
                SqlDbType = SqlDbType.VarChar,
                Size = 20,
                Direction = ParameterDirection.Input,
                Value = CRepatidor.Celular
            };
            params1[3] = new SqlParameter
            {
                ParameterName = "Licencia",
                SqlDbType = SqlDbType.VarChar,
                Size = 40,
                Direction = ParameterDirection.Input,
                Value = CRepatidor.Licencia
            };


            string sentencia = "Insert into Repartidor values(@Nombre,@Celular,@Licencia);";

            Boolean salida = false;

            salida = objacceso.ModificaBDunPocoMasSegura(sentencia, objacceso.AbrirConexion(ref mens_salida), ref mens_salida, params1);

            return salida;
        }
        //---------------------------------------------------------------------------
        public List<Repartidor> Repartidores(ref string mens_salida)
        {
            List<Repartidor> reparitodersd = new List<Repartidor>();
            string sentencia = @"select * from Repartidor;";
            SqlDataReader todos = objacceso.ConsultarReader(sentencia, objacceso.AbrirConexion(ref mens_salida), ref mens_salida);
            while (todos.Read())
            {
                Repartidor temp = new Repartidor
                {
                    id_Repartidor = Convert.ToInt32(todos["id_Repartidor"]),
                    Nombre = Convert.ToString(todos["Nombre"]),
                    Celular = Convert.ToString(todos["Celular"]),
                    Licencia = Convert.ToString(todos["Licencia"]),
                    
                };
                reparitodersd.Add(temp);
            }
            return reparitodersd;
        }

        public Boolean EliminRep(int idRep, ref string mens_salida)
        {
            SqlParameter[] params1 = new SqlParameter[1];
            params1[0] = new SqlParameter
            {
                ParameterName = "idRep",
                SqlDbType = SqlDbType.Int,
                Direction = ParameterDirection.Input,
                Value = idRep
            };


            string sentencia = "DELETE FROM Repartidor WHERE id_Repartidor = @idRep; ";

            Boolean salida = false;

            salida = objacceso.ModificaBDunPocoMasSegura(sentencia, objacceso.AbrirConexion(ref mens_salida), ref mens_salida, params1);

            return salida;
        }

        public Boolean EliminRepEP(int idRep, ref string mens_salida)
        {
            SqlParameter[] params1 = new SqlParameter[1];
            params1[0] = new SqlParameter
            {
                ParameterName = "idRep",
                SqlDbType = SqlDbType.Int,
                Direction = ParameterDirection.Input,
                Value = idRep
            };


            string sentencia = "DELETE FROM EntregaPedido WHERE F_Repartidor = @idRep; ";

            Boolean salida = false;

            salida = objacceso.ModificaBDunPocoMasSegura(sentencia, objacceso.AbrirConexion(ref mens_salida), ref mens_salida, params1);

            return salida;
        }

        public Boolean ActRep(Repartidor rep, ref string mens_salida)
        {
            SqlParameter[] params1 = new SqlParameter[4];
            params1[0] = new SqlParameter
            {
                ParameterName = "idRep",
                SqlDbType = SqlDbType.Int,
                Direction = ParameterDirection.Input,
                Value = rep.id_Repartidor
            };
            params1[1] = new SqlParameter
            {
                ParameterName = "Nombre",
                SqlDbType = SqlDbType.VarChar,
                Size = 90,
                Direction = ParameterDirection.Input,
                Value = rep.Nombre
            };
            params1[2] = new SqlParameter
            {
                ParameterName = "Celular",
                SqlDbType = SqlDbType.VarChar,
                Size = 90,
                Direction = ParameterDirection.Input,
                Value = rep.Celular
            };
            params1[3] = new SqlParameter
            {
                ParameterName = "Licencia",
                SqlDbType = SqlDbType.VarChar,
                Size = 90,
                Direction = ParameterDirection.Input,
                Value = rep.Licencia
            };

            string sentencia = @"update Repartidor
                                 set Celular = @Celular
                                 where id_Repartidor = @idRep;";

            Boolean salida = false;

            salida = objacceso.ModificaBDunPocoMasSegura(sentencia, objacceso.AbrirConexion(ref mens_salida), ref mens_salida, params1);

            return salida;
        }
    }
}
