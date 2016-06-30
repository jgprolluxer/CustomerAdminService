using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using MySql.Data.MySqlClient;

namespace Prollux.CustomerAdmin.WcfService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    public class ProlluxCustomerAdmin : IProlluxCustomerAdmin
    {
        public ResultData IsValidClient(ClientData clientData)
        {
            var err = "";
            var valid = false;

            try
            {
                var connString = ConfigurationManager.ConnectionStrings["ProlluxCustomerAdmin"].ConnectionString;

                using (var context = new MySqlConnection(connString))
                {
                    context.Open();

                    var sql = string.Format("SELECT ClientId, Valid FROM Clients WHERE ClientId = {0}", clientData.ClientId);
                    var cmd = new MySqlCommand(sql, context);

                    using (var rdr = cmd.ExecuteReader())
                    {
                        while (rdr.Read())
                        {
                            valid = rdr["Valid"].ToString() == "1";
                        }
                    }
                }
            }
            catch (Exception e)
            {
                err = e.Message;
            }

            var result = new ResultData
            {
                Error = err,
                Valid = valid
            };

            return result;
        }
    }
}
