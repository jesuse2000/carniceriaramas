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
    public class LogCliente
    {
        private ClaseConeccion objacceso =
           new ClaseConeccion(@"Data Source=DESKTOP-UJ8LE08; Initial Catalog=PedidosCarniceria; Integrated Security = true;");

        public int idd(Cliente nuevo, ref string mens_salida)
        {
            SqlParameter[] params1 = new SqlParameter[5];
            params1[0] = new SqlParameter
            {
                ParameterName = "Nombre",
                SqlDbType = SqlDbType.VarChar,
                Size = 90,
                Direction = ParameterDirection.Input,
                Value = nuevo.Nombre
            };
            params1[1] = new SqlParameter
            {
                ParameterName = "App",
                SqlDbType = SqlDbType.VarChar,
                Size = 90,
                Direction = ParameterDirection.Input,
                Value = nuevo.App
            };
            params1[2] = new SqlParameter
            {
                ParameterName = "ApM",
                SqlDbType = SqlDbType.VarChar,
                Size = 90,
                Direction = ParameterDirection.Input,
                Value = nuevo.ApM
            };
            params1[3] = new SqlParameter
            {
                ParameterName = "Celular",
                SqlDbType = SqlDbType.VarChar,
                Size = 20,
                Direction = ParameterDirection.Input,
                Value = nuevo.Celular
            };
            params1[4] = new SqlParameter
            {
                ParameterName = "Correo",
                SqlDbType = SqlDbType.VarChar,
                Size = 150,
                Direction = ParameterDirection.Input,
                Value = nuevo.Correo
            };

            int idr = 0;
            string query = @"insert into Cliente values (@Nombre,@App,@ApM,@Celular,@Correo)
                            SELECT @@IDENTITY AS 'id_Cliente'; ";

            SqlDataReader cont_atrapa = null;

            cont_atrapa = objacceso.ModificaBDunPocoMasSeguraDS(query, objacceso.AbrirConexion(ref mens_salida),
                ref mens_salida, params1);

            while (cont_atrapa.Read())
            {
                idr = Convert.ToInt32(cont_atrapa["id_Cliente"]);
            }

            return idr;
        }

        public Cliente EncontradoT(Cliente nuevo, ref string mens_salida)
        {
            SqlParameter[] params1 = new SqlParameter[6];
            params1[0] = new SqlParameter
            {
                ParameterName = "id",
                SqlDbType = SqlDbType.Int,
                Direction = ParameterDirection.Input,
                Value = nuevo.id_Cliente
            };
            params1[1] = new SqlParameter
            {
                ParameterName = "Nombre",
                SqlDbType = SqlDbType.VarChar,
                Size = 90,
                Direction = ParameterDirection.Input,
                Value = nuevo.Nombre
            };
            params1[2] = new SqlParameter
            {
                ParameterName = "App",
                SqlDbType = SqlDbType.VarChar,
                Size = 90,
                Direction = ParameterDirection.Input,
                Value = nuevo.App
            };
            params1[3] = new SqlParameter
            {
                ParameterName = "ApM",
                SqlDbType = SqlDbType.VarChar,
                Size = 90,
                Direction = ParameterDirection.Input,
                Value = nuevo.ApM
            };
            params1[4] = new SqlParameter
            {
                ParameterName = "Celular",
                SqlDbType = SqlDbType.VarChar,
                Size = 20,
                Direction = ParameterDirection.Input,
                Value = nuevo.Celular
            };
            params1[5] = new SqlParameter
            {
                ParameterName = "Correo",
                SqlDbType = SqlDbType.VarChar,
                Size = 150,
                Direction = ParameterDirection.Input,
                Value = nuevo.Correo
            };

            
            string query = @"select * from Cliente where Celular=@Celular;";

            SqlDataReader cont_atrapa = null;

            cont_atrapa = objacceso.ModificaBDunPocoMasSeguraDS(query, objacceso.AbrirConexion(ref mens_salida),
                ref mens_salida, params1);

            Cliente dev = new Cliente();
            while (cont_atrapa.Read())
            {
                dev.id_Cliente = Convert.ToInt32(cont_atrapa["id_Cliente"]);
                dev.Nombre = Convert.ToString(cont_atrapa["Nombre"]);
                dev.App = Convert.ToString(cont_atrapa["App"]);
                dev.ApM = Convert.ToString(cont_atrapa["ApM"]);
                dev.Celular = Convert.ToString(cont_atrapa["Celular"]);
                dev.Correo = Convert.ToString(cont_atrapa["Correo"]);

            }

            return dev;
        }

        public List<Cliente> ObtenerTodo(ref string mens_salida)
        {
            List<Cliente> clientes = new List<Cliente>();
            string sentencia = @"select id_Cliente as 'Identificacion del Cliente', Nombre as 'Nombre del Cliente', App as 'Apellido Paterno', ApM as 'Apellido Materno', Celular as 'Celular del Cliente', Correo as 'Correo del Cliente'
                                from Cliente; ";
            SqlDataReader todos = objacceso.ConsultarReader(sentencia, objacceso.AbrirConexion(ref mens_salida), ref mens_salida);
            while (todos.Read())
            {
                Cliente temp = new Cliente
                {
                    id_Cliente = Convert.ToInt32(todos["Identificacion del Cliente"]),
                    Nombre = Convert.ToString(todos["Nombre del Cliente"]),
                    App = Convert.ToString(todos["Apellido Paterno"]),
                    ApM = Convert.ToString(todos["Apellido Materno"]),
                    Celular = Convert.ToString(todos["Celular del Cliente"]),
                    Correo = Convert.ToString(todos["Correo del Cliente"])
                };
                clientes.Add(temp);
            }
            return clientes;
        }

        public List<Pedido> ObtenerTodoP(Cliente nuevo,ref string mens_salida)
        {
            List<Pedido> Pedidos = new List<Pedido>();
            SqlParameter[] params1 = new SqlParameter[6];
            params1[0] = new SqlParameter
            {
                ParameterName = "id",
                SqlDbType = SqlDbType.Int,
                Direction = ParameterDirection.Input,
                Value = nuevo.id_Cliente
            };
            params1[1] = new SqlParameter
            {
                ParameterName = "Nombre",
                SqlDbType = SqlDbType.VarChar,
                Size = 90,
                Direction = ParameterDirection.Input,
                Value = nuevo.Nombre
            };
            params1[2] = new SqlParameter
            {
                ParameterName = "App",
                SqlDbType = SqlDbType.VarChar,
                Size = 90,
                Direction = ParameterDirection.Input,
                Value = nuevo.App
            };
            params1[3] = new SqlParameter
            {
                ParameterName = "ApM",
                SqlDbType = SqlDbType.VarChar,
                Size = 90,
                Direction = ParameterDirection.Input,
                Value = nuevo.ApM
            };
            params1[4] = new SqlParameter
            {
                ParameterName = "Celular",
                SqlDbType = SqlDbType.VarChar,
                Size = 20,
                Direction = ParameterDirection.Input,
                Value = nuevo.Celular
            };
            params1[5] = new SqlParameter
            {
                ParameterName = "Correo",
                SqlDbType = SqlDbType.VarChar,
                Size = 150,
                Direction = ParameterDirection.Input,
                Value = nuevo.Correo
            };


            /*string query = @"select * from Pedido where F_Cliente = id";

            SqlDataReader todos = objacceso.ConsultarReader(query, objacceso.AbrirConexion(ref mens_salida), ref mens_salida);
            */

            string query = @"select * from Pedido where F_Cliente = @id;";

            SqlDataReader cont_atrapa = null;

            cont_atrapa = objacceso.ModificaBDunPocoMasSeguraDS(query, objacceso.AbrirConexion(ref mens_salida),
                ref mens_salida, params1);

            Cliente dev = new Cliente();
            while (cont_atrapa.Read())               
            {
                Pedido temp = new Pedido
                {
                    id_Pedido = Convert.ToInt32(cont_atrapa["id_Pedido"]),
                    FechaHora = Convert.ToDateTime(cont_atrapa["FechaHora"]),
                    F_Cliente = Convert.ToInt32(cont_atrapa["F_Cliente"]),
                    F_Carnicero = Convert.ToInt32(cont_atrapa["F_Carnicero"]),
                    Envio = Convert.ToInt32(cont_atrapa["Envio"]),
                    Pago = Convert.ToString(cont_atrapa["Pago"])
                };
                Pedidos.Add(temp);
            }
            return Pedidos;
        }

        //---------------------CRUD------------------------

        public List<Cliente> Clientes(ref string mens_salida)
        {
            List<Cliente> envC = new List<Cliente>();

            string query = @"select * from Cliente;";

            SqlDataReader cont_atrapa = null;

            cont_atrapa = objacceso.ConsultarReader(query, objacceso.AbrirConexion(ref mens_salida),
                ref mens_salida);

            Cliente devCl = null;

            if (cont_atrapa.HasRows == true)
            {
                while (cont_atrapa.Read())
                {
                    devCl = new Cliente
                    {
                        id_Cliente = Convert.ToInt32(cont_atrapa["id_Cliente"]),
                        Nombre = Convert.ToString(cont_atrapa["Nombre"]),
                        App = Convert.ToString(cont_atrapa["App"]),
                        ApM = Convert.ToString(cont_atrapa["ApM"]),
                        Celular = Convert.ToString(cont_atrapa["Celular"]),
                        Correo = Convert.ToString(cont_atrapa["Correo"]),
                        

                    };
                    envC.Add(devCl);
                }
            }
            else
            {
                envC = null;
            }
            return envC;
        }

        public Boolean ActClient(string correo, string celular,int id, ref string mens_salida)
        {
            SqlParameter[] params1 = new SqlParameter[3];
            params1[0] = new SqlParameter
            {
                ParameterName = "idC",
                SqlDbType = SqlDbType.Int,
                Direction = ParameterDirection.Input,
                Value = id
            };
            params1[1] = new SqlParameter
            {
                ParameterName = "Celular",
                SqlDbType = SqlDbType.VarChar,
                Size = 150,
                Direction = ParameterDirection.Input,
                Value = celular
            };
            params1[2] = new SqlParameter
            {
                ParameterName = "Correo",
                SqlDbType = SqlDbType.VarChar,
                Size = 120,
                Direction = ParameterDirection.Input,
                Value = correo
            };


            string sentencia = @"update Cliente
                                 set Celular=@Celular, Correo=@Correo
                                 where id_Cliente = @idC;";

            Boolean salida = false;

            salida = objacceso.ModificaBDunPocoMasSegura(sentencia, objacceso.AbrirConexion(ref mens_salida), ref mens_salida, params1);

            return salida;
        }

        

        public Boolean ElimCli(int id, ref string mens_salida)
        {
            SqlParameter[] params1 = new SqlParameter[1];
            params1[0] = new SqlParameter
            {
                ParameterName = "idC",
                SqlDbType = SqlDbType.Int,
                Direction = ParameterDirection.Input,
                Value = id
            };
            
            string sentencia = @"DELETE FROM Cliente WHERE id_Cliente = @idC;";

            Boolean salida = false;

            salida = objacceso.ModificaBDunPocoMasSegura(sentencia, objacceso.AbrirConexion(ref mens_salida), ref mens_salida, params1);

            return salida;
        }
    }
}
