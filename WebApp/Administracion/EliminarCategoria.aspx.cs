using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class EliminarCategoria : System.Web.UI.Page
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
            CargarCategorias();
        }
    }
    protected void btnEliminarCategoria_Click(object sender, EventArgs e)
    {
        //int categoriaSelec = int.Parse(ddlCategoria.SelectedItem.Value);
        int categoriaSelec = int.Parse(ddlCategoria.SelectedValue);
        CategoriaService categoriaService = new CategoriaService();

        categoriaService.delete(categoriaSelec);


        CargarCategorias();
    }

    private void CargarCategorias()
    {
        CategoriaService categoriaService = new CategoriaService();

        ddlCategoria.DataValueField = "id_Categoria";
        ddlCategoria.DataTextField = "Nombre";

        ddlCategoria.DataSource = categoriaService.getAllByCompanyId((int)Session["id_Empresa"]);
        ddlCategoria.DataBind();
    }
}