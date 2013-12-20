using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Administracion_EditarStockCanasta : System.Web.UI.Page
{

    public ProductoCanasta _itemProductoCanasta;

    public List<ProductoCanasta> CanastaProducto
    {
        get
        {
            return ((List<ProductoCanasta>)Session["CanastaProducto"]);
        }
        set
        {
            this.Session["CanastaProducto"] = value;
        }
    }

    public ProductoCanasta ItemProductoCanasta
    {
        get
        {
            return (this._itemProductoCanasta);
        }
        set
        {
            this._itemProductoCanasta = value;
        }
    }

    protected void Page_PreInit(Object sender, EventArgs e)
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
            if (int.Parse(Request.QueryString["id_Producto"]) != 0)
            {
                if (this.CanastaProducto != null)
                {
                    bool isCorrect = false;

                    for (int contador = 0; contador < CanastaProducto.Count; contador++)
                    {
                        if (this.CanastaProducto[contador].Id == int.Parse(Request.QueryString["id_Producto"]))
                        {
                            isCorrect = true;
                            this.ItemProductoCanasta = CanastaProducto[contador];
                        }
                    }

                    if (isCorrect)
                    {
                        lblId.Text = this.ItemProductoCanasta.Id.ToString();
                        lblName.Text = this.ItemProductoCanasta.Nombre;
                        lblBrand.Text = this.ItemProductoCanasta.Marca;
                        lblPrice.Text = this.ItemProductoCanasta.Precio.ToString();
                        txtQty.Text = this.ItemProductoCanasta.Cantidad.ToString();

                    }
                    else
                    {
                        Response.Redirect("~/Administracion/Venta.aspx");
                    }

                }
                else
                {
                    Response.Redirect("~/Administracion/Venta.aspx");
                }
            }
            else
            {
                Response.Redirect("~/Administracion/Venta.aspx",false);
            }
        }
    }



    protected void btnActualizar_Click(object sender, EventArgs e)
    {
        try
        {
            ProductoService productoService = new ProductoService();
            if (int.Parse(txtQty.Text) > 0)
            {

                bool isUpdated = false;

                for (int contador = 0; contador < CanastaProducto.Count; contador++)
                {
                    if (this.CanastaProducto[contador].Id == int.Parse(Request.QueryString["id_Producto"]))
                    {
                        isUpdated = true;
                        CanastaProducto[contador].Cantidad = int.Parse(txtQty.Text);
                    }
                }

                if (isUpdated)
                {
                    lblStatus.Text = "La cantidad se ha actualizado correctamente.";
                }
                else
                {
                    lblStatus.Text = "La cantidad no se ha podido actualizar.";
                }
            }
            else
            {
                lblStatus.Text = "La cantidad ingresada no es valida.";
            }
        }
        catch (Exception exception)
        {
            lblStatus.Text = "Se ha producido un error interno, intente nuevamente mas tarde.";
            BusinessException businessException = new BusinessException(exception);
        }
        
    }
}