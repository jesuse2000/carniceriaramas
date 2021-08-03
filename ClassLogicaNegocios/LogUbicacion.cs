using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClassAccesoSQL;
using ClassEntidades;
using System.Data;
using System.Data.SqlClient;

namespace ClassLogicaNegocios
{
    public class LogUbicacion
    {
        private ClaseConeccion objacceso =
           new ClaseConeccion(@"Data Source=DESKTOP-20LP090; Initial Catalog=PedidosCarniceria; Integrated Security = true;");

        private LogCliente LogicaCliente = new LogCliente();

        public Boolean Insert(Ubicacion ub, Cliente nuevo, ref string mens_salida)
        {
            int idC = LogicaCliente.idd(nuevo, ref mens_salida);

            SqlParameter[] params1 = new SqlParameter[8];
            params1[0] = new SqlParameter
            {
                ParameterName = "Col",
                SqlDbType = SqlDbType.VarChar,
                Size = 120,
                Direction = ParameterDirection.Input,
                Value = ub.Colonia
            };
            params1[1] = new SqlParameter
            {
                ParameterName = "Call",
                SqlDbType = SqlDbType.VarChar,
                Size = 120,
                Direction = ParameterDirection.Input,
                Value = ub.Calleynumero
            };
            params1[2] = new SqlParameter
            {
                ParameterName = "Mun",
                SqlDbType = SqlDbType.VarChar,
                Size = 90,
                Direction = ParameterDirection.Input,
                Value = ub.Municipio
            };
            params1[3] = new SqlParameter
            {
                ParameterName = "Ciu",
                SqlDbType = SqlDbType.VarChar,
                Size = 90,
                Direction = ParameterDirection.Input,
                Value = ub.Ciudad
            };
            params1[4] = new SqlParameter
            {
                ParameterName = "Ref",
                SqlDbType = SqlDbType.VarChar,
                Size = 120,
                Direction = ParameterDirection.Input,
                Value = ub.Referencia
            };
            params1[5] = new SqlParameter
            {
                ParameterName = "Carac",
                SqlDbType = SqlDbType.VarChar,
                Size = 100,
                Direction = ParameterDirection.Input,
                Value = ub.Caracteristica
            };
            params1[6] = new SqlParameter
            {
                ParameterName = "CP",
                SqlDbType = SqlDbType.VarChar,
                Size = 10,
                Direction = ParameterDirection.Input,
                Value = ub.CP
            };
            params1[7] = new SqlParameter
            {
                ParameterName = "F_C",
                SqlDbType = SqlDbType.Int,
                Direction = ParameterDirection.Input,
                Value = idC
            };

            string sentencia = "Insert into Ubicacion values (@Col,@Call,@Mun,@Ciu,@Ref,@Carac,@CP,@F_C);";

            Boolean salida = false;

            salida = objacceso.ModificaBDunPocoMasSegura(sentencia, objacceso.AbrirConexion(ref mens_salida), ref mens_salida, params1);

            return salida;
        }

        //-------------------CRUD-----------------------

        public List<Ubicacion> Ubicaciones(ref string mens_salida)
        {
            List<Ubicacion> envU = new List<Ubicacion>();

            string query = @"select * from Ubicacion;";

            SqlDataReader cont_atrapa = null;

            cont_atrapa = objacceso.ConsultarReader(query, objacceso.AbrirConexion(ref mens_salida),
                ref mens_salida);

            Ubicacion devu = null;

            if (cont_atrapa.HasRows == true)
            {
                while (cont_atrapa.Read())
                {
                    devu = new Ubicacion
                    {
                        id_ubicacion = Convert.ToInt32(cont_atrapa["id_Ubicacion"]),
                        Colonia = Convert.ToString(cont_atrapa["Colonia"]),
                        Calleynumero = Convert.ToString(cont_atrapa["Calleynumero"]),
                        Municipio = Convert.ToString(cont_atrapa["Municipio"]),
                        Ciudad = Convert.ToString(cont_atrapa["Ciudad"]),
                        Referencia = Convert.ToString(cont_atrapa["Referencia"]),
                        Caracteristica = Convert.ToString(cont_atrapa["Caracteristica"]),
                        CP = Convert.ToString(cont_atrapa["CP"]),
                        F_Cliente = Convert.ToInt32(cont_atrapa["F_Cliente"]),

                    };
                    envU.Add(devu);
                }
            }
            else
            {
                envU = null;
            }
            return envU;
        }

        public Boolean InsertU(Ubicacion ub, ref string mens_salida)
        {
            SqlParameter[] params1 = new SqlParameter[8];
            params1[0] = new SqlParameter
            {
                ParameterName = "Col",
                SqlDbType = SqlDbType.VarChar,
                Size = 120,
                Direction = ParameterDirection.Input,
                Value = ub.Colonia
            };
            params1[1] = new SqlParameter
            {
                ParameterName = "Call",
                SqlDbType = SqlDbType.VarChar,
                Size = 120,
                Direction = ParameterDirection.Input,
                Value = ub.Calleynumero
            };
            params1[2] = new SqlParameter
            {
                ParameterName = "Mun",
                SqlDbType = SqlDbType.VarChar,
                Size = 90,
                Direction = ParameterDirection.Input,
                Value = ub.Municipio
            };
            params1[3] = new SqlParameter
            {
                ParameterName = "Ciu",
                SqlDbType = SqlDbType.VarChar,
                Size = 90,
                Direction = ParameterDirection.Input,
                Value = ub.Ciudad
            };
            params1[4] = new SqlParameter
            {
                ParameterName = "Ref",
                SqlDbType = SqlDbType.VarChar,
                Size = 120,
                Direction = ParameterDirection.Input,
                Value = ub.Referencia
            };
            params1[5] = new SqlParameter
            {
                ParameterName = "Carac",
                SqlDbType = SqlDbType.VarChar,
                Size = 100,
                Direction = ParameterDirection.Input,
                Value = ub.Caracteristica
            };
            params1[6] = new SqlParameter
            {
                ParameterName = "CP",
                SqlDbType = SqlDbType.VarChar,
                Size = 10,
                Direction = ParameterDirection.Input,
                Value = ub.CP
            };
            params1[7] = new SqlParameter
            {
                ParameterName = "F_C",
                SqlDbType = SqlDbType.Int,
                Direction = ParameterDirection.Input,
                Value = ub.F_Cliente
            };

            string sentencia = "Insert into Ubicacion values (@Col,@Call,@Mun,@Ciu,@Ref,@Carac,@CP,@F_C);";

            Boolean salida = false;

            salida = objacceso.ModificaBDunPocoMasSegura(sentencia, objacceso.AbrirConexion(ref mens_salida), ref mens_salida, params1);

            return salida;
        }

        public Boolean EliminU(int idUE, ref string mens_salida)
        {
            SqlParameter[] params1 = new SqlParameter[1];
            params1[0] = new SqlParameter
            {
                ParameterName = "idUE",
                SqlDbType = SqlDbType.Int,
                Direction = ParameterDirection.Input,
                Value = idUE
            };
            

            string sentencia = "DELETE FROM Ubicacion WHERE id_ubicacion = @idUE; ";

            Boolean salida = false;

            salida = objacceso.ModificaBDunPocoMasSegura(sentencia, objacceso.AbrirConexion(ref mens_salida), ref mens_salida, params1);

            return salida;
        }

        public Boolean ActUb(Ubicacion ub, ref string mens_salida)
        {
            SqlParameter[] params1 = new SqlParameter[8];
            params1[0] = new SqlParameter
            {
                ParameterName = "idUb",
                SqlDbType = SqlDbType.Int,
                Direction = ParameterDirection.Input,
                Value = ub.id_ubicacion
            };
            params1[1] = new SqlParameter
            {
                ParameterName = "Col",
                SqlDbType = SqlDbType.VarChar,
                Size = 120,
                Direction = ParameterDirection.Input,
                Value = ub.Colonia
            };
            params1[2] = new SqlParameter
            {
                ParameterName = "Call",
                SqlDbType = SqlDbType.VarChar,
                Size = 120,
                Direction = ParameterDirection.Input,
                Value = ub.Calleynumero
            };
            params1[3] = new SqlParameter
            {
                ParameterName = "Mun",
                SqlDbType = SqlDbType.VarChar,
                Size = 90,
                Direction = ParameterDirection.Input,
                Value = ub.Municipio
            };
            params1[4] = new SqlParameter
            {
                ParameterName = "Ciu",
                SqlDbType = SqlDbType.VarChar,
                Size = 90,
                Direction = ParameterDirection.Input,
                Value = ub.Ciudad
            };
            params1[5] = new SqlParameter
            {
                ParameterName = "Ref",
                SqlDbType = SqlDbType.VarChar,
                Size = 120,
                Direction = ParameterDirection.Input,
                Value = ub.Referencia
            };
            params1[6] = new SqlParameter
            {
                ParameterName = "Carac",
                SqlDbType = SqlDbType.VarChar,
                Size = 100,
                Direction = ParameterDirection.Input,
                Value = ub.Caracteristica
            };
            params1[7] = new SqlParameter
            {
                ParameterName = "CP",
                SqlDbType = SqlDbType.VarChar,
                Size = 10,
                Direction = ParameterDirection.Input,
                Value = ub.CP
            };



            string sentencia = @"update Ubicacion
                                 set Colonia = @Col, Calleynumero = @Call, Municipio = @Mun, Ciudad = @Ciu, Referencia = @Ref, Caracteristica = @Carac, CP = @CP
                                 where id_ubicacion = @idUb;";

            Boolean salida = false;

            salida = objacceso.ModificaBDunPocoMasSegura(sentencia, objacceso.AbrirConexion(ref mens_salida), ref mens_salida, params1);

            return salida;
        }

        public Boolean EliminUC(int idUE, ref string mens_salida)
        {
            SqlParameter[] params1 = new SqlParameter[1];
            params1[0] = new SqlParameter
            {
                ParameterName = "idUE",
                SqlDbType = SqlDbType.Int,
                Direction = ParameterDirection.Input,
                Value = idUE
            };


            string sentencia = "DELETE FROM Ubicacion WHERE F_Cliente = @idUE; ";

            Boolean salida = false;

            salida = objacceso.ModificaBDunPocoMasSegura(sentencia, objacceso.AbrirConexion(ref mens_salida), ref mens_salida, params1);

            return salida;
        }

    }
}
