using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class EditarProducto : System.Web.UI.Page
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
        try
        { 
            if(!Page.IsPostBack)
            {
                this.CargarDdlCategorias();
                this.CargarProducto();
            }
        }
        catch (Exception exception)
        {
            BusinessException businessException = new BusinessException(exception);
            Response.Redirect("~/Administracion/VerProducto.aspx", false);
        }
        

    }

    public void CargarDdlCategorias()
    {
        CategoriaService categoriaService = new CategoriaService();

        ddlCategoria.DataValueField = "id_Categoria";
        ddlCategoria.DataTextField = "Nombre";

        ddlCategoria.DataSource = categoriaService.getAllByCompanyId((int)Session["id_Empresa"]);
        ddlCategoria.DataBind();
    }

    public void CargarProducto()
    {
        ProductoService productoService = new ProductoService();
        Producto producto = new Producto();

        producto = productoService.getById(int.Parse(Request.QueryString["id_Producto"]));

        txtNombre_prod.Text = producto.Nombre;
        txtModelo.Text = producto.Modelo;
        ddlCategoria.SelectedValue = producto.Id_Categoria.ToString();
        txtStockMinimo_pro.Text = producto.Cantidad_Minima.ToString();
        txtStock.Text = producto.Cantidad_Stock.ToString();
        txtMarca_pro.Text = producto.Marca;
        txtPrecio_pro.Text = producto.Precio.ToString();

    }
    protected void btnModificarDatos_Click(object sender, EventArgs e)
    {
        try
        {
            ProductoService productoService = new ProductoService();
            Producto producto = new Producto();

            producto.Id_Empresa = (int)Session["id_Empresa"];
            producto.Id_Categoria = int.Parse(ddlCategoria.SelectedValue);
            producto.Id_Producto = int.Parse(Request.QueryString["id_Producto"]);
            producto.Nombre = txtNombre_prod.Text;
            producto.Marca = txtMarca_pro.Text;
            producto.Modelo = txtModelo.Text;
            producto.Cantidad_Minima = int.Parse(txtStockMinimo_pro.Text);
            producto.Cantidad_Stock = int.Parse(txtStock.Text);
            producto.Precio = int.Parse(txtPrecio_pro.Text);

            if (productoService.Update(producto))
            {
                lblProducto.Text = "Se ha actualizado el producto.";
            }
            else
            { 
                lblProducto.Text = "El Producto no se ha podido actualizar.";
                throw new Exception("Producto no actualizado, lanzado desde 'productoService.Update(producto)'.");
            }
        }
        catch (Exception exception)
        {
            BusinessException businessException = new BusinessException(exception);
            lblProducto.Text = "Ha ocurrido un error interno, intente nuevamente.";
        }
        

    }
}
