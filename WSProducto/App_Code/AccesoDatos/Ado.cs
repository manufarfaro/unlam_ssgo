using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections;
using System.Configuration;


namespace AccesoDatos
{
    public class Ado
    {
        string sConexion;
        SqlCommand sqlComm;
        SqlConnection cnx;
        SqlDataAdapter sqlDA;
        DataTable dtResultado;
        SqlTransaction transaccion;
        Int32 cantidadParametros = 0;
        Int32 numeroDeRegistro = 0;

        public Ado()
        {

        }

        public SqlConnection Conectar()
        {
            ConnectionStringSettingsCollection settings = ConfigurationManager.ConnectionStrings;

            sConexion = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;

            if (cnx == null)
                cnx = new SqlConnection(sConexion);

            if (cnx.State == ConnectionState.Closed)
                cnx.Open();


            return cnx;

        }

        public DataTable EjecutarSelect(string sSql)
        {

            cnx = Conectar();
            DataTable dt = new DataTable();

            SqlDataAdapter cmd = new SqlDataAdapter(sSql, cnx);
            if (cmd != null)
            {
                cmd.Fill(dt);
            }
            else
            {
                dt = null;
            }
            cnx.Close();
            return dt;
        }

        public int EjecutarSelectCount(string sSql)
        {
            cnx = Conectar();
            //DataTable dt = new DataTable();
            SqlCommand cmd = new SqlCommand(sSql, cnx);
            int t = Convert.ToInt32(cmd.ExecuteScalar());
            cnx.Close();
            return (t);
        }




        //private string CadenaConexion()
        //{
        //    SqlConnectionStringBuilder csb = new SqlConnectionStringBuilder();
        //    csb.DataSource = @"HOME\SQL2005";
        //    csb.InitialCatalog = "TallerASPNET_ADO";
        //    csb.IntegratedSecurity = false;
        //    csb.UserID = "sa";
        //    csb.Password = "globons";

        //    return csb.ConnectionString;
        //}

        private bool ComenzarTransaccion()
        {
            try
            {
                transaccion = cnx.BeginTransaction();
            }
            catch (SqlException sqlEx)
            {
                return false;
            }

            return true;

        }

        private bool FinalizarTransaccion()
        {
            try
            {
                transaccion.Commit();
            }
            catch (SqlException sqlEx)
            {
                transaccion.Rollback();
                return false;
            }

            return true;

        }

        private bool CancelarTransaccion()
        {
            try
            {
                transaccion.Rollback();
            }
            catch (SqlException sqlEx)
            {
                return false;
            }

            return true;

        }

        #region Ejemplo 5
        //public bool EjecutarStoredProcedure(bool tieneTransaccion, string nombreSP, ArrayList sqlParametros)
        //{
        //    if (Conectar())
        //    {

        //        sqlComm = new SqlCommand();		// Instancio el objeto Command de la clase
        //        sqlComm.Connection = sqlConn;	    // Asigno la conexión activa al Command

        //        sqlComm.CommandType = CommandType.StoredProcedure;	// Indico que se trata de un procedimiento almacenado
        //        sqlComm.CommandText = nombreSP;		                // Indico cual es el stored procedure

        //        if (tieneTransaccion)
        //            sqlComm.Transaction = transaccion;

        //        SqlCommandBuilder.DeriveParameters(sqlComm);       // Obtengo los Parametros del SP del SQLServer

        //        Int32 cantidadParametros;

        //        if (sqlParametros == null)
        //            cantidadParametros = 0;
        //        else
        //            cantidadParametros = sqlParametros.Count;

        //        if (cantidadParametros == sqlComm.Parameters.Count - 1)
        //        {
        //            for (int i = 1; i <= sqlComm.Parameters.Count - 1; i++)
        //            {
        //                sqlComm.Parameters[i].Value = sqlParametros[i - 1];		// Agrego el parámetro sqlConn el valor del cod de la provincia para obtener sus localidades
        //            }

        //            sqlComm.ExecuteNonQuery();

        //            return true;
        //        }

        //    }

        //    return false;
        //}

        public DataSet DevolverDatos()
        {

            DataSet ds = new DataSet();

            sqlDA = new SqlDataAdapter(sqlComm);

            sqlDA.Fill(ds);

            return ds;


        }
        #endregion Ejemplo 5

        #region Ejemplo 6
        //public bool EjecutarStoredProcedureDataReader(String nombreSP, ArrayList sqlParametros)
        //{
        //    if (Conectar())
        //    {

        //        sqlComm = new SqlCommand();		// Instancio el objeto Command de la clase
        //        sqlComm.Connection = sqlConn;	    // Asigno la conexión activa al Command

        //        sqlComm.CommandType = CommandType.StoredProcedure;	// Indico que se trata de un procedimiento almacenado
        //        sqlComm.CommandText = nombreSP;		                // Indico cual es el stored procedure


        //        SqlCommandBuilder.DeriveParameters(sqlComm);       // Obtengo los Parametros del SP del SQLServer

        //        if (sqlParametros == null)
        //            cantidadParametros = 0;
        //        else
        //            cantidadParametros = sqlParametros.Count;

        //        if (cantidadParametros == sqlComm.Parameters.Count - 1)
        //        {
        //            for (int i = 1; i <= sqlComm.Parameters.Count - 1; i++)
        //            {
        //                sqlComm.Parameters[i].Value = sqlParametros[i - 1];		// Agrego el parámetro sqlConn el valor del cod de la provincia para obtener sus localidades
        //            }

        //            numeroDeRegistro = 0;

        //            dtResultado = new DataTable();

        //            dtResultado.Load(sqlComm.ExecuteReader(CommandBehavior.CloseConnection));

        //            return true;
        //        }

        //    }

        //    return false;
        //}

        public DataTable DevolverDatosRapido()
        {

            return (dtResultado);	// Retorno el DataSet interno de la clase


        }

        #endregion Ejemplo 6

        #region Ejemplo 7

        public string DevolverRegistro()
        {
            string registro = String.Empty;

            if (dtResultado.Rows.Count > numeroDeRegistro)
            {
                for (int iColumna = 0; iColumna <= dtResultado.Columns.Count - 1; iColumna++)
                {
                    if (registro == String.Empty)
                        registro += dtResultado.Rows[numeroDeRegistro][iColumna].ToString();
                    else
                        registro += "|" + dtResultado.Rows[numeroDeRegistro][iColumna].ToString();
                }

                numeroDeRegistro++;
            }

            return (registro);	// Retorno el Registro Actual


        }

        #endregion Ejemplo 7
    }

}
