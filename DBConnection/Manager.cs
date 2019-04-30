using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace DBConnection
{
    public class Manager
    {

        //INSTANCIA DE CONEXION A LA BASE DE DATOS
        public SqlConnection conexion = new SqlConnection("Data Source=.;Initial Catalog=TPOSWS;Integrated Security=True");

        //METODO PARA EJECUTAR PROCESO ALMACENADO DE FORMA GENERICA
        //PARA TRAER INFORMACIÓN
        public DataSet execute(String nameSP, List<Parameter> lst)
        {
            DataSet data = new DataSet();
            SqlDataAdapter da;
            try
            {
                connect();
                da = new SqlDataAdapter(nameSP, conexion);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;

                if (null != lst)
                {
                  
                    for (int i = 0; i < lst.Count; i++)
                    {
                        //Pasamos cada uno de los parámetros
                        da.SelectCommand.Parameters.AddWithValue(lst[i].name, lst[i].value);

                    }
                }

                da.Fill(data);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            disconnect();
            return data;
        }

        
        //METODOS PARA CONECTAR Y DESCONECTAR DE LA BASE DE DATOS
        private void connect()
        {
            if (conexion.State == ConnectionState.Closed)
                conexion.Open();
        }

        private void disconnect()
        {
            if (conexion.State == ConnectionState.Open)
                conexion.Close();
        }
    }
}
