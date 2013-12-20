using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Descripción breve de Login
/// </summary>
public class Login
{
    public int id_Usuario { get; set; }
    public string UserName { get; set; }
    public string Password { get; set; }
    public int id_CategoriaUsuario { get; set; }
    public int id_Empresa { get; set; }
    public string Activo { get; set; }

    public Login(){}

}