using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using AccesoDatos;

/// <summary>
/// Summary description for LoginService
/// </summary>
public class LoginService
{
    public LoginService() { }

    public bool ValidarQuePuedeVerLaPagina()
    {
        return false;
    }

    public Login validarLogin(string usuario, string password)
    {
        AccesoDatos.Ado oAdo = new AccesoDatos.Ado();
        Login login = new Login();

        SqlConnection Cnx = oAdo.Conectar();
        if (Cnx.State == ConnectionState.Open)
        {
            string sSql;
            sSql = "exec sp_UsuariosGetByUsernameAndPassword @UserName, @UserPassword";

            DataTable dt = new DataTable();
            SqlCommand cmd = new SqlCommand(sSql, Cnx);
            cmd.Parameters.AddWithValue("@UserName", usuario);
            cmd.Parameters.AddWithValue("@UserPassword", password);

            SqlDataReader dataReader = cmd.ExecuteReader();

            if (dataReader.HasRows)
            {
                while (dataReader.Read())
                {

                    login.id_Empresa = dataReader.GetInt32(0);
                    login.id_CategoriaUsuario = dataReader.GetInt32(1);
                    login.id_Usuario = dataReader.GetInt32(2);
                    login.UserName = dataReader.GetString(3);
                    login.Password = dataReader.GetString(4);
                    login.Activo = dataReader.GetString(4);

                }
            }
            else
            {
                login.id_Usuario = -1;
            }

            Cnx.Close();
        }
        else
        {
            login.id_Usuario = -1;
        }

        if (login.Activo == "N" || login.Activo == "n")
        {
            login.id_Usuario = -2;
        }


        return (login);

    }
    public bool ConsultarUserIdExistente(Login lg)
    {
        Ado ad = new Ado();
        string sSql;
        int count;

        sSql = "SELECT count(*)";
        sSql = sSql + "FROM [Basedatos].[dbo].[Usuarios]";
        sSql = sSql + "where Usuario = '";
        sSql = sSql + lg.UserName;
        sSql = sSql + "' ;";


        count = ad.EjecutarSelectCount(sSql);
        if (count > 0)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public bool insertEnUsuarios(Login lg)
    {
        Ado ad = new Ado();
        SqlConnection cnx = ad.Conectar();
        //Insertamos en Usuarios
        string SqlString2 = " insert into [Basedatos].[dbo].[Usuarios] ([id_Empresa] ";
        SqlString2 = SqlString2 + " ,[id_CategoriaUsuario] ";
        //SqlString2 = SqlString2 + " ,[id_Usuario] ";
        SqlString2 = SqlString2 + " ,[Usuario] ";
        SqlString2 = SqlString2 + " ,[Password] ";
        SqlString2 = SqlString2 + " ,[Activo]) ";
        SqlString2 = SqlString2 + " values (@id_empresa, @id_CategoriaUsuario, @Usuario, @Password, @Activo); ";

        SqlCommand cmd2 = new SqlCommand(SqlString2, cnx);

        cmd2.CommandType = CommandType.Text;
        cmd2.Parameters.AddWithValue("@id_empresa", lg.id_Empresa);
        cmd2.Parameters.AddWithValue("@id_CategoriaUsuario", lg.id_CategoriaUsuario);
        //cmd2.Parameters.AddWithValue("@id_Usuario", );
        cmd2.Parameters.AddWithValue("@Usuario", lg.UserName);
        cmd2.Parameters.AddWithValue("@Password", lg.Password);
        cmd2.Parameters.AddWithValue("@Activo", "N");
        int resultadoInsert2 = cmd2.ExecuteNonQuery();
        if (resultadoInsert2 > 0)
        {
            return (true);
        }
        else
        {
            return (false);
        }
    }
    public virtual bool insertDatos()
    {
        return false;
    }
    
    public virtual bool ModificarDatos()
    {
        return false;
    }

    public int consultarIdUsuario(string UserId)
    {
        Ado ad = new Ado();
        SqlConnection cnx = ad.Conectar();
        string sSql;
        sSql = " SELECT id_Usuario";
        sSql = sSql + " FROM [Basedatos].[dbo].[Usuarios]";
        sSql = sSql + " where Usuario = '";
        sSql = sSql + UserId;
        sSql = sSql + "'";

        SqlCommand cmd = new SqlCommand(sSql, cnx);

        cmd.CommandType = CommandType.Text;

        int idusuario = Convert.ToInt32(cmd.ExecuteScalar());
        return (idusuario);
    }
    public int consultarIdEmpresa(string RazonSocial)
    {
        Ado ad = new Ado();
        SqlConnection cnx = ad.Conectar();
        string sSql;
        sSql = " SELECT id_Empresa";
        sSql = sSql + " FROM [Basedatos].[dbo].[Empresas_datos]";
        sSql = sSql + " where RazonSocial = '";
        sSql = sSql + RazonSocial;
        sSql = sSql + "'";

        SqlCommand cmd = new SqlCommand(sSql, cnx);

        cmd.CommandType = CommandType.Text;

        int resultadoInsert = (int)cmd.ExecuteScalar();
        return (resultadoInsert);
    }

    public bool ModificarPassword(Login lg)
    {
        Ado ad = new Ado();
        SqlConnection cnx = ad.Conectar();

        string sSql = " UPDATE [Basedatos].[dbo].[Usuarios]";
        sSql = sSql + " SET [Password] ='";
        sSql = sSql + lg.Password;
        sSql = sSql + "' ";
        sSql = sSql + " WHERE ";
        sSql = sSql + " id_usuario = '" + lg.id_Usuario + "';";

        SqlCommand cmd = new SqlCommand(sSql, cnx);

        cmd.CommandType = CommandType.Text;

        int resultadoInsert = cmd.ExecuteNonQuery();

        if (resultadoInsert > 0)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public bool eliminar(Login lg)
    {
        AccesoDatos.Ado oAdo = new AccesoDatos.Ado();
        SqlConnection Cnx = oAdo.Conectar();
        if (Cnx.State == ConnectionState.Open)
        {
            string sSql;
            sSql = " DELETE FROM [dbo].[Usuarios]";
            sSql += " WHERE id_Usuario = @ID_usuario ";

            SqlCommand cmd = new SqlCommand(sSql, Cnx);
            cmd.Parameters.AddWithValue("@ID_usuario", lg.id_Usuario);

            int resultadoInsert = cmd.ExecuteNonQuery();
            
            Cnx.Close();

            if (resultadoInsert > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        else
        {
            return false;
        }
    }

    public bool ActualizarActivo(Login lg)
    {
        Ado ad = new Ado();
        SqlConnection cnx = ad.Conectar();

        string sSql = " UPDATE [Basedatos].[dbo].[Usuarios]";
        sSql = sSql + " SET [Activo] ='";
        sSql = sSql + lg.Activo;
        sSql = sSql + "' ";
        sSql = sSql + " WHERE ";
        sSql = sSql + " id_Empresa = '" + lg.id_Empresa + "';";

        SqlCommand cmd = new SqlCommand(sSql, cnx);

        cmd.CommandType = CommandType.Text;

        int resultadoInsert = cmd.ExecuteNonQuery();

        if (resultadoInsert > 0)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

}