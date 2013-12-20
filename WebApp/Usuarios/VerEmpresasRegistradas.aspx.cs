using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Administrador_Empresas_VerEmpresasRegistradas : System.Web.UI.Page
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
            llenarGvEmpresas(); 
        }
        
    }


    protected void gvEmpresas_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        int index = Convert.ToInt32(e.CommandArgument);
        GridViewRow selectedRow = gvEmpresas.Rows[index];
        Login Emp1 = new Login();
        LoginService ls = new LoginService();
        Emp1.id_Empresa = int.Parse(selectedRow.Cells[0].Text);
        switch (e.CommandName)
        {
            case "btnHabilitar":
                Emp1.Activo = "S";
                ls.ActualizarActivo(Emp1);
                break;
            case "btnDeshabilitar":
                Emp1.Activo = "N";
                ls.ActualizarActivo(Emp1);
                break;
            default:
                break;

        }
        llenarGvEmpresas();
    }
    protected void llenarGvEmpresas()
    {
        EmpresaService empresaService = new EmpresaService();
        gvEmpresas.DataSource = empresaService.ConsultarEmpresas();
        gvEmpresas.DataBind();
    }

}