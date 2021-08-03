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
    public class LogCarnicero
    {
        private ClaseConeccion objacceso =
           new ClaseConeccion(@"Data Source=DESKTOP-UJ8LE08; Initial Catalog=PedidosCarniceria; Integrated Security = true;");

        public List<Carnicero> ObtenerTodoC(Carnicero Cconsulta, ref string mens_salida)
        {
            List<Carnicero> envC = new List<Carnicero>();
            SqlParameter[] params1 = new SqlParameter[5];
            params1[0] = new SqlParameter
            {
                ParameterName = "id_Carnicero",
                SqlDbType = SqlDbType.Int,
                Direction = ParameterDirection.Input,
                Value = Cconsulta.id_Carnicero
            };
            params1[1] = new SqlParameter
            {
                ParameterName = "Nombre",
                SqlDbType = SqlDbType.VarChar,
                Size = 190,
                Direction = ParameterDirection.Input,
                Value = Cconsulta.Nombre
            };
            params1[2] = new SqlParameter
            {
                ParameterName = "Celular",
                SqlDbType = SqlDbType.VarChar,
                Size = 20,
                Direction = ParameterDirection.Input,
                Value = Cconsulta.Celular
            };
            params1[3] = new SqlParameter
            {
                ParameterName = "Correo",
                SqlDbType = SqlDbType.VarChar,
                Size = 150,
                Direction = ParameterDirection.Input,
                Value = Cconsulta.Correo
            };
            params1[4] = new SqlParameter
            {
                ParameterName = "Exp_anios",
                SqlDbType = SqlDbType.SmallInt,
                Direction = ParameterDirection.Input,
                Value = Cconsulta.Exp_anios
            };

            string query = @"select * from Carnicero where id_Carnicero = @id_Carnicero;";

            SqlDataReader cont_atrapa = null;

            cont_atrapa = objacceso.ModificaBDunPocoMasSeguraDS(query, objacceso.AbrirConexion(ref mens_salida),
                ref mens_salida, params1);
            Carnicero devC = null;
            while (cont_atrapa.Read())
            {
               devC = new Carnicero
               {
                    id_Carnicero = Convert.ToInt32(cont_atrapa["id_Carnicero"]),
                    Nombre = Convert.ToString(cont_atrapa["Nombre"]),
                    Celular=Convert.ToString(cont_atrapa["Celular"]),
                    Correo = Convert.ToString(cont_atrapa["Correo"]),
                    Exp_anios = Convert.ToInt32(cont_atrapa["Exp_anios"]),
                    
               };
                envC.Add(devC);
            }
            return envC;
        }
        //----------------------------------------------------------------------
        public Boolean Insert(Carnicero TempC, ref string mens_salida)
        {
            SqlParameter[] params1 = new SqlParameter[5];
            params1[0] = new SqlParameter
            {
                ParameterName = "idC",
                SqlDbType = SqlDbType.Int,
                Direction = ParameterDirection.Input,
                Value = TempC.id_Carnicero
            };
            params1[1] = new SqlParameter
            {
                ParameterName = "Nombre",
                SqlDbType = SqlDbType.VarChar,
                Size=190,
                Direction = ParameterDirection.Input,
                Value = TempC.Nombre
            };
            params1[2] = new SqlParameter
            {
                ParameterName = "Celular",
                SqlDbType = SqlDbType.VarChar,
                Size = 20,
                Direction = ParameterDirection.Input,
                Value = TempC.Celular
            };
            params1[3] = new SqlParameter
            {
                ParameterName = "Correo",
                SqlDbType = SqlDbType.VarChar,
                Size = 150,
                Direction = ParameterDirection.Input,
                Value = TempC.Correo
            };
            params1[4] = new SqlParameter
            {
                ParameterName = "Exp_anios",
                SqlDbType = SqlDbType.SmallInt,
                Direction = ParameterDirection.Input,
                Value = TempC.Exp_anios
            };
            

            string sentencia = "Insert into Carnicero values(@Nombre,@Celular,@Correo,@Exp_anios);";

            Boolean salida = false;

            salida = objacceso.ModificaBDunPocoMasSegura(sentencia, objacceso.AbrirConexion(ref mens_salida), ref mens_salida, params1);

            return salida;
        }

        public List<Carnicero> CarniceroLis(ref string mens_salida)
        {
            List<Carnicero> envC = new List<Carnicero>();

            string query = @"select * from Carnicero;";

            SqlDataReader cont_atrapa = null;

            cont_atrapa = objacceso.ConsultarReader(query, objacceso.AbrirConexion(ref mens_salida),
                ref mens_salida);

            Carnicero devu = null;

            if (cont_atrapa.HasRows == true)
            {
                while (cont_atrapa.Read())
                {
                    devu = new Carnicero
                    {
                        id_Carnicero = Convert.ToInt32(cont_atrapa["id_Carnicero"]),
                        Nombre = Convert.ToString(cont_atrapa["Nombre"]),
                        Celular = Convert.ToString(cont_atrapa["Celular"]),
                        Correo = Convert.ToString(cont_atrapa["Correo"]),
                        Exp_anios = Convert.ToInt32(cont_atrapa["Exp_Anios"])
                    };
                    envC.Add(devu);
                }
            }
            else
            {
                envC = null;
            }
            return envC;
        }

        public Boolean EliminCar(int idCar, ref string mens_salida)
        {
            SqlParameter[] params1 = new SqlParameter[1];
            params1[0] = new SqlParameter
            {
                ParameterName = "idCar",
                SqlDbType = SqlDbType.Int,
                Direction = ParameterDirection.Input,
                Value = idCar
            };


            string sentencia = "DELETE FROM Carnicero WHERE id_Carnicero = @idCar; ";

            Boolean salida = false;

            salida = objacceso.ModificaBDunPocoMasSegura(sentencia, objacceso.AbrirConexion(ref mens_salida), ref mens_salida, params1);

            return salida;
        }

        public Boolean ActCar(Carnicero car, ref string mens_salida)
        {
            SqlParameter[] params1 = new SqlParameter[5];
            params1[0] = new SqlParameter
            {
                ParameterName = "idCar",
                SqlDbType = SqlDbType.Int,
                Direction = ParameterDirection.Input,
                Value = car.id_Carnicero
            };
            params1[1] = new SqlParameter
            {
                ParameterName = "Nombre",
                SqlDbType = SqlDbType.VarChar,
                Size = 90,
                Direction = ParameterDirection.Input,
                Value = car.Nombre
            };
            params1[2] = new SqlParameter
            {
                ParameterName = "Celular",
                SqlDbType = SqlDbType.VarChar,
                Size = 90,
                Direction = ParameterDirection.Input,
                Value = car.Celular
            };
            params1[3] = new SqlParameter
            {
                ParameterName = "Correo",
                SqlDbType = SqlDbType.VarChar,
                Size = 90,
                Direction = ParameterDirection.Input,
                Value = car.Correo
            };
            params1[4] = new SqlParameter
            {
                ParameterName = "Anios",
                SqlDbType = SqlDbType.Int,
                Size = 20,
                Direction = ParameterDirection.Input,
                Value = car.Exp_anios
            };

            string sentencia = @"update Carnicero
                                 set Celular = @Celular, Correo = @Correo
                                 where id_Carnicero = @idCar;";

            Boolean salida = false;

            salida = objacceso.ModificaBDunPocoMasSegura(sentencia, objacceso.AbrirConexion(ref mens_salida), ref mens_salida, params1);

            return salida;
        }
    }
}
