using CapaModelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;

namespace CapaDAO
{
    public class PeriodicoDAO
    {
        string connection = ConfigurationManager.ConnectionStrings["ConnectMetaDocs"].ConnectionString;

        public List<Periodico> ListPagination(int pageIndex, int pageSize, int pageCount) 
        {

            List<Periodico> oPeriodico = null;

            SqlConnection cn = new SqlConnection(connection);
            cn.Open();


            SqlCommand cmd = new SqlCommand
            {
                CommandType = CommandType.StoredProcedure,
                CommandText = "uspDocsLst",
                Connection = cn
            };


            SqlParameter param1 = cmd.Parameters.AddWithValue("@PageIndex", pageIndex );
            param1.Direction = ParameterDirection.Input;

            SqlParameter param2 = cmd.Parameters.AddWithValue("@PageSize", pageSize );
            param2.Direction = ParameterDirection.Input;

            SqlParameter param3 = cmd.Parameters.AddWithValue("@PageCount", 0);
            param3.Direction = ParameterDirection.Output;
            

            using (SqlDataReader dr = cmd.ExecuteReader(CommandBehavior.SingleResult))
            {
                if (dr != null)
                {
                    oPeriodico = new List<Periodico>();
                    while(dr.Read())
                    {
                        oPeriodico.Add(new Periodico()
                        {
                            Pk_Doc = Convert.ToInt32(dr["Pk_Doc"]),
                            Fk_Cat = Convert.ToInt32(dr["FK_cat"]),
                            Categoria = dr["Cat"].ToString(),
                            dateInclude = Convert.ToDateTime( dr["dateInclude"])
                        });
                    }
                    
                }               
            }
            pageCount = cmd.Parameters["@PageCount"].Value != null ? (int)cmd.Parameters["@PageCount"].Value : -1;
            return oPeriodico;
            
        }

        public List<Periodico> getAllDocs (Periodico Item)
        {

            List<Periodico> oPeriodico = null;

            SqlConnection cn = new SqlConnection(connection);
            cn.Open();


            SqlCommand cmd = new SqlCommand
            {
                CommandType = CommandType.StoredProcedure,
                CommandText = "uspGetByDateInclude",
                Connection = cn
            };


            SqlParameter param1 = cmd.Parameters.AddWithValue("@dateInicio",Item.dateInicio ?? "" ?? null);
            param1.Direction = ParameterDirection.Input;

            SqlParameter param2 = cmd.Parameters.AddWithValue("@dateFin", Item.dateFin ?? "" ?? null);
            param2.Direction = ParameterDirection.Input;

            using (SqlDataReader dr = cmd.ExecuteReader(CommandBehavior.SingleResult))
            {
                if (dr != null)
                {
                    oPeriodico = new List<Periodico>();
                    while (dr.Read())
                    {
                        oPeriodico.Add(new Periodico()
                        {
                            Pk_Doc = Convert.ToInt32(dr["Pk_Doc"]),
                            Fk_Cat = Convert.ToInt32(dr["FK_cat"]),
                            Categoria = dr["Cat"].ToString(),
                            dateInclude = Convert.ToDateTime(dr["dateInclude"]),
                            //dateInicio = Convert.ToDateTime(dr["dateStart"]),
                            //dateFin = Convert.ToDateTime(dr["dateEnd"])
                            dateInicio = dr["dateStart"].ToString(),
                            dateFin = dr["dateEnd"].ToString()
                        });
                    }
                }
            }

            return oPeriodico;

        }
    }
}
