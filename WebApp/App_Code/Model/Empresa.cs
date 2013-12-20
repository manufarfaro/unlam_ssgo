using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for Empresa
/// </summary>
public class Empresa:Login
{

    int _id;
    string _nombre;
    string _razonSocial;
    string _provincia;
    string _localidad;
    string _direccion;
    string _telefono;
    string _ultimoAcceso;
    string _CUIT;
    public int catidadUsuarios { get; set; }

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

    public string RazonSocial
    {
        get
        {
            return (this._razonSocial);
        }
        set
        {
            this._razonSocial = value;
        }
    }

    public string Provincia
    {
        get
        {
            return (this._provincia);
        }
        set
        {
            this._provincia = value;
        }
    }

    public string Localidad
    {
        get
        {
            return (this._localidad);
        }
        set
        {
            this._localidad = value;
        }
    }

    public string Direccion
    {
        get
        {
            return (this._direccion);
        }
        set
        {
            this._direccion = value;
        }
    }

    public string Telefono
    {
        get
        {
            return (this._telefono);
        }
        set
        {
            this._telefono = value;
        }
    }

    public string UltimoAcceso
    {
        get
        {
            return (this._ultimoAcceso);
        }
        set
        {
            this._ultimoAcceso = value;
        }
    }

    public string CUIT
    {
        get
        {
            return (this._CUIT);
        }
        set
        {
            this._CUIT = value;
        }
    }



	public Empresa()
	{
		//
		// TODO: Add constructor logic here
		//
	}
}