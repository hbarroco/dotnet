using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace HB.Sorte.Online.Data.Connection
{
    public class ProviderConnection
    {
        private string _hbApostasConnection { get; set; }

        public ProviderConnection(string hbApostasConnection)
        {
            this._hbApostasConnection = hbApostasConnection;
        }        

        public IDbConnection GetHBApostasConnection
        {
            get
            {
                var connection = new SqlConnection(this._hbApostasConnection);                
                return connection;
            }
        }
    }
}