using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using CapaModelo;
using System.Data.SqlClient;
using System.Data;

namespace CapaDAO
{
    public class UserDAO
    {

        string connection = ConfigurationManager.ConnectionStrings["ConnectSysCloud"].ConnectionString;
        
        public List<User> getAllUser()
	    {

		    List<User> lstUser = null;
		
		    SqlConnection cn = new SqlConnection(connection);
		    cn.Open();
		
		    SqlCommand cmd = new SqlCommand{
		
			   CommandType = CommandType.StoredProcedure,
               CommandText = "uspGetAllUser",
			    Connection = cn		
		    };
		
		
		    using(SqlDataReader dr = cmd.ExecuteReader(CommandBehavior.SingleResult))		
		    {
			    if(dr != null){
				
				    lstUser = new List<User>();
				    while(dr.Read())
				    {
					    lstUser.Add(new User()
					    {
						    PK_user = Convert.ToInt32(dr["PK_user"]),
						    username = dr["username"].ToString(),
                            firstName = dr["firstName"].ToString(),
                            lastName = dr["lastName"].ToString()
					    });
				    }
			    }
		
		    }
		
		    return lstUser;

	    }

    }
}