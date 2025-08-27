using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventarioDB
{
    public class ConnectionString
    {
        private static ConnectionString _instance;
        private string _value;

        private ConnectionString()
        {
            // Constructor privado para evitar instanciación directa
        }

        public static ConnectionString Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new ConnectionString();
                }
                return _instance;
            }
        }

        public string Value
        {
            get { return _value; }
            set { _value = value; }
        }
    }

}
