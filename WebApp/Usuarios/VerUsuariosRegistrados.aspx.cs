using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Usuario_Administracion_VerUsuarios : System.Web.UI.Page
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
        this.CargarUsuarios();
    }
    protected void gvUsuarios_SelectedIndexChanged(object sender, EventArgs e)
    {
        
    }
    protected void gvUsuarios_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        switch (e.CommandName)
        { 
            case "cmdBorrar":

                int index = Convert.ToInt32(e.CommandArgument);
                GridViewRow selectedRow = gvUsuarios.Rows[index];

                int id_Usuario = int.Parse(selectedRow.Cells[0].Text);

                /**/

                UsuarioService usuServ = new UsuarioService();
                Usuario usuario1 = new Usuario();
                usuario1.id_Usuario = id_Usuario;
                if (usuServ.eliminar(usuario1))
                {
                    if (usuario1.id_Usuario != (int)Session["id_Usuario"])
                    {
                        lblUsuario.Text = "El usuario se ha eliminado correctamente.";

                        this.CargarUsuarios();
                    }
                    else
                    {
                        Response.Redirect("~/Logout.aspx");
                    }
            
                }
                else
                {
                    lblUsuario.Text = "El usuario no se ha podido eliminar.";
                }

                /**/

                break;
        }
    }

    public void CargarUsuarios()
    {
        UsuarioService usuarioService = new UsuarioService();

        gvUsuarios.DataSource = usuarioService.GetAllByCompanyId((int)Session["id_Empresa"]);

        gvUsuarios.DataBind();
    }
}