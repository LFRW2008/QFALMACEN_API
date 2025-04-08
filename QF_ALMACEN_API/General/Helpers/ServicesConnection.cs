using Dapper;
using Microsoft.Data.SqlClient;
using Newtonsoft.Json;
using System.Data;

namespace QF_ALMACEN_API.General.Helpers
{
    public class ServicesConnection
    {
        private string? _connection = "";
        private readonly string? _connectionSISLAB;
        private readonly string? _connectionLOGISTICA;
        private readonly string? _connectionSIGE;

        private readonly string ? _connectionALMACEN;
        public ServicesConnection(IConfiguration configuration)
        {
            _connectionLOGISTICA = configuration.GetConnectionString("LogisticaQFConnection");
            //_connection = configuration.GetConnectionString("LogisticaQFConnection");
            // _connectionSISLAB = configuration.GetConnectionString("SislabConnection");

            //_connectionSIGE = configuration.GetConnectionString("SigeConnection");

            _connectionALMACEN = configuration.GetConnectionString("AlmacenConnection");


        }
        private void GetConexion(int idconexion)
        {
            if (idconexion == 1)
            {
                _connection = _connectionLOGISTICA;
            }
            else if (idconexion == 2)
            {
                _connection = _connectionSISLAB;
            }
            else if (idconexion == 3)
            {
                _connection = _connectionSIGE;
            }else if(idconexion == 4)
            {
                _connection = _connectionALMACEN;
            }

        }

        //Metodo que retorna una tabla
        public string MetodoDatatabletostringsql(string procedimiento, DynamicParameters? parametros, int idconexion)
        {
            try
            {
                GetConexion(idconexion);
                using (var connection = new SqlConnection(_connection))
                {
                    var datatable = new DataTable();

                    using (var command = new SqlCommand(procedimiento, connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        if (parametros is not null)
                        {
                            // Agregar parámetros al comando
                            foreach (var param in parametros.ParameterNames)
                            {
                                command.Parameters.Add(new SqlParameter(param, parametros.Get<dynamic>(param)));
                            }
                        }

                        // Llenar el DataTable con el resultado
                        using (var adapter = new SqlDataAdapter(command))
                        {
                            connection.Open();
                            adapter.Fill(datatable);
                        }
                    }

                    // Convertir el DataTable a JSON y devolverlo
                    return JsonConvert.SerializeObject(datatable);
                }
            }
            catch (Exception ex)
            {
                // Manejar excepciones
                return null;
            }
        }
        //Metodo que retorna un output
        public string MetodoRespuestasql(string procedimiento, DynamicParameters parametros, int sizeParametroSalida, int idconexion)
        {
            try
            {
                GetConexion(idconexion);
                string parametrosalida = "@respuesta";
                string respuesta = "";
                using (var connection = new SqlConnection(_connection))
                {
                    using (var command = new SqlCommand(procedimiento, connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        if (parametros is not null)
                        {
                            foreach (var param in parametros.ParameterNames)
                            {
                                command.Parameters.AddWithValue(param, parametros.Get<dynamic>(param));
                            }
                            command.Parameters.Add(parametrosalida, SqlDbType.VarChar, sizeParametroSalida).Direction = ParameterDirection.Output;
                        }
                        connection.Open();
                        int rpt = command.ExecuteNonQuery();
                        if (rpt > 0)
                        {
                            respuesta = command.Parameters[parametrosalida].Value.ToString();
                        }
                        else
                        {
                            respuesta = command.Parameters[parametrosalida].Value.ToString();
                        }
                        connection.Close();
                    }
                    return respuesta;
                }
            }
            catch (Exception vEx)
            {
                // Manejar excepciones
                return vEx.Message.ToString();
            }
        }
        //Metodo que te da una respuesta en caso se haya ejecutado algun registro
        public string MetodoRespuestasql(string procedimiento, DynamicParameters parametros, int idconexion)
        {
            try
            {
                GetConexion(idconexion);
                string respuesta = "";
                using (var connection = new SqlConnection(_connection))
                {
                    using (var command = new SqlCommand(procedimiento, connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        if (parametros is not null)
                        {
                            foreach (var param in parametros.ParameterNames)
                            {
                                command.Parameters.AddWithValue(param, parametros.Get<dynamic>(param));
                            }
                        }
                        connection.Open();
                        if (command.ExecuteNonQuery() > 0)
                        {
                            respuesta = "Ok";
                        }
                        else
                        {
                            respuesta = "Vacio";
                        }
                        connection.Close();
                    }
                    return respuesta;
                }
            }
            catch (Exception vEx)
            {
                // Manejar excepciones
                return vEx.Message.ToString();
            }
        }
        //Metodo que te retorna una tabla de manera asincrona
        public async Task<string> MetodoDatatabletostringsqlasync(string procedimiento, DynamicParameters parametros, int idconexion)
        {
            try
            {
                GetConexion(idconexion);
                using (var connection = new SqlConnection(_connection))
                {
                    var datatable = new DataTable();

                    using (var command = new SqlCommand(procedimiento, connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        if (parametros is not null)
                        {
                            // Agregar parámetros al comando
                            foreach (var param in parametros.ParameterNames)
                            {
                                command.Parameters.Add(new SqlParameter(param, parametros.Get<dynamic>(param)));
                            }
                        }

                        // Llenar el DataTable con el resultado
                        using (var adapter = new SqlDataAdapter(command))
                        {
                            await connection.OpenAsync();
                            adapter.Fill(datatable);
                        }
                    }

                    // Convertir el DataTable a JSON y devolverlo
                    return JsonConvert.SerializeObject(datatable);
                }
            }
            catch (Exception ex)
            {
                // Manejar excepciones
                return null;
            }
        }

        public string EjecutarProcedimiento(string procedimiento, DynamicParameters parametros, int idconexion)
        {
            try
            {
                GetConexion(idconexion);
                using (var connection = new SqlConnection(_connection))
                {
                    using (var command = new SqlCommand(procedimiento, connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        // Agregar los parámetros al comando si existen
                        if (parametros is not null)
                        {
                            foreach (var param in parametros.ParameterNames)
                            {
                                command.Parameters.AddWithValue(param, parametros.Get<dynamic>(param));
                            }
                        }

                        connection.Open();

                        // Ejecutar el procedimiento almacenado
                        int resultado = command.ExecuteNonQuery();

                        // Confirmar si la operación fue exitosa
                        return resultado > 0 ? "Ok" : "Vacio";
                    }
                }
            }
            catch (Exception ex)
            {
                // Devolver el mensaje de error en caso de excepción
                return ex.Message;
            }
        }

        public string EjecutarProcedimientoConSalida(string procedimiento, DynamicParameters parametros, string nombreParametroSalida, int idconexion)
        {
            try
            {
                GetConexion(idconexion);
                using (var connection = new SqlConnection(_connection))
                {
                    connection.Execute(procedimiento, parametros, commandType: CommandType.StoredProcedure);

                    // Recupera el valor del parámetro de salida
                    return parametros.Get<string>(nombreParametroSalida);
                }
            }
            catch (Exception ex)
            {
                // Retorna el mensaje de error en caso de excepción
                return $"Error: {ex.Message}";
            }
        }

    }

}
