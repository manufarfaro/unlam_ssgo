using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using AccesoDatos;
public partial class Usuarios_CrearUsuario : System.Web.UI.Page
{

    void Page_PreInit(Object sender, EventArgs e)
    {
        try
        {
            int cat = (int)Session["categoria_usuario"];

            switch (cat)
            {
                case 1:
                    this.MasterPageFile = "~/Administrador.master";
                    break;
                case 2:
                    this.MasterPageFile = "~/Superusuario.master";
                    break;
                case 3:
                    this.MasterPageFile = "~/Usuario.master";
                    break;
                default:
                    Response.Redirect("index.aspx");
                    break;
            }
        }
        catch (Exception exception)
        {
            BusinessException businessException = new BusinessException(exception);
            Response.Redirect("~/login.aspx");
        }


    }

    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void btnCrearUsuario_Click(object sender, EventArgs e)
    {
        Usuario usuario1 = new Usuario();
        usuario1.id_Empresa = (int)Session["id_Empresa"];
        usuario1.id_CategoriaUsuario = 3;
        usuario1.nombre = txtNombre.Text;
        usuario1.email = txtEmail.Text;
        usuario1.telefono = txtTelefono.Text;
        usuario1.apellido = txtApellido.Text;
        usuario1.documento = txtDni.Text;
        usuario1.direccion = txtDireccion.Text;
        usuario1.Password = txtClave.Text;
        usuario1.UserName = txtUserID.Text;

        UsuarioService us = new UsuarioService();
        
        if (us.RegistrarUsuario(usuario1))
        {
            lblSeCreo.Text = "Se creo correctamente el usuario ";
        }
        else
        {
            lblSeCreo.Text = "Error al crear el usuario ";
        }
    }
}