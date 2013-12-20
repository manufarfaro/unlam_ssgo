using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class SuperUsuario_MiCuenta_EditarCuenta : System.Web.UI.Page
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
        if (!IsPostBack)
        {
            
        
        if ((int)Session["categoria_usuario"] == 2)
        {
            //Empresa
            divRazonSocial.Visible = true;
            divCUIT.Visible = true;
            rfvDocumento.Enabled = false;
            rfvApellido.Enabled = false;
            rfvDocumento.Enabled = false;
            rfvEmail.Enabled = false;

            Empresa empresa1 = new Empresa();
            EmpresaService empService = new EmpresaService();
            empresa1.id_Empresa = (int)Session["id_Empresa"];
            empresa1 = empService.ObtenerDatosUsuario(empresa1);
            txtUserid.Text = Convert.ToString(Session["UserName"]);
            txtLocalidad.Text = empresa1.Localidad;
            txtRazonSocial.Text = empresa1.RazonSocial;
            txtCUIT.Text = empresa1.CUIT;
            txtDireccion.Text = empresa1.Direccion;
            txtTelefono.Text = empresa1.Telefono;
            
            
        }
        if ((int)Session["categoria_usuario"] == 3)
        {
            //Usuario
            divDocumento.Visible = true;
            divApellido.Visible = true;
            divDocumento.Visible = true;
            divEmail.Visible = true;
            rfvRazonSocial.Enabled = false;
            rfvCUIT.Enabled = false;

            Usuario usuario1 = new Usuario();
            UsuarioService usuarioService = new UsuarioService();
            usuario1.id_Usuario = (int)Session["id_usuario"];
            usuario1.id_Empresa = (int)Session["id_Empresa"];
            usuario1 = usuarioService.ObtenerDatosUsuario(usuario1);
            txtUserid.Text = usuario1.nombre;

        }

        }
    }
    protected void btnModificarDatos_Click(object sender, EventArgs e)
    {
        Empresa empresa1 = new Empresa();
        EmpresaService empService = new EmpresaService();
        empresa1.id_Empresa = (int)Session["id_Empresa"];
        empresa1.UserName = Convert.ToString(Session["UserName"]);
        empresa1.Localidad = txtLocalidad.Text;
        empresa1.RazonSocial = txtRazonSocial.Text;
        empresa1.CUIT = txtCUIT.Text;
        empresa1.Direccion = txtDireccion.Text;
        empresa1.Telefono = txtTelefono.Text;
        if (empService.modificarDatos(empresa1))
        {
            lblResultado.Text = "Se modificaron los datos con exito";
        }
        else
        {
            lblResultado.Text = "No se modificaron los datos";
        }
        
    }
}