using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class AgregarProducto : System.Web.UI.Page
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

            CategoriaService categoriaService = new CategoriaService();
            int idEmpresa = (int)Session["id_Empresa"];
            ddlCategoria.DataValueField = "id_Categoria";
            ddlCategoria.DataTextField = "Nombre";

            ddlCategoria.DataSource = categoriaService.getAll();
            ddlCategoria.DataBind();

        }
    }

    protected void btnAgregar_Click(object sender, EventArgs e)
    {
        Producto prod1 = new Producto();
        ProductoService ProdService = new ProductoService();
        prod1.Id_Empresa = Convert.ToInt32(Session["id_Empresa"]);
        prod1.Id_Categoria = Convert.ToInt32(ddlCategoria.SelectedValue);
        prod1.Marca = txtMarca.Text;
        prod1.Modelo = txtModelo.Text;
        prod1.Nombre = txtNombre.Text;
        prod1.Precio = Convert.ToInt16(txtPrecio.Text);
        prod1.Cantidad_Minima = Convert.ToInt16(txtStockMinimo.Text);
        prod1.Cantidad_Stock = Convert.ToInt16(txtStockInicial.Text);

        if (ProdService.insert(prod1))
        {
            lblResultado.Text = "Se agrego el producto con exito";
        }
        else
        {
            lblResultado.Text = "No se agrego la categoria. Contacte al administrador";
        }   
        
     
    }
}