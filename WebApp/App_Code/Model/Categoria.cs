using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for Categoria
/// </summary>
public class Categoria
{

    public int id_Categoria { get; set; }
    public string Nombre { get; set; }
    public string Codigo { get; set; }
    public string Descripcion { get; set; }
    public int ID_Empresa { get; set; }
    public Categoria()
	{

	}
}