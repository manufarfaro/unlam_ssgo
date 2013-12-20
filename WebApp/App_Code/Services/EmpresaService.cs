using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using AccesoDatos;
/// <summary>
/// Summary description for EmpresaService
/// </summary>
public class EmpresaService : LoginService
{
    public EmpresaService()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    public List<Empresa> getAll()
    {
        List<Empresa> lsEmpresas = new List<Empresa>();

        AccesoDatos.Ado oAdo = new AccesoDatos.Ado();
        SqlConnection Cnx = oAdo.Conectar();
        if (Cnx.State == ConnectionState.Open)
        {
            string sSql;
            sSql = "exec sp_EmpresasGetAll";

            SqlCommand cmd = new SqlCommand(sSql, Cnx);
            SqlDataReader dataReader = cmd.ExecuteReader();

            if (dataReader.HasRows)
            {
                while (dataReader.Read())
                {
                    Empresa empresa = new Empresa();

                    if (dataReader.IsDBNull(0))
                    {
                        empresa.Id = dataReader.GetInt32(0);
                    }
                    if (dataReader.IsDBNull(1))
                    {
                        empresa.Nombre = dataReader.GetString(1);
                    }
                    if (dataReader.IsDBNull(2))
                    {
                        empresa.RazonSocial = dataReader.GetString(2);
                    }
                    if (dataReader.IsDBNull(3))
                    {
                        empresa.Provincia = dataReader.GetString(3);
                    }
                    if (dataReader.IsDBNull(4))
                    {
                        empresa.Localidad = dataReader.GetString(4);
                    }
                    if (dataReader.IsDBNull(5))
                    {
                        empresa.Direccion = dataReader.GetString(5);
                    }

                    lsEmpresas.Add(empresa);
                }
            }

            //int t = Convert.ToInt32(cmd.ExecuteScalar());
            Cnx.Close();
        }

        return (lsEmpresas);
    }

    public List<Empresa> ConsultarEmpresas()
    {
        List<Empresa> lsEmpresas = new List<Empresa>();
        string sSql = "";
        AccesoDatos.Ado oAdo = new AccesoDatos.Ado();
        DataTable dt = new DataTable();
        sSql = " SELECT distinct u.[id_Empresa] as id_Empresa ";
        sSql = sSql + " ,[RazonSocial] as RazonSocial ";
        sSql = sSql + " ,[Direccion] as Direccion ";
        sSql = sSql + " ,[CUIT] as CUIT  ";
        sSql = sSql + " ,[Telefono] as Telefono ";
        sSql = sSql + " ,u.[Activo] as Activo ";
        sSql = sSql + " FROM [Basedatos].[dbo].[Usuarios] u join [Basedatos].[dbo].[Empresas_Datos] e ";
        sSql = sSql + " on u.id_Empresa = e.id_Empresa ";
        sSql = sSql + ";";
        dt = oAdo.EjecutarSelect(sSql);
        if (dt.Rows.Count > 0)
        {
            foreach (DataRow dr in dt.Rows)
            {
                Empresa emp = new Empresa();
                emp.id_Empresa = Convert.ToInt32(dr["id_Empresa"]);
                emp.RazonSocial = Convert.ToString(dr["RazonSocial"]);
                emp.Direccion = Convert.ToString(dr["Direccion"]);
                emp.CUIT = Convert.ToString(dr["CUIT"]);
                emp.Telefono = Convert.ToString(dr["Telefono"]);
                emp.Activo = Convert.ToString(dr["Activo"]);
                lsEmpresas.Add(emp);
            }
        }
                return (lsEmpresas);
    }
    public bool RegistrarUsuario(Empresa empresa1)
    {
        Ado ad = new Ado();
        SqlConnection cnx = ad.Conectar();

        empresa1.id_CategoriaUsuario = 2;

        //Insertamos en Empresa_Datos
        string SqlString = " insert into [Basedatos].[dbo].[Empresas_Datos] ( ";
        SqlString = SqlString + " [RazonSocial] ";
        SqlString = SqlString + " ,[Direccion] ";
        SqlString = SqlString + " ,[CUIT] ";
        SqlString = SqlString + " ,[Telefono] ";
        SqlString = SqlString + " ,[Activo]) ";
        SqlString = SqlString + " values (@RazonSocial,@Direccion,@CUIT,@Telefono,@Activo); ";

        SqlCommand cmd = new SqlCommand(SqlString, cnx);

        cmd.CommandType = CommandType.Text;
        //cmd.Parameters.AddWithValue("@id_Empresa", empresa1.id_Empresa);
        cmd.Parameters.AddWithValue("@RazonSocial", empresa1.RazonSocial);
        cmd.Parameters.AddWithValue("@Direccion", empresa1.Direccion);
        cmd.Parameters.AddWithValue("@CUIT", empresa1.CUIT);
        cmd.Parameters.AddWithValue("@Telefono", empresa1.Telefono);
        cmd.Parameters.AddWithValue("@Activo", "N");

        int resultadoInsert1 = cmd.ExecuteNonQuery();

        empresa1.id_Empresa = base.consultarIdEmpresa(empresa1.RazonSocial);
        //empresa1.id_Usuario = empresa1.id_Empresa;

        cnx.Close();
        if (resultadoInsert1 > 0 && base.insertEnUsuarios(empresa1))
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public Empresa ObtenerDatosUsuario(Empresa emp)
    {
        Ado ad = new Ado();
        DataTable dt = new DataTable();
        try
        {


            string sSql;
            sSql = "SELECT TOP 1000 [id_Empresa]";
            sSql = sSql + "  ,[RazonSocial]";
            sSql = sSql + " ,[Direccion]";
            sSql = sSql + " ,[CUIT]";
            sSql = sSql + " ,[Telefono]";
            sSql = sSql + " FROM [Basedatos].[dbo].[Empresas_Datos] ";
            sSql = sSql + " where [id_Empresa] =";
            sSql = sSql + emp.id_Empresa;

            dt = ad.EjecutarSelect(sSql);
            foreach (DataRow dr in dt.Rows)
            {
                emp.RazonSocial = (string)dr["RazonSocial"];
                emp.Direccion = (string)dr["Direccion"];
                emp.CUIT = (string)dr["CUIT"];
                emp.Telefono = (string)dr["Telefono"];

            }
            return emp;
        }
        catch (Exception exception)
        {
            BusinessException businessException = new BusinessException(exception);
            emp.RazonSocial = "error";
            return emp;
        }

    }
    public bool modificarDatos(Empresa empresa1)
    {

        Ado ad = new Ado();
        SqlConnection cnx = ad.Conectar();

        empresa1.id_CategoriaUsuario = 2;

        //Insertamos en Empresa_Datos

        string SqlString = " UPDATE [Basedatos].[dbo].[Empresas_Datos]";
        SqlString = SqlString + " SET [RazonSocial] = @RazonSocial";
        SqlString = SqlString + " ,[Direccion] = @Direccion";
        SqlString = SqlString + " ,[CUIT] = @CUIT";
        SqlString = SqlString + " ,[Telefono] = @Telefono";
        SqlString = SqlString + " WHERE id_Empresa = @id_Empresa";


        SqlCommand cmd = new SqlCommand(SqlString, cnx);

        cmd.CommandType = CommandType.Text;
        //cmd.Parameters.AddWithValue("@id_Empresa", empresa1.id_Empresa);
        cmd.Parameters.AddWithValue("@RazonSocial", empresa1.RazonSocial);
        cmd.Parameters.AddWithValue("@Direccion", empresa1.Direccion);
        cmd.Parameters.AddWithValue("@CUIT", empresa1.CUIT);
        cmd.Parameters.AddWithValue("@Telefono", empresa1.Telefono);
        cmd.Parameters.AddWithValue("@id_Empresa", empresa1.id_Empresa);

        int resultadoUpdate = cmd.ExecuteNonQuery();
        if (resultadoUpdate > 0)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}