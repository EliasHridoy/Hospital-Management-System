using System.Data.SqlClient;
using System.Web.Configuration;

namespace HospitalManagmentSystemWebApp.Gateways
{
    public class CommonGateway
    {

        public SqlConnection Connection { get; set; }
        public SqlCommand Command { get; set; }
        public SqlDataReader Reader { get; set; }

        public string query;

        public CommonGateway()
        {
            string conString = WebConfigurationManager.ConnectionStrings["HospitalManagmentDB"].ConnectionString;
            Connection =  new SqlConnection(conString);
        }
    }
}