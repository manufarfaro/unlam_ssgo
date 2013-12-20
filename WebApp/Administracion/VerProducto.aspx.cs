using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class VerStock : System.Web.UI.Page
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
            this.CargarProductos();
        }

    }
    protected void btnActualizarDatos_Click(object sender, EventArgs e)
    {
        gvProductos.DataBind();
    }

    protected void gvProductos_RowDataBound(object sender, GridViewRowEventArgs e)
    { 
        if(e.Row.RowType == DataControlRowType.DataRow)
        {
            //Columna de Categoria - Inicio

            CategoriaService categoriaService = new CategoriaService();
            Categoria categoria = new Categoria();

            int categoriaRowValue = int.Parse(e.Row.Cells[1].Text);

            categoria = categoriaService.getById(categoriaRowValue);

            e.Row.Cells[1].Text = categoria.Nombre;

            //Columna de Categoria - Fin

            //Columna de Stock / Stock Minimo (Comparacion) - Inicio

            int Stock = int.Parse(e.Row.Cells[3].Text);
            int StockMinimo = int.Parse(e.Row.Cells[4].Text);

            if (Stock < StockMinimo)
            {
                e.Row.BackColor = System.Drawing.Color.FromName("red");
            }

            //Columna de Stock / Stock Minimo (Comparacion) - Fin

        }
    }

    protected void gvProductos_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        switch (e.CommandName)
        {
            case "cmdBorrar":

                int index = Convert.ToInt32(e.CommandArgument);
                GridViewRow selectedRow = gvProductos.Rows[index];

                int id_Producto = int.Parse(selectedRow.Cells[0].Text);

                ProductoService productoService = new ProductoService();
                Producto producto = new Producto();

                producto.Id_Producto = id_Producto;

                if (productoService.eliminarProducto(producto))
                {
                    lblProductos.Text = "Se ha eliminado el producto.";
                    this.CargarProductos();
                }
                else
                {
                    lblProductos.Text = "El producto no ha podido ser eliminado.";
                }

                break;
        }

    }

    public void CargarProductos()
    {
        ProductoService productoService = new ProductoService();

        gvProductos.DataSource = productoService.getAllByCompanyId((int)Session["id_Empresa"]);

        gvProductos.DataBind();
    }

}