using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using AccesoDatos;

/// <summary>
/// Summary description for UsuarioService
/// </summary>
public class UsuarioService : LoginService
{
    public UsuarioService()
    {
        //
        // TODO: Add constructor logic here
        //
    }
    public List<Usuario> GetAllByCompanyId(int Company_Id)
    {

        List<Usuario> lsUsuario = new List<Usuario>();

        Ado ad = new Ado();
        string sSql = "";
        //sSql = " SELECT [id_Usuario] ,[id_CategoriaUsuario] ,[id_Empresa] ,[Nombre] ,[Apellido] ,[Documento] ,[Telefono] ,[Direccion] ,[email]";
        //sSql = sSql + " FROM [dbo].[Usuarios_Datos] udt";
        //sSql = sSql + " INNER JOIN [Usuarios]";
        //sSql = sSql + " WHERE [id_Empresa] = " + Company_Id;

        sSql = " SELECT [Usuario]";
        sSql = sSql + " ,d.[id_Usuario]";
        sSql = sSql + " ,[Nombre]";
        sSql = sSql + " ,[Apellido]";
        sSql = sSql + " ,[Documento]";
        sSql = sSql + " ,[id_TipoDocumento]";
        sSql = sSql + " ,[Telefono]";
        sSql = sSql + " ,[Direccion]";
        sSql = sSql + " ,[email]";
        sSql = sSql + " FROM Usuarios_Datos d INNER JOIN Usuarios u ON d.id_Usuario = u.id_Usuario WHERE d.id_empresa = " + Company_Id;


        DataTable dt = new DataTable();
        dt = ad.EjecutarSelect(sSql);


        foreach (DataRow dr in dt.Rows)
        {
            Usuario usuario = new Usuario();

            usuario.UserName = Convert.ToString(dr["Usuario"]);
            usuario.id_Usuario = Convert.ToInt32(dr["id_Usuario"]);
            usuario.nombre = Convert.ToString(dr["Nombre"]);
            usuario.apellido = Convert.ToString(dr["Apellido"]);
            usuario.documento = Convert.ToString(dr["Documento"]);
            usuario.telefono = Convert.ToString(dr["Telefono"]);
            usuario.direccion = Convert.ToString(dr["Direccion"]);
            usuario.email = Convert.ToString(dr["email"]);

            lsUsuario.Add(usuario);
        }
        return (lsUsuario);

    }
    public ArrayList getAll()
    {
        ArrayList colUsuarios = new ArrayList();

        Usuario usuario = new Usuario();
        usuario.id_Usuario = 1;
        usuario.nombre = "Maxi";
        usuario.apellido = "Caronte";
        usuario.email = "maxicaronte@gmail.com";
        usuario.UserName = "maxicaronte";
        usuario.Password = "maxi123";
        usuario.Activo = "s";

        Usuario usuario2 = new Usuario();
        usuario2.id_Usuario = 2;
        usuario2.nombre = "Manu";
        usuario2.apellido = "Farfaro";
        usuario2.email = "manu.farfaro@gmail.com";
        usuario2.UserName = "manufarfaro";
        usuario2.Password = "manu123";
        usuario2.Activo = "s";

        Usuario usuario3 = new Usuario();
        usuario3.id_Usuario = 3;
        usuario3.nombre = "Ilian";
        usuario3.apellido = "Schneider";
        usuario3.email = "i.sch144@gmail.com";
        usuario3.UserName = "illianschneider";
        usuario3.Password = "illian123";
        usuario3.Activo = "s";


        colUsuarios.Add(usuario);
        colUsuarios.Add(usuario2);
        colUsuarios.Add(usuario3);

        return (colUsuarios);
    }

    public bool RegistrarUsuario(Usuario usuario1)
    {
        Ado ad = new Ado();
        SqlConnection cnx = ad.Conectar();

        if (base.insertEnUsuarios(usuario1))
        {
            usuario1.id_Usuario = base.consultarIdUsuario(usuario1.UserName);
        }
        else
        {
            return false;
        }
        //Insertamos en Empresa_Datos
        string SqlString = " insert into [Basedatos].[dbo].[usuarios_Datos] ([id_Usuario] ";
        SqlString = SqlString + " ,[id_CategoriaUsuario] ";
        SqlString = SqlString + " ,[id_Empresa] ";
        SqlString = SqlString + " ,[Nombre] ";
        SqlString = SqlString + " ,[Apellido] ";
        SqlString = SqlString + " ,[Documento] ";
        SqlString = SqlString + " ,[Telefono] ";
        SqlString = SqlString + " ,[Direccion] ";
        SqlString = SqlString + " ,[email]) ";
        SqlString = SqlString + " values (@id_Usuario,@id_CategoriaUsuario,@id_Empresa,@Nombre,@Apellido";
        SqlString = SqlString + ",@Documento,@Telefono,@Direccion,@email); ";

        SqlCommand cmd = new SqlCommand(SqlString, cnx);

        cmd.CommandType = CommandType.Text;
        cmd.Parameters.AddWithValue("@id_Usuario", usuario1.id_Usuario);
        cmd.Parameters.AddWithValue("@id_CategoriaUsuario", usuario1.id_CategoriaUsuario);
        cmd.Parameters.AddWithValue("@id_Empresa", usuario1.id_Empresa);
        cmd.Parameters.AddWithValue("@Nombre", usuario1.nombre);
        cmd.Parameters.AddWithValue("@Apellido", usuario1.apellido);
        cmd.Parameters.AddWithValue("@Documento", usuario1.documento);
        cmd.Parameters.AddWithValue("@Telefono", usuario1.telefono);
        cmd.Parameters.AddWithValue("@Direccion", usuario1.direccion);
        cmd.Parameters.AddWithValue("@email", usuario1.email);



        int resultadoInsert1 = cmd.ExecuteNonQuery();

        cnx.Close();
        if (resultadoInsert1 > 0)
        {
            return true;
        }
        else
        {
            return false;
        }



    }

    public Usuario ObtenerDatosUsuario(Usuario usuario)
    {
        Ado ad = new Ado();
        DataTable dt = new DataTable();
        try
        {


            string sSql;
            sSql = "SELECT ud.[id_Usuario] ";
            sSql += ", u.[Usuario] ";
            sSql += ", ud.[id_CategoriaUsuario] ";
            sSql += ", ud.[id_Empresa] ";
            sSql += ", ud.[Nombre] ";
            sSql += ", ud.[Apellido] ";
            sSql += ", ud.[Documento] ";
            sSql += ", ud.[id_TipoDocumento] ";
            sSql += ", ud.[Telefono] ";
            sSql += ", ud.[Direccion] ";
            sSql += ", ud.[email] ";
            sSql += "FROM [dbo].[Usuarios_Datos] ud ";
            sSql += "INNER JOIN [dbo].[Usuarios] u ";
            sSql += "ON ud.[id_Usuario] = u.[id_Usuario] ";
            sSql += "WHERE ud.[id_usuario] = ";
            sSql += usuario.id_Usuario;

            dt = ad.EjecutarSelect(sSql);
            foreach (DataRow dr in dt.Rows)
            {
                usuario.UserName = Convert.ToString(dr["Usuario"]);
                usuario.nombre = Convert.ToString(dr["Nombre"]);
                usuario.apellido = Convert.ToString(dr["Apellido"]);
                usuario.documento = Convert.ToString(dr["Documento"]);
                usuario.telefono = Convert.ToString(dr["Telefono"]);
                usuario.direccion = Convert.ToString(dr["Direccion"]);
                usuario.email = Convert.ToString(dr["email"]);

            }
            return usuario;
        }
        catch (Exception exception)
        {
            BusinessException businessException = new BusinessException(exception);
            usuario.nombre = "error";
            return usuario;

        }

    }
    /// <summary>
    /// Devuelve una lista de usuarios los cuales tienen cargado username y id_usuario
    /// </summary>
    public List<Usuario> ObtenerUsuariosConID(int id_empresa)
    {
        int categoriaUsuarioComun = 3;
        Ado ad = new Ado();
        DataTable dt = new DataTable();
        List<Usuario> listaDeUsuarios = new List<Usuario>();
        string sSql;
        sSql = "SELECT ";
        sSql = sSql + " [id_Usuario] as id_usuario";
        sSql = sSql + " ,[Usuario] as Usuario ";
        sSql = sSql + " FROM [Basedatos].[dbo].[Usuarios]";
        sSql = sSql + " where id_empresa = " + id_empresa + " and id_categoriausuario = " + categoriaUsuarioComun + " ;";
        dt = ad.EjecutarSelect(sSql);
        foreach (DataRow dr in dt.Rows)
        {
            Usuario usuario1 = new Usuario();
            usuario1.UserName = Convert.ToString(dr["Usuario"]);
            usuario1.id_Usuario = Convert.ToInt32(dr["id_Usuario"]);
            listaDeUsuarios.Add(usuario1);
        }
        return listaDeUsuarios;

    }

    /*
     * Actualizar Usuarios.
     * 
     * SQL SP Script:
     *  CREATE PROCEDURE [dbo].[sp_UsuarioUpdate]
	 *      @ID_Usuario INT,
	 *      @Nombre NVARCHAR(100),
	 *      @Apellido NVARCHAR(100),
	 *      @Documento INT,
	 *      @Direccion NVARCHAR(100),
	 *      @Telefono NVARCHAR(100),
	 *      @Email NVARCHAR(100),
	 *      @Usuario NVARCHAR(100),
     *  AS
     *  BEGIN
	 *      UPDATE [dbo].[Usuarios_Datos]
	 *      SET [Nombre] = @Nombre,
	 *      [Apellido] = @Apellido,
	 *      [Documento] = @Documento,
	 *      [Direccion] = @Direccion,
	 *      [Telefono] = @Telefono,
	 *      [email] = @Email
	 *      WHERE [id_Usuario] = @ID_Usuario
     *
	 *      UPDATE [dbo].[Usuarios]
	 *      SET [Usuario] = @Usuario
	 *      WHERE [id_Usuario] = @ID_Usuario
     *  END
     *  GO
     * 
     */

    public bool Update(Usuario usuario)
    {

        /**/
        AccesoDatos.Ado oAdo = new AccesoDatos.Ado();
        SqlConnection Cnx = oAdo.Conectar();
        if (Cnx.State == ConnectionState.Open)
        {
            int resultadoUpdate = 0;
            string sSql;


            sSql = "exec sp_UsuarioUpdate ";
            sSql += "@ID_Usuario, ";
            sSql += "@Nombre, ";
            sSql += "@Apellido, ";
            sSql += "@Documento, ";
            sSql += "@Direccion, ";
            sSql += "@Telefono, ";
            sSql += "@Email, ";
            sSql += "@Usuario ";
            

            SqlCommand cmd = new SqlCommand(sSql, Cnx);
            

            cmd.Parameters.AddWithValue("@ID_Usuario", usuario.id_Usuario);
            cmd.Parameters.AddWithValue("@Nombre", usuario.nombre);
            cmd.Parameters.AddWithValue("@Apellido", usuario.apellido);
            cmd.Parameters.AddWithValue("@Documento", usuario.documento);
            cmd.Parameters.AddWithValue("@Direccion", usuario.direccion);
            cmd.Parameters.AddWithValue("@Telefono", usuario.telefono);
            cmd.Parameters.AddWithValue("@Email", usuario.email);
            cmd.Parameters.AddWithValue("@Usuario", usuario.UserName);


            if( (resultadoUpdate = cmd.ExecuteNonQuery()) != 0)
            {
                Cnx.Close();
                return (true);
            }
            else
            {
                Cnx.Close();
                return (false);
            }
        }

        /**/

        return(true);
    }

}