using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Administracion_EditarStock : System.Web.UI.Page
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

    protected void ddlCategoria_SelectedIndexChanged(object sender, EventArgs e)
    {


    }

    private void CargarCategorias()
    {
        CategoriaService categoriaService = new CategoriaService();

        ddlCategoria.DataValueField = "id_Categoria";
        ddlCategoria.DataTextField = "Nombre";

        ddlCategoria.DataSource = categoriaService.getAll();
        ddlCategoria.DataBind();
    }

    private void CargarProductoPorCategoria(int id_categoria)
    {
        ProductoService productoService = new ProductoService();

        ddlProducto.DataValueField = "id_Producto";
        ddlProducto.DataTextField = "Nombre";

        ddlProducto.DataSource = productoService.getByCategoryId(id_categoria);
        ddlProducto.DataBind();
    }

    protected void btnFiltrar_Click(object sender, EventArgs e)
    {
        int categoriaSelec = int.Parse(ddlCategoria.SelectedValue);

        CargarProductoPorCategoria(categoriaSelec);
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        ProductoService prodService = new ProductoService();
        Producto prod1 = new Producto();

        prod1.Cantidad_Stock = Convert.ToInt16(txtQtyProducto.Text);
        prod1.Id_Producto = Convert.ToInt16(ddlProducto.SelectedValue);
        if (prodService.editarStock(prod1))
        {
            lblResultado.Text = "Se modifico el stock con exito";
            txtQtyProducto.Text = "";
        }
        else
        {
            lblResultado.Text = "No se pudo actualizar el stock";
        }


    }
}