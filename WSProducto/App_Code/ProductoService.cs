using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using AccesoDatos;

/// <summary>
/// Descripción breve de ProductoService
/// </summary>
public class ProductoService
{
	public ProductoService()
	{
		//
		// TODO: Agregar aquí la lógica del constructor
		//
	}

    public List<Producto> getAllByCompanyId(int Company_Id)
    {
        List<Producto> lsProductos = new List<Producto>();

        AccesoDatos.Ado oAdo = new AccesoDatos.Ado();
        SqlConnection Cnx = oAdo.Conectar();
        if (Cnx.State == ConnectionState.Open)
        {
            string sSql;
            sSql = " SELECT [id_Producto]";
            sSql = sSql + " ,[id_Empresa]";
            sSql = sSql + " ,[id_Categoria]";
            sSql = sSql + " ,[Nombre]";
            sSql = sSql + " ,[Cantidad_Minima]";
            sSql = sSql + " ,[Cantidad_Stock]";
            sSql = sSql + " ,[Precio]";
            sSql = sSql + " ,[Marca]";
            sSql = sSql + " ,[Modelo]";
            sSql = sSql + " FROM [Basedatos].[dbo].[Productos]";
            sSql = sSql + " where id_empresa =";
            sSql = sSql + Company_Id;




            SqlCommand cmd = new SqlCommand(sSql, Cnx);
            cmd.Parameters.AddWithValue("@ID_Company", Company_Id);

            SqlDataReader dataReader = cmd.ExecuteReader();

            if (dataReader.HasRows)
            {
                while (dataReader.Read())
                {
                    Producto producto = new Producto();
                    producto.Id_Producto = dataReader.GetInt32(0);
                    producto.Id_Empresa = dataReader.GetInt32(1);
                    producto.Id_Categoria = dataReader.GetInt32(2);
                    producto.Nombre = dataReader.GetString(3);
                    producto.Cantidad_Minima = dataReader.GetInt32(4);
                    producto.Cantidad_Stock = dataReader.GetInt32(5);
                    producto.Precio = dataReader.GetInt32(6);
                    producto.Marca = dataReader.GetString(7);
                    producto.Modelo = dataReader.GetString(8);
                    lsProductos.Add(producto);
                }
            }

            //int t = Convert.ToInt32(cmd.ExecuteScalar());
            Cnx.Close();
        }

        return (lsProductos);
    }
}