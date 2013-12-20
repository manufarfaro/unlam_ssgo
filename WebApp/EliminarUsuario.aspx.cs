using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Usuarios_EliminarUsuario : System.Web.UI.Page
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
        if (!Page.IsPostBack)
        {
            UsuarioService usuService = new UsuarioService();

            ddlUsuarios.DataValueField = "id_Usuario";
            ddlUsuarios.DataTextField = "UserName";

            ddlUsuarios.DataSource = usuService.ObtenerUsuariosConID((int)Session["id_Empresa"]);
            ddlUsuarios.DataBind();

            this.CargarUsuarios();
        }
    }
    protected void btnEliminarUsuario_Click(object sender, EventArgs e)
    {
        UsuarioService usuServ = new UsuarioService();
        Usuario usuario1 = new Usuario();
        usuario1.id_Usuario = Convert.ToInt32(ddlUsuarios.SelectedValue);
        if (usuServ.eliminar(usuario1))
        {
            if (usuario1.id_Usuario != (int)Session["id_Usuario"])
            {
                txtApellido.Text = "";
                txtDni.Text = "";
                txtNombre.Text = "";

                lblUsuarios.Text = "El usuario se ha eliminado correctamente.";

                this.CargarUsuarios();
            }
            else
            {
                Response.Redirect("~/Logout.aspx");
            }
            
        }
        else
        {
            lblUsuarios.Text = "El usuario no se ha podido eliminar.";
        }



    }

    protected void ddlUsuarios_SelectedIndexChanged(object sender, EventArgs e)
    {
        this.CargarUsuarios();
    }

    public void CargarUsuarios()
    {
        Usuario usuario1 = new Usuario();
        UsuarioService usuServ = new UsuarioService();
        usuario1.id_Usuario = Convert.ToInt16(ddlUsuarios.SelectedValue);
        usuario1 = usuServ.ObtenerDatosUsuario(usuario1);
        txtApellido.Text = usuario1.apellido;
        txtDni.Text = usuario1.documento;
        txtNombre.Text = usuario1.nombre;
    }
}