using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for Usuario
/// </summary>
public class Usuario : Login
{

    public string nombre { get; set; }
    public string apellido { get; set; }
    public string email { get; set; }
    public string documento { get; set; }
    public string telefono { get; set; }
    public string direccion { get; set; }

    public Usuario()
	{
		//
		// TODO: Add constructor logic here
		//
	}
}