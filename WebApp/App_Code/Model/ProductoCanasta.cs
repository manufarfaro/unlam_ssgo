using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Clase encargada de Abstraer la Canasta de Productos usada en la venta de los mismos.
/// </summary>
public class ProductoCanasta
{
    public int _id;
    public string _nombre;
    public int _cantidad;
    public string _marca;
    public double _precio;

    public int Id
    {
        get
        {
            return (this._id);
        }
        set
        {
            this._id = value;
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

    public int Cantidad
    {
        get
        {
            return (this._cantidad);
        }
        set
        {
            this._cantidad = value;
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

    public ProductoCanasta()
	{
		//
		// TODO: Add constructor logic here
		//
	}
}