using System;

public partial class Usuarios_EditarUsuario : System.Web.UI.Page
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
        try
        { 
            if(!Page.IsPostBack)
            {
                int GetId = int.Parse(Request.QueryString["id_Usuario"]);

                this.CargarUsuario(GetId);
            }
           

        }
        catch(Exception exception)
        {
            BusinessException businessException = new BusinessException(exception);
            Response.Redirect("~/Usuarios/VerUsuariosRegistrados.aspx",false);
        }
        
    }
    protected void btnActualizarUsuario_Click(object sender, EventArgs e)
    {
        try
        {
            UsuarioService usuarioService = new UsuarioService();
            Usuario usuario = new Usuario();

            usuario.id_Usuario = int.Parse(Request.QueryString["id_Usuario"]);
            usuario.UserName = txtUserName.Text;
            usuario.nombre = txtNombre.Text;
            usuario.apellido = txtApellido.Text;
            usuario.documento = txtDni.Text;
            usuario.direccion = txtDireccion.Text;
            usuario.email = txtMail.Text;
            usuario.telefono = txtTelefono.Text;

            if(usuarioService.Update(usuario))
            {
                lblUsuario.Text = "Se ha Actualizado la información";
            }
            else
            {
                lblUsuario.Text = "No se ha podido actualizar el usuario.";
                throw new Exception();
            }
        }
        catch(Exception exception)
        {
            BusinessException bussinessException = new BusinessException(exception);
        }
        

    }

    public void CargarUsuario(int id_Usuario)
    {
        UsuarioService usuarioService = new UsuarioService();
        Usuario usuario = new Usuario();
        usuario.id_Usuario = id_Usuario;

        usuario = usuarioService.ObtenerDatosUsuario(usuario);

        txtUserName.Text = usuario.UserName;
        txtNombre.Text = usuario.nombre;
        txtApellido.Text = usuario.apellido;
        txtDni.Text = usuario.documento;
        txtDireccion.Text = usuario.direccion;
        txtMail.Text = usuario.email;
        txtTelefono.Text = usuario.telefono;

    }

}