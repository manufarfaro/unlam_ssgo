using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Account_Login : System.Web.UI.Page
{

    protected void Page_Load(object sender, EventArgs e)
    {
        RegisterHyperLink.NavigateUrl = "Register.aspx?ReturnUrl=" + HttpUtility.UrlEncode(Request.QueryString["ReturnUrl"]);
    }

    protected void LoginButton_Click(object sender, EventArgs e)
    {

        try
        {
            string usuario = UserName.Text;
            string password = Password.Text;

            Login login = new Login();
            LoginService loginService = new LoginService();
            login = loginService.validarLogin(usuario, password);
            if (login.id_Usuario == -1)
            {
                FailureText.Text = "Usuario o Contraseña incorrectos";
                //Response.Redirect("http://www.google.com");
            }
            else
            {
                if (login.id_Usuario == -2)
                {
                    FailureText.Text = "El usuario no esta habilitado";
                }
                else
                {
                    FailureText.Text = login.UserName;
                    Session["UserName"] = login.UserName;
                    Session["id_Empresa"] = login.id_Empresa;
                    Session["categoria_usuario"] = login.id_CategoriaUsuario;
                    //Session["id_usuario"] = login.Usuario;
                    Session["id_usuario"] = login.id_Usuario;
                    Session["pwd"] = login.Password;
                    Response.Redirect("~/Default.aspx", false);
                }
            }
        }
        catch (Exception exception)
        {
            FailureText.Text = exception.ToString();
            BusinessException businessException = new BusinessException(exception);
            Response.Redirect("~/login.aspx");
        }
    }
}