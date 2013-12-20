using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;

/// <summary>
/// Summary description for BusinessException
/// </summary>
public class BusinessException
{

    /*
     *
     * SQL SP Script:
     * 
        CREATE PROCEDURE [dbo].[sp_IncidentHistoryInsert]
            @UserMessage TEXT,
            @UserSource VARCHAR(100)
        AS
        BEGIN
	        INSERT INTO [dbo].[IncidentHistory]
		        ([Message], [Source])
	        VALUES
		        (@UserMessage, @UserSource)
        END

     */
    public BusinessException(Exception exception)
{
        try
        {
            AccesoDatos.Ado oAdo = new AccesoDatos.Ado();
            SqlConnection Cnx = oAdo.Conectar();
            if (Cnx.State == ConnectionState.Open)
            {
                string sSql;
                sSql = "exec sp_IncidentHistoryInsert @UserMessage ,@UserSource ";

                SqlCommand cmd = new SqlCommand(sSql, Cnx);

                cmd.Parameters.AddWithValue("@UserMessage", exception.Message);
                cmd.Parameters.AddWithValue("@UserSource", exception.Source);

                cmd.ExecuteNonQuery();
                Cnx.Close();
            }
        }
        catch(Exception exceptional)
        {
            /* Do nothing */
        }
        /**/

        
	}
}