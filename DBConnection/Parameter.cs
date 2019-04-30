using System;

using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
namespace DBConnection
{
    public class Parameter
    {
        
        //Atributos
        public String name {get; set;}
        public String value { get; set; }


   

        //CONSTRUCTORES
        public Parameter()
        {
        }

        public Parameter(String objName, String objValue)
        {
            name = objName;
            value = objValue;
           
        }



    }
}
