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
    public class LogEntregaPedido
    {
        private ClaseConeccion objacceso =
           new ClaseConeccion(@"Data Source=DESKTOP-20LP090; Initial Catalog=PedidosCarniceria; Integrated Security = true;");

        public Boolean Insert(EntregaPedido pd, int idC, ref string mens_salida)
        {
            SqlParameter[] params1 = new SqlParameter[6];
            params1[0] = new SqlParameter
            {
                ParameterName = "idE",
                SqlDbType = SqlDbType.Int,
                Direction = ParameterDirection.Input,
                Value = pd.id_Entrega
            };
            params1[1] = new SqlParameter
            {
                ParameterName = "FP",
                SqlDbType = SqlDbType.Int,
                Direction = ParameterDirection.Input,
                Value = pd.F_Pedido
            };
            params1[2] = new SqlParameter
            {
                ParameterName = "FR",
                SqlDbType = SqlDbType.Int,
                Direction = ParameterDirection.Input,
                Value = pd.F_Repartidor
            };
            params1[3] = new SqlParameter
            {
                ParameterName = "Salida",
                SqlDbType = SqlDbType.DateTime,
                Direction = ParameterDirection.Input,
                Value = pd.Salida
            };
            params1[4] = new SqlParameter
            {
                ParameterName = "SE",
                SqlDbType = SqlDbType.DateTime,
                Direction = ParameterDirection.Input,
                Value = pd.SeEntrego
            };
            params1[5] = new SqlParameter
            {
                ParameterName = "Estado",
                SqlDbType = SqlDbType.VarChar,
                Size = 50,
                Direction = ParameterDirection.Input,
                Value = pd.Estado
            };

            string sentencia = "Insert into EntregaPedido values(@FP,@FR,@Salida,@SE,@Estado);";

            Boolean salida = false;

            salida = objacceso.ModificaBDunPocoMasSegura(sentencia, objacceso.AbrirConexion(ref mens_salida), ref mens_salida, params1);

            return salida;
        }

        public Boolean Actualizacion(EntregaPedido pd, int idC, ref string mens_salida)
        {
            SqlParameter[] params1 = new SqlParameter[6];
            params1[0] = new SqlParameter
            {
                ParameterName = "idE",
                SqlDbType = SqlDbType.Int,
                Direction = ParameterDirection.Input,
                Value = pd.id_Entrega
            };
            params1[1] = new SqlParameter
            {
                ParameterName = "FP",
                SqlDbType = SqlDbType.Int,
                Direction = ParameterDirection.Input,
                Value = pd.F_Pedido
            };
            params1[2] = new SqlParameter
            {
                ParameterName = "FR",
                SqlDbType = SqlDbType.Int,
                Direction = ParameterDirection.Input,
                Value = pd.F_Repartidor
            };
            params1[3] = new SqlParameter
            {
                ParameterName = "Salida",
                SqlDbType = SqlDbType.DateTime,
                Direction = ParameterDirection.Input,
                Value = pd.Salida
            };
            params1[4] = new SqlParameter
            {
                ParameterName = "SE",
                SqlDbType = SqlDbType.DateTime,
                Direction = ParameterDirection.Input,
                Value = pd.SeEntrego
            };
            params1[5] = new SqlParameter
            {
                ParameterName = "Estado",
                SqlDbType = SqlDbType.VarChar,
                Size = 50,
                Direction = ParameterDirection.Input,
                Value = pd.Estado
            };

            string sentencia = "UPDATE EntregaPedido SET SeEntrego = @SE, Estado= @Estado WHERE F_Pedido = @FP";

            Boolean salida = false;

            salida = objacceso.ModificaBDunPocoMasSegura(sentencia, objacceso.AbrirConexion(ref mens_salida), ref mens_salida, params1);

            return salida;
        }

        public List<EntregaPedido> ObtenerTodoC(Pedido CPedido, ref string mens_salida)
        {
            List<EntregaPedido> envR = new List<EntregaPedido>();
            SqlParameter[] params1 = new SqlParameter[6];
            params1[0] = new SqlParameter
            {
                ParameterName = "id_P",
                SqlDbType = SqlDbType.Int,
                Direction = ParameterDirection.Input,
                Value = CPedido.id_Pedido
            };
            params1[1] = new SqlParameter
            {
                ParameterName = "FechaHora",
                SqlDbType = SqlDbType.DateTime,
                Direction = ParameterDirection.Input,
                Value = CPedido.FechaHora
            };
            params1[2] = new SqlParameter
            {
                ParameterName = "F_Cliente",
                SqlDbType = SqlDbType.Int,
                Direction = ParameterDirection.Input,
                Value = CPedido.F_Cliente
            };
            params1[3] = new SqlParameter
            {
                ParameterName = "F_Carnicero",
                SqlDbType = SqlDbType.Int,
                Direction = ParameterDirection.Input,
                Value = CPedido.F_Carnicero
            };
            params1[4] = new SqlParameter
            {
                ParameterName = "Envio",
                SqlDbType = SqlDbType.SmallInt,
                Direction = ParameterDirection.Input,
                Value = CPedido.Envio
            };
            params1[5] = new SqlParameter
            {
                ParameterName = "Pago",
                SqlDbType = SqlDbType.VarChar,
                Size = 50,
                Direction = ParameterDirection.Input,
                Value = CPedido.Pago
            };

            string query = @"select EntregaPedido.id_Entrega,EntregaPedido.F_Pedido,EntregaPedido.F_Repartidor,EntregaPedido.Salida,EntregaPedido.SeEntrego,EntregaPedido.Estado
                             from Pedido,EntregaPedido
                             where Pedido.id_Pedido = EntregaPedido.F_Pedido and Envio=1 and F_Pedido=@id_P";

            SqlDataReader cont_atrapa = null;

            cont_atrapa = objacceso.ModificaBDunPocoMasSeguraDS(query, objacceso.AbrirConexion(ref mens_salida),
                ref mens_salida, params1);
            
            if (cont_atrapa.HasRows == true) {
                EntregaPedido ent = null;
                while (cont_atrapa.Read())
                {
                    ent = new EntregaPedido
                    {
                        id_Entrega = Convert.ToInt32(cont_atrapa["id_Entrega"]),
                        F_Pedido = Convert.ToInt32(cont_atrapa["F_Pedido"]),
                        F_Repartidor = Convert.ToInt32(cont_atrapa["F_Repartidor"]),
                        Salida = Convert.ToDateTime(cont_atrapa["Salida"]),
                        SeEntrego = Convert.ToDateTime(cont_atrapa["SeEntrego"]),
                        Estado = Convert.ToString(cont_atrapa["Estado"])
                    };
                    envR.Add(ent);
                }
            }
            else
            {
                envR = null;
            }
            
            return envR;
        }

        public List<EntregaPedido> ObtenerTodosR(Repartidor CRepatidor, ref string mens_salida)
        {
            List<EntregaPedido> envR = new List<EntregaPedido>();
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

            string query = @"select * from EntregaPedido where F_Repartidor=@id_R";

            SqlDataReader cont_atrapa = null;

            cont_atrapa = objacceso.ModificaBDunPocoMasSeguraDS(query, objacceso.AbrirConexion(ref mens_salida),
                ref mens_salida, params1);

            if (cont_atrapa.HasRows == true)
            {
                
                while (cont_atrapa.Read())
                {
                    EntregaPedido ent = new EntregaPedido
                    {
                        id_Entrega = Convert.ToInt32(cont_atrapa["id_Entrega"]),
                        F_Pedido = Convert.ToInt32(cont_atrapa["F_Pedido"]),
                        F_Repartidor = Convert.ToInt32(cont_atrapa["F_Repartidor"]),
                        Salida = Convert.ToDateTime(cont_atrapa["Salida"]),
                        SeEntrego = Convert.ToDateTime(cont_atrapa["SeEntrego"]),
                        Estado = Convert.ToString(cont_atrapa["Estado"])
                    };
                    envR.Add(ent);
                }
            }
            else
            {
                envR = null;
            }

            return envR;
        }

        public List<EntregaPedido> ObtenerTodoC(DateTime fechab, ref string mens_salida)
        {
            List<EntregaPedido> envR = new List<EntregaPedido>();
            SqlParameter[] params1 = new SqlParameter[6];
            params1[0] = new SqlParameter
            {
                ParameterName = "id_Ent",
                SqlDbType = SqlDbType.DateTime,
                Direction = ParameterDirection.Input,
                Value = fechab
            };
           

            string query = @"select EntregaPedido.id_Entrega,EntregaPedido.F_Pedido,EntregaPedido.F_Repartidor,EntregaPedido.Salida,EntregaPedido.SeEntrego,EntregaPedido.Estado
                             from Pedido,EntregaPedido
                             where Pedido.id_Pedido = EntregaPedido.F_Pedido and Envio=1 and F_Pedido=@id_P";

            SqlDataReader cont_atrapa = null;

            cont_atrapa = objacceso.ModificaBDunPocoMasSeguraDS(query, objacceso.AbrirConexion(ref mens_salida),
                ref mens_salida, params1);

            if (cont_atrapa.HasRows == true)
            {
                EntregaPedido ent = null;
                while (cont_atrapa.Read())
                {
                    ent = new EntregaPedido
                    {
                        id_Entrega = Convert.ToInt32(cont_atrapa["id_Entrega"]),
                        F_Pedido = Convert.ToInt32(cont_atrapa["F_Pedido"]),
                        F_Repartidor = Convert.ToInt32(cont_atrapa["F_Repartidor"]),
                        Salida = Convert.ToDateTime(cont_atrapa["Salida"]),
                        SeEntrego = Convert.ToDateTime(cont_atrapa["SeEntrego"]),
                        Estado = Convert.ToString(cont_atrapa["Estado"])
                    };
                    envR.Add(ent);
                }
            }
            else
            {
                envR = null;
            }

            return envR;
        }
        //---------------------CRUD---------------------------
        public Boolean EliminEnv(int F_Pedido, ref string mens_salida)
        {
            SqlParameter[] params1 = new SqlParameter[1];
            params1[0] = new SqlParameter
            {
                ParameterName = "F_Pedido",
                SqlDbType = SqlDbType.Int,
                Direction = ParameterDirection.Input,
                Value = F_Pedido
            };


            string sentencia = "DELETE FROM EntregaPedido WHERE F_Pedido = @F_Pedido; ";

            Boolean salida = false;

            salida = objacceso.ModificaBDunPocoMasSegura(sentencia, objacceso.AbrirConexion(ref mens_salida), ref mens_salida, params1);

            return salida;
        }

        public List<EntregaPedido> EntregaLis(ref string mens_salida)
        {
            List<EntregaPedido> envE = new List<EntregaPedido>();

            string query = @"select * from EntregaPedido;";

            SqlDataReader cont_atrapa = null;

            cont_atrapa = objacceso.ConsultarReader(query, objacceso.AbrirConexion(ref mens_salida),
                ref mens_salida);

            EntregaPedido devu = null;

            if (cont_atrapa.HasRows == true)
            {
                while (cont_atrapa.Read())
                {
                    devu = new EntregaPedido
                    {
                        id_Entrega = Convert.ToInt32(cont_atrapa["id_Entrega"]),
                        F_Pedido = Convert.ToInt32(cont_atrapa["F_Pedido"]),
                        F_Repartidor = Convert.ToInt32(cont_atrapa["F_Repartidor"]),
                        Salida = Convert.ToDateTime(cont_atrapa["Salida"]),
                        SeEntrego = Convert.ToDateTime(cont_atrapa["SeEntrego"]),
                        Estado = Convert.ToString(cont_atrapa["Estado"]),
                    };
                    envE.Add(devu);
                }
            }
            else
            {
                envE = null;
            }
            return envE;
        }

        public Boolean EliminEnt(int idEnt, ref string mens_salida)
        {
            SqlParameter[] params1 = new SqlParameter[1];
            params1[0] = new SqlParameter
            {
                ParameterName = "idEnt",
                SqlDbType = SqlDbType.Int,
                Direction = ParameterDirection.Input,
                Value = idEnt
            };


            string sentencia = "DELETE FROM EntregaPedido WHERE id_Entrega = @idEnt; ";

            Boolean salida = false;

            salida = objacceso.ModificaBDunPocoMasSegura(sentencia, objacceso.AbrirConexion(ref mens_salida), ref mens_salida, params1);

            return salida;
        }

        public Boolean ActEnt(EntregaPedido Ent, ref string mens_salida)
        {
            SqlParameter[] params1 = new SqlParameter[5];
            params1[0] = new SqlParameter
            {
                ParameterName = "id_Entrega",
                SqlDbType = SqlDbType.Int,
                Direction = ParameterDirection.Input,
                Value = Ent.id_Entrega
            };
            params1[1] = new SqlParameter
            {
                ParameterName = "F_Pedido",
                SqlDbType = SqlDbType.Int,
                Direction = ParameterDirection.Input,
                Value = Ent.F_Pedido
            };
            params1[2] = new SqlParameter
            {
                ParameterName = "F_Repartidor",
                SqlDbType = SqlDbType.Int,
                Direction = ParameterDirection.Input,
                Value = Ent.F_Repartidor
            };
            params1[3] = new SqlParameter
            {
                ParameterName = "Salida",
                SqlDbType = SqlDbType.DateTime,
                Direction = ParameterDirection.Input,
                Value = Ent.Salida
            };
            params1[4] = new SqlParameter
            {
                ParameterName = "SeEntrego",
                SqlDbType = SqlDbType.DateTime,
                Direction = ParameterDirection.Input,
                Value = Ent.SeEntrego
            };
            params1[3] = new SqlParameter
            {
                ParameterName = "Estado",
                SqlDbType = SqlDbType.VarChar,
                Size = 90,
                Direction = ParameterDirection.Input,
                Value = Ent.Estado
            };

            string sentencia = @"update EntregaPedido
                                 set Estado = @Estado
                                 where id_Entrega = @id_Entrega;";

            Boolean salida = false;

            salida = objacceso.ModificaBDunPocoMasSegura(sentencia, objacceso.AbrirConexion(ref mens_salida), ref mens_salida, params1);

            return salida;
        }

    }
}
