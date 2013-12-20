using System;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Administracion_VerCategoria : System.Web.UI.Page
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
        if(!Page.IsPostBack)
        {
            this.CargarCategorias();
        }
    }

    protected void btnActualizarDatos_Click(object sender, EventArgs e)
    {
    }
    protected void gvCategorias_SelectedIndexChanged(object sender, EventArgs e)
    {
        
    }

    protected void gvCategorias_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        switch (e.CommandName)
        {
            case "cmdBorrar":

                int index = Convert.ToInt32(e.CommandArgument);
                GridViewRow selectedRow = gvCategorias.Rows[index];

                int id_Categoria = int.Parse(selectedRow.Cells[0].Text);

                CategoriaService categoriaService = new CategoriaService();
                if (categoriaService.delete(id_Categoria))
                {
                    lblCategoria.Text = "La Categoria se ha eliminado Correctamente.";

                    this.CargarCategorias();
                }
                else
                {
                    lblCategoria.Text = "La Categoria se ha podido eliminar.";
                }

                break;
        }
    }

    public void CargarCategorias() 
    { 
        CategoriaService categoraService = new CategoriaService();

        gvCategorias.DataSource = categoraService.getAllByCompanyId((int)Session["id_Empresa"]);
        gvCategorias.DataBind();
    }
}