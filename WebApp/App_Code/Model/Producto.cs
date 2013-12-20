using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


public class Producto
{
    int _id_Producto;
    int _id_Empresa;
    int _id_Categoria;
    string _nombre;
    int _cantidad_minima;
    int _cantidad_stock;
    double _precio;
    string _marca;
    string _modelo;

    public int Id_Producto
    {
        get
        {
            return (this._id_Producto);
        }
        set
        {
            this._id_Producto = value;
        }
    }

    public int Id_Empresa
    {
        get
        {
            return (this._id_Empresa);
        }
        set
        {
            this._id_Empresa = value;
        }
    }

    public int Id_Categoria
    {
        get
        {
            return (this._id_Categoria);
        }
        set
        {
            this._id_Categoria = value;
        }
    }

    public string Nombre 
    {
        get
        {
            return (this._nombre);
        }
        set
        {
            this._nombre = value;
        }
    }

    public int Cantidad_Minima
    {
        get
        {
            return (this._cantidad_minima);
        }
        set
        {
            this._cantidad_minima = value;
        }
    }

    public int Cantidad_Stock
    {
        get
        {
            return (this._cantidad_stock);
        }
        set
        {
            this._cantidad_stock = value;
        }
    }

    public double Precio
    {
        get
        {
            return (this._precio);
        }
        set
        {
            this._precio = value;
        }
    }

    public string Marca
    {
        get
        {
            return (this._marca);
        }
        set
        {
            this._marca = value;
        }
    }

    public string Modelo
    {
        get
        {
            return (this._modelo);
        }
        set
        {
            this._modelo = value;
        }
    }

	public Producto()
	{
		
	}
}