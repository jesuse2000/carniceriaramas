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
    public class LogPedido
    {
        private ClaseConeccion objacceso =
           new ClaseConeccion(@"Data Source=DESKTOP-UJ8LE08; Initial Catalog=PedidosCarniceria; Integrated Security = true;");

        public int idd(Pedido pedido, ref string mens_salida)
        {
            SqlParameter[] params1 = new SqlParameter[6];
            params1[0] = new SqlParameter
            {
                ParameterName = "id_Pedido",
                SqlDbType = SqlDbType.Int,
                Direction = ParameterDirection.Input,
                Value = pedido.id_Pedido
            };
            params1[1] = new SqlParameter
            {
                ParameterName = "FechaHora",
                SqlDbType = SqlDbType.DateTime,
                Direction = ParameterDirection.Input,
                Value = pedido.FechaHora
            };
            params1[2] = new SqlParameter
            {
                ParameterName = "F_Cli",
                SqlDbType = SqlDbType.Int,
                Direction = ParameterDirection.Input,
                Value = pedido.F_Cliente
            };
            params1[3] = new SqlParameter
            {
                ParameterName = "F_Car",
                SqlDbType = SqlDbType.Int,
                Direction = ParameterDirection.Input,
                Value = pedido.F_Carnicero
            };
            params1[4] = new SqlParameter
            {
                ParameterName = "Env",
                SqlDbType = SqlDbType.Bit,
                Direction = ParameterDirection.Input,
                Value = pedido.Envio
            };
            params1[5] = new SqlParameter
            {
                ParameterName = "Pag",
                SqlDbType = SqlDbType.VarChar,
                Size = 50,
                Direction = ParameterDirection.Input,
                Value = pedido.Pago
            };

            int idr = 0;
            string query = @"Insert into Pedido values (@FechaHora,@F_Cli,@F_Car,@Env,@Pag);
                            SELECT @@IDENTITY AS 'id_Pedido'; ";

            SqlDataReader cont_atrapa = null;

            cont_atrapa = objacceso.ModificaBDunPocoMasSeguraDS(query, objacceso.AbrirConexion(ref mens_salida),
                ref mens_salida, params1);

            while (cont_atrapa.Read())
            {
                idr = Convert.ToInt32(cont_atrapa["id_Pedido"]);
            }

            return idr;
        }

        public int PEncontrado(Cliente Buscar, ref string mens_salida)
        {
            SqlParameter[] params1 = new SqlParameter[6];
            params1[0] = new SqlParameter
            {
                ParameterName = "id",
                SqlDbType = SqlDbType.Int,
                Direction = ParameterDirection.Input,
                Value = Buscar.id_Cliente
            };
            params1[1] = new SqlParameter
            {
                ParameterName = "Nombre",
                SqlDbType = SqlDbType.VarChar,
                Size = 90,
                Direction = ParameterDirection.Input,
                Value = Buscar.Nombre
            };
            params1[2] = new SqlParameter
            {
                ParameterName = "App",
                SqlDbType = SqlDbType.VarChar,
                Size = 90,
                Direction = ParameterDirection.Input,
                Value = Buscar.App
            };
            params1[3] = new SqlParameter
            {
                ParameterName = "ApM",
                SqlDbType = SqlDbType.VarChar,
                Size = 90,
                Direction = ParameterDirection.Input,
                Value = Buscar.ApM
            };
            params1[4] = new SqlParameter
            {
                ParameterName = "Celular",
                SqlDbType = SqlDbType.VarChar,
                Size = 20,
                Direction = ParameterDirection.Input,
                Value = Buscar.Celular
            };
            params1[5] = new SqlParameter
            {
                ParameterName = "Correo",
                SqlDbType = SqlDbType.VarChar,
                Size = 150,
                Direction = ParameterDirection.Input,
                Value = Buscar.Correo
            };
            DateTime fechahora = DateTime.Now;

            string query = @"select id_Pedido from Pedido,Cliente where Cliente.id_Cliente=Pedido.F_Cliente and Cliente.Celular=@Celular and Envio=1;";

            SqlDataReader cont_atrapa = null;

            cont_atrapa = objacceso.ModificaBDunPocoMasSeguraDS(query, objacceso.AbrirConexion(ref mens_salida),
                ref mens_salida, params1);

            int idE = 0;
            while (cont_atrapa.Read())
            {
                idE = Convert.ToInt32(cont_atrapa["id_Pedido"]);
            }

            return idE;
        }

        public List<Producto> ObtenerTodoP(Pedido pedido, ref string mens_salida)
        {
            List<Producto> Productos = new List<Producto>();
            SqlParameter[] params1 = new SqlParameter[6];
            params1[0] = new SqlParameter
            {
                ParameterName = "id_Pedido",
                SqlDbType = SqlDbType.Int,
                Direction = ParameterDirection.Input,
                Value = pedido.id_Pedido
            };
            params1[1] = new SqlParameter
            {
                ParameterName = "FechaHora",
                SqlDbType = SqlDbType.DateTime,
                Direction = ParameterDirection.Input,
                Value = pedido.FechaHora
            };
            params1[2] = new SqlParameter
            {
                ParameterName = "F_Cli",
                SqlDbType = SqlDbType.Int,
                Direction = ParameterDirection.Input,
                Value = pedido.F_Cliente
            };
            params1[3] = new SqlParameter
            {
                ParameterName = "F_Car",
                SqlDbType = SqlDbType.Int,
                Direction = ParameterDirection.Input,
                Value = pedido.F_Carnicero
            };
            params1[4] = new SqlParameter
            {
                ParameterName = "Env",
                SqlDbType = SqlDbType.Bit,
                Direction = ParameterDirection.Input,
                Value = pedido.Envio
            };
            params1[5] = new SqlParameter
            {
                ParameterName = "Pag",
                SqlDbType = SqlDbType.VarChar,
                Size = 50,
                Direction = ParameterDirection.Input,
                Value = pedido.Pago
            };

            string query = @"select * from Producto where F_Pedido = @id_Pedido;";

            SqlDataReader cont_atrapa = null;

            cont_atrapa = objacceso.ModificaBDunPocoMasSeguraDS(query, objacceso.AbrirConexion(ref mens_salida),
                ref mens_salida, params1);

            while (cont_atrapa.Read())
            {
                Producto temp = new Producto
                {
                    id_prod = Convert.ToInt32(cont_atrapa["id_prod"]),
                    NombreProd = Convert.ToString(cont_atrapa["NombreProd"]),
                    Peso = Convert.ToInt32(cont_atrapa["Peso"]),
                    Cantidad = Convert.ToInt32(cont_atrapa["Cantidad"]),
                    PrecioFinal = Convert.ToDouble(cont_atrapa["PrecioFinal"]),
                    NotaEspecial = Convert.ToString(cont_atrapa["NotaEspecial"]),
                    F_Pedido=Convert.ToInt32(cont_atrapa["F_Pedido"])
                };
                Productos.Add(temp);
            }
            return Productos;
        }

        public List<Pedido> ObtenerTodoPe(Pedido pedido, ref string mens_salida)
        {
            List<Pedido> Pedidos = new List<Pedido>();
            SqlParameter[] params1 = new SqlParameter[6];
            params1[0] = new SqlParameter
            {
                ParameterName = "id_Pedido",
                SqlDbType = SqlDbType.Int,
                Direction = ParameterDirection.Input,
                Value = pedido.id_Pedido
            };
            params1[1] = new SqlParameter
            {
                ParameterName = "FechaHora",
                SqlDbType = SqlDbType.DateTime,
                Direction = ParameterDirection.Input,
                Value = pedido.FechaHora
            };
            params1[2] = new SqlParameter
            {
                ParameterName = "F_Cli",
                SqlDbType = SqlDbType.Int,
                Direction = ParameterDirection.Input,
                Value = pedido.F_Cliente
            };
            params1[3] = new SqlParameter
            {
                ParameterName = "F_Car",
                SqlDbType = SqlDbType.Int,
                Direction = ParameterDirection.Input,
                Value = pedido.F_Carnicero
            };
            params1[4] = new SqlParameter
            {
                ParameterName = "Env",
                SqlDbType = SqlDbType.Bit,
                Direction = ParameterDirection.Input,
                Value = pedido.Envio
            };
            params1[5] = new SqlParameter
            {
                ParameterName = "Pag",
                SqlDbType = SqlDbType.VarChar,
                Size = 50,
                Direction = ParameterDirection.Input,
                Value = pedido.Pago
            };

            string query = @"select * from Pedido where id_Pedido = @id_Pedido;";

            SqlDataReader cont_atrapa = null;

            cont_atrapa = objacceso.ModificaBDunPocoMasSeguraDS(query, objacceso.AbrirConexion(ref mens_salida),
                ref mens_salida, params1);

            while (cont_atrapa.Read())
            {
                Pedido temp = new Pedido
                {
                    id_Pedido = Convert.ToInt32(cont_atrapa["id_Pedido"]),
                    FechaHora = Convert.ToDateTime(cont_atrapa["FechaHora"]),
                    F_Cliente = Convert.ToInt32(cont_atrapa["F_Cliente"]),
                    F_Carnicero = Convert.ToInt32(cont_atrapa["F_Carnicero"]),
                    Envio = Convert.ToInt32(cont_atrapa["Envio"]),
                    Pago = Convert.ToString(cont_atrapa["Pago"]),
                    
                };
                Pedidos.Add(temp);
            }
            return Pedidos;
        }


        public int ObtenerTodoPEnvi(Pedido pedido, ref string mens_salida)
        {
            //List<Pedido> Pedidos = new List<Pedido>();
            int num = 0;
            SqlParameter[] params1 = new SqlParameter[6];
            params1[0] = new SqlParameter
            {
                ParameterName = "id_Pedido",
                SqlDbType = SqlDbType.Int,
                Direction = ParameterDirection.Input,
                Value = pedido.id_Pedido
            };
            params1[1] = new SqlParameter
            {
                ParameterName = "FechaHora",
                SqlDbType = SqlDbType.DateTime,
                Direction = ParameterDirection.Input,
                Value = pedido.FechaHora
            };
            params1[2] = new SqlParameter
            {
                ParameterName = "F_Cli",
                SqlDbType = SqlDbType.Int,
                Direction = ParameterDirection.Input,
                Value = pedido.F_Cliente
            };
            params1[3] = new SqlParameter
            {
                ParameterName = "F_Car",
                SqlDbType = SqlDbType.Int,
                Direction = ParameterDirection.Input,
                Value = pedido.F_Carnicero
            };
            params1[4] = new SqlParameter
            {
                ParameterName = "Env",
                SqlDbType = SqlDbType.Bit,
                Direction = ParameterDirection.Input,
                Value = pedido.Envio
            };
            params1[5] = new SqlParameter
            {
                ParameterName = "Pag",
                SqlDbType = SqlDbType.VarChar,
                Size = 50,
                Direction = ParameterDirection.Input,
                Value = pedido.Pago
            };

            string query = @"select COUNT(id_Pedido) as 'Numero' from Pedido where Envio = @Env;";

            SqlDataReader cont_atrapa = null;

            cont_atrapa = objacceso.ModificaBDunPocoMasSeguraDS(query, objacceso.AbrirConexion(ref mens_salida),
                ref mens_salida, params1);

            while (cont_atrapa.Read())
            {
                num = Convert.ToInt32(cont_atrapa["Numero"]);
            }
            return num;
        }

        public int OBTENERIDMR(ref string mens_salida)
        {
            int num = 0;

            string query = @"select MAX(F_Repartidor) as 'F_Repartidor' from EntregaPedido";

            SqlDataReader cont_atrapa = null;

            cont_atrapa = objacceso.ConsultarReader(query, objacceso.AbrirConexion(ref mens_salida),
                ref mens_salida);
            if (cont_atrapa.HasRows == true)
            {
                while (cont_atrapa.Read())
                {
                    try
                    {
                        num = Convert.ToInt32(cont_atrapa["F_Repartidor"]);
                    }
                    catch(Exception w)
                    {
                        num = 0;
                    }
                }
            }
            else
            {
                num = 0;
            }
            return num;
        }

        public int OBTENERIDMN(ref string mens_salida)
        {
            int num = 0;

            string query = @"select MIN(F_Repartidor) as 'F_Repartidor' from EntregaPedido;";

            SqlDataReader cont_atrapa = null;

            cont_atrapa = objacceso.ConsultarReader(query, objacceso.AbrirConexion(ref mens_salida),
                ref mens_salida);

            if (cont_atrapa.HasRows == true)
            {
                while (cont_atrapa.Read())
                {
                    try
                    {
                        num = Convert.ToInt32(cont_atrapa["F_Repartidor"]);
                    }
                    catch (Exception w)
                    {
                        num = 0;
                    }
                }
            }
            else
            {
                num = 0;
            }
            return num;
        }

        public int OBTENERIDCMX(ref string mens_salida)
        {
            int num = 0;

            string query = @"select MAX(F_Carnicero) as 'F_Carnicero' from Pedido";

            SqlDataReader cont_atrapa = null;

            cont_atrapa = objacceso.ConsultarReader(query, objacceso.AbrirConexion(ref mens_salida),
                ref mens_salida);

            if (cont_atrapa.HasRows == true)
            {
                while (cont_atrapa.Read())
                {
                    try
                    {
                        num = Convert.ToInt32(cont_atrapa["F_Carnicero"]);
                    }
                    catch (Exception w)
                    {
                        num = 0;
                    }
                }
            }
            else
            {
                num = 0;
            }
            return num;
        }

        public int OBTENERIDCMN(ref string mens_salida)
        {
            int num = 0;

            string query = @"select MIN(F_Carnicero) as 'F_Carnicero' from Pedido";

            SqlDataReader cont_atrapa = null;

            cont_atrapa = objacceso.ConsultarReader(query, objacceso.AbrirConexion(ref mens_salida),
                ref mens_salida);

            if (cont_atrapa.HasRows == true)
            {
                while (cont_atrapa.Read())
                {
                    try
                    {
                        num = Convert.ToInt32(cont_atrapa["F_Carnicero"]);
                    }
                    catch (Exception w)
                    {
                        num = 0;
                    }
                }
            }
            else
            {
                num = 0;
            }
            return num;
        }
        ///---------CRUD--------------------
        public List<Pedido> EliminarPedidos(int idC, ref string mens_salida)
        {
            List<Pedido> Pedidos = new List<Pedido>();
            SqlParameter[] params1 = new SqlParameter[1];
            params1[0] = new SqlParameter
            {
                ParameterName = "id",
                SqlDbType = SqlDbType.Int,
                Direction = ParameterDirection.Input,
                Value = idC
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

        public Boolean EliminPS(int idE, ref string mens_salida)
        {
            SqlParameter[] params1 = new SqlParameter[1];
            params1[0] = new SqlParameter
            {
                ParameterName = "idE",
                SqlDbType = SqlDbType.Int,
                Direction = ParameterDirection.Input,
                Value = idE
            };


            string sentencia = "DELETE FROM Pedido WHERE id_Pedido = @idE; ";

            Boolean salida = false;

            salida = objacceso.ModificaBDunPocoMasSegura(sentencia, objacceso.AbrirConexion(ref mens_salida), ref mens_salida, params1);

            return salida;
        }

        public Boolean EliminCarP(int idCar, ref string mens_salida)
        {
            SqlParameter[] params1 = new SqlParameter[1];
            params1[0] = new SqlParameter
            {
                ParameterName = "idCar",
                SqlDbType = SqlDbType.Int,
                Direction = ParameterDirection.Input,
                Value = idCar
            };


            string sentencia = "DELETE FROM Pedido WHERE F_Carnicero = @idCar; ";

            Boolean salida = false;

            salida = objacceso.ModificaBDunPocoMasSegura(sentencia, objacceso.AbrirConexion(ref mens_salida), ref mens_salida, params1);

            return salida;
        }

        public List<Pedido> EliminarProductosCar(int idC, ref string mens_salida)
        {
            List<Pedido> Pedidos = new List<Pedido>();
            SqlParameter[] params1 = new SqlParameter[1];
            params1[0] = new SqlParameter
            {
                ParameterName = "id",
                SqlDbType = SqlDbType.Int,
                Direction = ParameterDirection.Input,
                Value = idC
            };

            /*string query = @"select * from Pedido where F_Cliente = id";

            SqlDataReader todos = objacceso.ConsultarReader(query, objacceso.AbrirConexion(ref mens_salida), ref mens_salida);
            */

            string query = @"select * from Pedido where F_Carnicero = @id;";

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


        //---------------------------CRUD-------------------------------------

        public List<Pedido> LISTPEDIDO( ref string mens_salida)
        {
            List<Pedido> pedidos = new List<Pedido>();

            string query = @"select * from Pedido;";

            SqlDataReader cont_atrapa = null;

            cont_atrapa = objacceso.ConsultarReader(query, objacceso.AbrirConexion(ref mens_salida),
                ref mens_salida);

            
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
                pedidos.Add(temp);
            }
            return pedidos;
        }

        public Boolean EliminProdIDP(int idCar, ref string mens_salida)
        {
            SqlParameter[] params1 = new SqlParameter[1];
            params1[0] = new SqlParameter
            {
                ParameterName = "idCar",
                SqlDbType = SqlDbType.Int,
                Direction = ParameterDirection.Input,
                Value = idCar
            };


            string sentencia = "DELETE FROM Pedido WHERE F_Carnicero = @idCar; ";

            Boolean salida = false;

            salida = objacceso.ModificaBDunPocoMasSegura(sentencia, objacceso.AbrirConexion(ref mens_salida), ref mens_salida, params1);

            return salida;
        }

        public Boolean EliminPedido(int F_Pedido, ref string mens_salida)
        {
            SqlParameter[] params1 = new SqlParameter[1];
            params1[0] = new SqlParameter
            {
                ParameterName = "F_Pedido",
                SqlDbType = SqlDbType.Int,
                Direction = ParameterDirection.Input,
                Value = F_Pedido
            };


            string sentencia = "DELETE FROM Pedido WHERE id_Pedido = @F_Pedido; ";

            Boolean salida = false;

            salida = objacceso.ModificaBDunPocoMasSegura(sentencia, objacceso.AbrirConexion(ref mens_salida), ref mens_salida, params1);

            return salida;
        }

        public Boolean ActPedido(Pedido Pedi, ref string mens_salida)
        {
            SqlParameter[] params1 = new SqlParameter[6];
            params1[0] = new SqlParameter
            {
                ParameterName = "id_Pedido",
                SqlDbType = SqlDbType.Int,
                Direction = ParameterDirection.Input,
                Value = Pedi.id_Pedido
            };
            params1[1] = new SqlParameter
            {
                ParameterName = "FechaHora",
                SqlDbType = SqlDbType.DateTime,
                Direction = ParameterDirection.Input,
                Value = Pedi.FechaHora
            };
            params1[2] = new SqlParameter
            {
                ParameterName = "F_Cliente",
                SqlDbType = SqlDbType.Int,
                Direction = ParameterDirection.Input,
                Value = Pedi.F_Cliente
            };
            params1[3] = new SqlParameter
            {
                ParameterName = "F_Carnicero",
                SqlDbType = SqlDbType.Int,
                Direction = ParameterDirection.Input,
                Value = Pedi.F_Carnicero
            };
            params1[4] = new SqlParameter
            {
                ParameterName = "Envio",
                SqlDbType = SqlDbType.Bit,
                Direction = ParameterDirection.Input,
                Value = Pedi.Envio
            };
            params1[5] = new SqlParameter
            {
                ParameterName = "Pago",
                SqlDbType = SqlDbType.VarChar,
                Size = 50,
                Direction = ParameterDirection.Input,
                Value = Pedi.Pago
            };

            string sentencia = @"update Pedido
                                 set Pago = @Pago
                                 where id_Pedido = @id_Pedido;";

            Boolean salida = false;

            salida = objacceso.ModificaBDunPocoMasSegura(sentencia, objacceso.AbrirConexion(ref mens_salida), ref mens_salida, params1);

            return salida;
        }
    }
}
