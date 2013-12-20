using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;

/// <summary>
/// Summary description for CategoriaService
/// </summary>
public class CategoriaService
{
    public CategoriaService()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    /*
     * Obtiene todas las categorias de una empresa especifica.
     *
     * SQL SP Creation Script:
     * 
     *  CREATE PROCEDURE [dbo].[sp_CategoriasGetByCompanyId]
     *  @ID_Empresa INT
     *  AS
     *  BEGIN
     *
	 *      SELECT id_Empresa, id_Categoria, Codigo, Nombre, Descripcion
	 *      FROM [Basedatos].[dbo].[Categorias] 
	 *      WHERE id_Empresa = @ID_Empresa
	 *	
     *  END
     *  GO
     */

    public List<Categoria> getAllByCompanyId(int id_company)
    {
        List<Categoria> lsCategorias = new List<Categoria>();

        AccesoDatos.Ado oAdo = new AccesoDatos.Ado();
        SqlConnection Cnx = oAdo.Conectar();
        if (Cnx.State == ConnectionState.Open)
        {
            string sSql;
            sSql = "exec sp_CategoriasGetByCompanyId @Company_Id";

            SqlCommand cmd = new SqlCommand(sSql, Cnx);
            cmd.Parameters.AddWithValue("@Company_Id",id_company);

            SqlDataReader dataReader = cmd.ExecuteReader();

            if (dataReader.HasRows)
            {
                while (dataReader.Read())
                {
                    Categoria categoria = new Categoria();

                    categoria.ID_Empresa = id_company;
                    categoria.id_Categoria = dataReader.GetInt32(1);
                    categoria.Codigo = dataReader.GetString(2);
                    categoria.Nombre = dataReader.GetString(3);
                    categoria.Descripcion = dataReader.GetString(4);
                    lsCategorias.Add(categoria);
                }
            }

            //int t = Convert.ToInt32(cmd.ExecuteScalar());
            Cnx.Close();
        }

        return (lsCategorias);
    }

    public List<Categoria> getAll()
    {
        List<Categoria> lsCategorias = new List<Categoria>();

        AccesoDatos.Ado oAdo = new AccesoDatos.Ado();
        SqlConnection Cnx = oAdo.Conectar();
        if (Cnx.State == ConnectionState.Open)
        {
            string sSql;
            sSql = "exec sp_CategoriasGetAll";

            SqlCommand cmd = new SqlCommand(sSql, Cnx);
            SqlDataReader dataReader = cmd.ExecuteReader();

            if (dataReader.HasRows)
            {
                while (dataReader.Read())
                {
                    Categoria categoria = new Categoria();

                    if (dataReader.IsDBNull(0))
                    {
                        categoria.ID_Empresa = dataReader.GetInt32(0);
                    }
                    categoria.id_Categoria = dataReader.GetInt32(1);
                    categoria.Codigo = dataReader.GetString(2);
                    categoria.Nombre = dataReader.GetString(3);
                    categoria.Descripcion = dataReader.GetString(4);
                    lsCategorias.Add(categoria);
                }
            }

            //int t = Convert.ToInt32(cmd.ExecuteScalar());
            Cnx.Close();
        }

        return (lsCategorias);
    }

    public Categoria getById(Int32 id_Categoria)
    {
        AccesoDatos.Ado oAdo = new AccesoDatos.Ado();
        SqlConnection Cnx = oAdo.Conectar();

        Categoria categoria = new Categoria();

        if (Cnx.State == ConnectionState.Open)
        {
            string sSql;
            sSql = "exec sp_CategoriasGetById @id_Categoria";

            SqlCommand cmd = new SqlCommand(sSql, Cnx);
            cmd.Parameters.AddWithValue("@id_Categoria", id_Categoria);

            SqlDataReader dataReader = cmd.ExecuteReader();

            if (dataReader.HasRows)
            {
                while (dataReader.Read())
                {

                    categoria.id_Categoria = dataReader.GetInt32(0);
                    categoria.ID_Empresa = dataReader.GetInt32(1);
                    categoria.Codigo = dataReader.GetString(2);
                    categoria.Nombre = dataReader.GetString(3);
                    categoria.Descripcion = dataReader.GetString(4);

                }
            }

            Cnx.Close();
        }
        return (categoria);
    }

    public bool insert(Categoria cat)
    {

        if (String.IsNullOrEmpty(cat.Codigo))
        {

        }

        AccesoDatos.Ado oAdo = new AccesoDatos.Ado();
        SqlConnection Cnx = oAdo.Conectar();
        if (Cnx.State == ConnectionState.Open)
        {
            string sSql;
            sSql = "exec sp_CategoriasAdd @Nombre, @ID_Empresa, @Codigo, @Descripcion";
            DataTable dt = new DataTable();
            SqlCommand cmd = new SqlCommand(sSql, Cnx);
            cmd.Parameters.AddWithValue("@Nombre", cat.Nombre);
            cmd.Parameters.AddWithValue("@ID_Empresa", cat.ID_Empresa);
            cmd.Parameters.AddWithValue("@Codigo", cat.Codigo);
            cmd.Parameters.AddWithValue("@Descripcion", cat.Descripcion);

            int t = Convert.ToInt32(cmd.ExecuteScalar());
            Cnx.Close();
            return true;

        }
        else
        {
            return false;
        }

    }

    public bool update(Categoria cat)
    {
        AccesoDatos.Ado oAdo = new AccesoDatos.Ado();
        SqlConnection Cnx = oAdo.Conectar();
        if (Cnx.State == ConnectionState.Open)
        {
            string sSql;
            sSql = "exec sp_CategoriasUpdate @ID_Categoria, @Nombre, @ID_Empresa, @Codigo, @Descripcion";

            DataTable dt = new DataTable();
            SqlCommand cmd = new SqlCommand(sSql, Cnx);
            cmd.Parameters.AddWithValue("@ID_Categoria", cat.id_Categoria);
            cmd.Parameters.AddWithValue("@Nombre", cat.Nombre);
            cmd.Parameters.AddWithValue("@ID_Empresa", cat.ID_Empresa);
            cmd.Parameters.AddWithValue("@Codigo", cat.Codigo);
            cmd.Parameters.AddWithValue("@Descripcion", cat.Descripcion);

            int t = Convert.ToInt32(cmd.ExecuteScalar());
            Cnx.Close();
            return true;
        }
        else
        {
            return false;
        }

    }

    public bool delete(int id_Categoria)
    {
        AccesoDatos.Ado oAdo = new AccesoDatos.Ado();
        SqlConnection Cnx = oAdo.Conectar();
        if (Cnx.State == ConnectionState.Open)
        {
            string sSql;
            sSql = "exec sp_CategoriasDelete @ID_Categoria";

            SqlCommand cmd = new SqlCommand(sSql, Cnx);
            cmd.Parameters.AddWithValue("@ID_Categoria", id_Categoria);

            int t = Convert.ToInt32(cmd.ExecuteScalar());
            Cnx.Close();
            return true;
        }
        else
        {
            return false;
        }

    }

}