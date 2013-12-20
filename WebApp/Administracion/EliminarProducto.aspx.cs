using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class EliminarProducto : System.Web.UI.Page
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

        ProductoService productoService = new ProductoService();

        ddlProducto_eliminar.DataValueField = "id_producto";
        ddlProducto_eliminar.DataTextField = "Nombre";

        ddlProducto_eliminar.DataSource = productoService.getAllByCompanyId((int)Session["id_Empresa"]);
        ddlProducto_eliminar.DataBind();
        
    }
    protected void btnElimiarProducto_Click(object sender, EventArgs e)
    {
        Producto prod1 = new Producto();
        ProductoService pService = new ProductoService();
        prod1.Id_Producto = Convert.ToInt32(ddlProducto_eliminar.SelectedValue);
        if (pService.eliminarProducto(prod1))
        {
            lblResultado.Text = "Se elimino el producto";
        }
        else
        {
            lblResultado.Text = "No se elimino el producto";
        }

    }
}