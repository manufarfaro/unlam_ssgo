using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using AccesoDatos;

public partial class Account_Register : System.Web.UI.Page
{

    void Page_PreInit(Object sender, EventArgs e)
    {
        this.MasterPageFile = "~/Anonimo.master";
        //try
        //{
        //    int cat = (int)Session["categoria_usuario"];
        //    switch (cat)
        //    {
        //        case 1:
        //            this.MasterPageFile = "~/Administrador.master";
        //            break;
        //        default:
        //            this.MasterPageFile = "~/Anonimo.master";
        //            break;
        //    }
        //}
        //catch (Exception exception)
        //{
        //    BusinessException businessException = new BusinessException(exception);
        //    Response.Redirect("~/login.aspx");
        //}
     }
    protected void Page_Load(object sender, EventArgs e)
    {
        
    }

    protected void CreateUserButton_Click(object sender, EventArgs e)
    {
        Empresa empresa1 = new Empresa();
        empresa1.RazonSocial = txtRazonSocial.Text;
        empresa1.Telefono = txtTelefono.Text;
        empresa1.CUIT = txtCUIT.Text;
        empresa1.Direccion = txtDireccion.Text;
        empresa1.Password = txtPassword.Text;
        empresa1.UserName = txtUsuario.Text;
        
        EmpresaService es = new EmpresaService();

        if (es.ConsultarUserIdExistente(empresa1))
        {
            lblSeCreo.Text = "El usuario ya existe.";
        }
        else
        {
            if (es.RegistrarUsuario(empresa1))
            {
                lblSeCreo.Text = "Se creo correctamente el usuario ";
            }
            else
            {
                lblSeCreo.Text = "Error al crear el usuario ";
            }
        }
        
    }
}
