using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using AccesoDatos;

/// <summary>
/// Summary description for Class1
/// </summary>
public class ProductoService
{
    public ProductoService()
    {

    }

    public List<Producto> getAll()
    {
        List<Producto> lsProductos = new List<Producto>();

        AccesoDatos.Ado oAdo = new AccesoDatos.Ado();
        SqlConnection Cnx = oAdo.Conectar();
        if (Cnx.State == ConnectionState.Open)
        {
            string sSql;
            sSql = "exec sp_ProductosGetAll";

            SqlCommand cmd = new SqlCommand(sSql, Cnx);
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

    /**/

    public List<Producto> getAllByCompanyId(int Company_Id)
    {
        
        wsProducto.WebService ows = new wsProducto.WebService();
        
        List<Producto> lsProductos = new List<Producto>();
        wsProducto.Producto[] arrayDeProd = ows.ObtenerListaDeProductos(Company_Id);
        foreach (wsProducto.Producto prows in arrayDeProd)
        {
            Producto producto = new Producto();
            producto.Id_Producto = prows.Id_Producto;
            producto.Id_Empresa = prows.Id_Empresa;
            producto.Id_Categoria = prows.Id_Categoria;
            producto.Nombre = prows.Nombre;
            producto.Cantidad_Minima = prows.Cantidad_Minima;
            producto.Cantidad_Stock = prows.Cantidad_Stock;
            producto.Precio = prows.Precio;
            producto.Marca = prows.Marca;
            producto.Modelo = prows.Modelo;
            lsProductos.Add(producto);
        }
        
        return (lsProductos);
        //AccesoDatos.Ado oAdo = new AccesoDatos.Ado();
        //SqlConnection Cnx = oAdo.Conectar();
        //if (Cnx.State == ConnectionState.Open)
        //{
        //    string sSql;
        //    sSql = " SELECT [id_Producto]";
        //    sSql = sSql + " ,[id_Empresa]";
        //    sSql = sSql + " ,[id_Categoria]";
        //    sSql = sSql + " ,[Nombre]";
        //    sSql = sSql + " ,[Cantidad_Minima]";
        //    sSql = sSql + " ,[Cantidad_Stock]";
        //    sSql = sSql + " ,[Precio]";
        //    sSql = sSql + " ,[Marca]";
        //    sSql = sSql + " ,[Modelo]";
        //    sSql = sSql + " FROM [Basedatos].[dbo].[Productos]";
        //    sSql = sSql + " where id_empresa =";
        //    sSql = sSql + Company_Id;




        //    SqlCommand cmd = new SqlCommand(sSql, Cnx);
        //    cmd.Parameters.AddWithValue("@ID_Company", Company_Id);

        //    SqlDataReader dataReader = cmd.ExecuteReader();

        //    if (dataReader.HasRows)
        //    {
        //        while (dataReader.Read())
        //        {
        //            Producto producto = new Producto();
        //            producto.Id_Producto = dataReader.GetInt32(0);
        //            producto.Id_Empresa = dataReader.GetInt32(1);
        //            producto.Id_Categoria = dataReader.GetInt32(2);
        //            producto.Nombre = dataReader.GetString(3);
        //            producto.Cantidad_Minima = dataReader.GetInt32(4);
        //            producto.Cantidad_Stock = dataReader.GetInt32(5);
        //            producto.Precio = dataReader.GetInt32(6);
        //            producto.Marca = dataReader.GetString(7);
        //            producto.Modelo = dataReader.GetString(8);
        //            lsProductos.Add(producto);
        //        }
        //    }

        //    //int t = Convert.ToInt32(cmd.ExecuteScalar());
        //    Cnx.Close();
        //}

        //return (lsProductos);
    }

    /**/

    public List<Producto> getByCategoryId(int id_Categoria)
    {
        List<Producto> lsProductos = new List<Producto>();

        AccesoDatos.Ado oAdo = new AccesoDatos.Ado();
        SqlConnection Cnx = oAdo.Conectar();
        if (Cnx.State == ConnectionState.Open)
        {
            string sSql;
            sSql = "exec sp_ProductosGetByCategoryId @ID_Categoria";

            SqlCommand cmd = new SqlCommand(sSql, Cnx);
            cmd.Parameters.AddWithValue("@ID_Categoria", id_Categoria);
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

    public Producto getById(int id_Producto)
    {
        Producto producto = new Producto();

        AccesoDatos.Ado oAdo = new AccesoDatos.Ado();
        SqlConnection Cnx = oAdo.Conectar();
        if (Cnx.State == ConnectionState.Open)
        {
            string sSql;
            sSql = "exec sp_ProductosGetById @ID_Producto";

            SqlCommand cmd = new SqlCommand(sSql, Cnx);
            cmd.Parameters.AddWithValue("@ID_Producto", id_Producto);
            SqlDataReader dataReader = cmd.ExecuteReader();

            if (dataReader.HasRows)
            {
                while (dataReader.Read())
                {
                    producto.Id_Producto = dataReader.GetInt32(0);
                    producto.Id_Empresa = dataReader.GetInt32(1);
                    producto.Id_Categoria = dataReader.GetInt32(2);
                    producto.Nombre = dataReader.GetString(3);
                    producto.Cantidad_Minima = dataReader.GetInt32(4);
                    producto.Cantidad_Stock = dataReader.GetInt32(5);
                    producto.Precio = dataReader.GetInt32(6);
                    producto.Marca = dataReader.GetString(7);
                    producto.Modelo = dataReader.GetString(8);
                }
            }

            //int t = Convert.ToInt32(cmd.ExecuteScalar());
            Cnx.Close();
        }

        return (producto);
    }

    public bool insert(Producto prod)
    {
        try
        {
            AccesoDatos.Ado oAdo = new AccesoDatos.Ado();
            SqlConnection Cnx = oAdo.Conectar();
            if (Cnx.State == ConnectionState.Open)
            {
                string sSql;
                sSql = " INSERT INTO [Basedatos].[dbo].[Productos] ";
                sSql = sSql + " ([id_Empresa] ";
                sSql = sSql + " ,[id_Categoria] ";
                sSql = sSql + " ,[Nombre] ";
                sSql = sSql + " ,[Cantidad_Minima] ";
                sSql = sSql + " ,[Cantidad_Stock] ";
                sSql = sSql + " ,[Precio] ";
                sSql = sSql + " ,[Marca] ";
                sSql = sSql + " ,[Modelo]) ";
                sSql = sSql + " VALUES ";
                sSql = sSql + " ( @id_Empresa , ";
                sSql = sSql + " @id_Categoria , ";
                sSql = sSql + " @Nombre , ";
                sSql = sSql + " @Cantidad_Minima , ";
                sSql = sSql + " @Cantidad_Stock , ";
                sSql = sSql + " @Precio, ";
                sSql = sSql + " @Marca , ";
                sSql = sSql + " @Modelo ); ";

                DataTable dt = new DataTable();
                SqlCommand cmd = new SqlCommand(sSql, Cnx);

                cmd.Parameters.AddWithValue("@id_Empresa", prod.Id_Empresa);
                cmd.Parameters.AddWithValue("@id_Categoria", prod.Id_Categoria);
                cmd.Parameters.AddWithValue("@Nombre", prod.Nombre);
                cmd.Parameters.AddWithValue("@Cantidad_Minima", prod.Cantidad_Minima);
                cmd.Parameters.AddWithValue("@Cantidad_Stock", prod.Cantidad_Stock);
                cmd.Parameters.AddWithValue("@Precio", prod.Precio);
                cmd.Parameters.AddWithValue("@Marca", prod.Marca);
                cmd.Parameters.AddWithValue("@Modelo", prod.Modelo);

                int t = Convert.ToInt32(cmd.ExecuteScalar());
                Cnx.Close();
                return true;

            }
            else
            {
                return false;
            }
        }
        catch (Exception exception)
        {
            BusinessException businessException = new BusinessException(exception);
            return false;
        }

    }
    public bool eliminarProducto(Producto prod1)
    {
        try
        {
            AccesoDatos.Ado oAdo = new AccesoDatos.Ado();
            SqlConnection Cnx = oAdo.Conectar();
            if (Cnx.State == ConnectionState.Open)
            {
                string sSql;
                sSql = " delete from [Basedatos].[dbo].[Productos] ";
                sSql = sSql + " where ";
                sSql = sSql + " id_producto = ";
                sSql = sSql + " @id_Producto ; ";

                DataTable dt = new DataTable();
                SqlCommand cmd = new SqlCommand(sSql, Cnx);

                cmd.Parameters.AddWithValue("@id_Producto", prod1.Id_Producto);
                

                int t = Convert.ToInt32(cmd.ExecuteNonQuery());
                Cnx.Close();
                return true;

            }
            else
            {
                return false;
            }
        }
        catch (Exception exception)
        {
            BusinessException businessException = new BusinessException(exception);
            return false;
        }
    }
    public bool editarStock(Producto prod1)
    {
        Ado ad = new Ado();
        SqlConnection cnx = ad.Conectar();

        string sSql = " UPDATE [Basedatos].[dbo].[Productos]";
        sSql = sSql + " SET [Cantidad_Stock] ='";
        sSql = sSql + prod1.Cantidad_Stock;
        sSql = sSql + "' ";
        sSql = sSql + " WHERE ";
        sSql = sSql + " id_Producto = '" + prod1.Id_Producto + "';";

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

    /*
     * SQL SP Script:
        CREATE PROCEDURE sp_ProductosUpdate
        @id_Producto INT,
        @id_Categoria INT,
        @id_Empresa INT,
        @Nombre NVARCHAR(50),
        @Cantidad_Minima INT,
        @Cantidad_Stock INT,
        @Precio INT,
        @Marca NVARCHAR(50),
        @Modelo NVARCHAR(50)
        AS
        BEGIN
	        UPDATE [dbo].[Productos]
	        SET [id_Categoria] = @id_Categoria,
		        [id_Empresa] = @id_Empresa,
		        [Nombre] = @Nombre,
		        [Cantidad_Minima] = @Cantidad_Minima,
		        [Cantidad_Stock] = @Cantidad_Stock,
		        [Precio] = @Precio,
		        [Marca] = @Marca,
		        [Modelo] = @Modelo
	        WHERE [id_Producto] = @id_Producto
        END

     
     */

    public bool Update(Producto producto)
    {
        try
        {
            AccesoDatos.Ado oAdo = new AccesoDatos.Ado();
            SqlConnection Cnx = oAdo.Conectar();
            if (Cnx.State == ConnectionState.Open)
            {
                string sSql;

                sSql = " EXEC sp_ProductosUpdate ";
                sSql = sSql + " @id_Producto, ";
                sSql = sSql + " @id_Categoria, ";
                sSql = sSql + " @id_Empresa, ";
                sSql = sSql + " @Nombre, ";
                sSql = sSql + " @Cantidad_Minima, ";
                sSql = sSql + " @Cantidad_Stock, ";
                sSql = sSql + " @Precio, ";
                sSql = sSql + " @Marca , ";
                sSql = sSql + " @Modelo ";

                SqlCommand cmd = new SqlCommand(sSql, Cnx);

                cmd.Parameters.AddWithValue("@id_Empresa", producto.Id_Empresa);
                cmd.Parameters.AddWithValue("@id_Categoria", producto.Id_Categoria);
                cmd.Parameters.AddWithValue("@id_Producto", producto.Id_Producto);
                cmd.Parameters.AddWithValue("@Nombre", producto.Nombre);
                cmd.Parameters.AddWithValue("@Cantidad_Minima", producto.Cantidad_Minima);
                cmd.Parameters.AddWithValue("@Cantidad_Stock", producto.Cantidad_Stock);
                cmd.Parameters.AddWithValue("@Precio", producto.Precio);
                cmd.Parameters.AddWithValue("@Marca", producto.Marca);
                cmd.Parameters.AddWithValue("@Modelo", producto.Modelo);

                cmd.ExecuteNonQuery();
                Cnx.Close();

                return true;

            }
            else
            {
                return false;
            }
        }
        catch (Exception exception)
        {
            BusinessException businessException = new BusinessException(exception);
            return false;
        }
    }

    /*
     *  UpdateStockById
     * 
     * SQL SP Script:
        CREATE PROCEDURE sp_ProductosUpdateStockById
        @ID_Producto INT,
        @QtyStock INT
        AS
        BEGIN

	        UPDATE [dbo].[Productos]
	        SET [Cantidad_Stock] = @QtyStock
	        WHERE [id_Producto] = @ID_Producto

        END
     */

    public bool UpdateStockById(int id_Producto, int Stock)
    {
        try
        {
            AccesoDatos.Ado oAdo = new AccesoDatos.Ado();
            SqlConnection Cnx = oAdo.Conectar();
            if (Cnx.State == ConnectionState.Open)
            {
                string sSql;

                sSql = " EXEC sp_ProductosUpdateStockById ";
                sSql = sSql + " @id_Producto, ";
                sSql = sSql + " @QtyStock ";

                SqlCommand cmd = new SqlCommand(sSql, Cnx);

                cmd.Parameters.AddWithValue("@id_Producto", id_Producto);
                cmd.Parameters.AddWithValue("@QtyStock", Stock);

                cmd.ExecuteNonQuery();
                Cnx.Close();

                return (true);

            }
            else
            {
                return (false);
            }
        }
        catch (Exception exception)
        {
            BusinessException businessException = new BusinessException(exception);
            return (false);
        }
    }

}