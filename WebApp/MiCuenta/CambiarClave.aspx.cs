using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class SuperUsuario_MiCuenta_CambiarClave : System.Web.UI.Page
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
    protected void btnModificarClave_Click(object sender, EventArgs e)
    {
        Login lg = new Login();
        LoginService lgs = new LoginService();
        lg.id_Usuario = Convert.ToInt16(Session["id_usuario"]);
        lg.Password = txtClaveActual.Text;
        lg.UserName = Convert.ToString(Session["UserName"]);
        lg = lgs.validarLogin(lg.UserName, lg.Password);
        if (lg.id_Usuario == -1)
        {
            lblResultado.Text = "La clave actual no es correcta";
        }
        else
        {
            lg.Password = txtClave1.Text;
            if (lgs.ModificarPassword(lg))
            {
                lblResultado.Text = "Se cambio la clave con exito";
            }
            else
            {
                lblResultado.Text = "La clave no pudo ser modificada";
            }

        }
        
    }
}