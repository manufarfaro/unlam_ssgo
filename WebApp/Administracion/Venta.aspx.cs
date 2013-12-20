using System;
using System.Collections;
using System.Collections.Generic;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Administracion_Venta : System.Web.UI.Page
{

    public int _productoSelectedIndex;

    public int ProductoSelectedIndex
    {
        get
        {
            return (this._productoSelectedIndex);
        }
        set
        {
            this._productoSelectedIndex = value;
        }
    }

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

            if (Page.PreviousPage != null)
            {
                DropDownList SourceDdlProducto = (DropDownList)Page.PreviousPage.FindControl("ddlProducto");

                ProductoSelectedIndex = int.Parse(SourceDdlProducto.SelectedValue);

                this.EstablecerValorDefectoProducto();

                this.CargarLblStock(int.Parse(ddlProducto.SelectedValue));
            }

            if (Session["CanastaProducto"] == null)
            {
                CanastaProducto = new List<ProductoCanasta>();
            }
            
            gvProductSales.DataSource = CanastaProducto;
            gvProductSales.DataBind();



            if (!Page.IsPostBack)
            {
                this.CargarProductos();
            }
            



        }
        catch (Exception exception)
        {
            BusinessException businessException = new BusinessException(exception);
        }
    }

    protected void gvProductSales_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        { 
            // Informar de Cantidad Superada en Stock - Inicio

            int id_Producto = int.Parse(e.Row.Cells[0].Text);
            int ProductoQty = int.Parse(e.Row.Cells[2].Text);

            ProductoService productoService = new ProductoService();
            Producto producto = new Producto();

            producto = productoService.getById(id_Producto);

            if (producto.Cantidad_Stock < ProductoQty)
            {
                e.Row.BackColor = System.Drawing.Color.FromName("red");
            }

            // Informar de Cantidad Superada en Stock - Fin
        }
    }

    protected void gvProductSales_RowCommand(object sender, GridViewCommandEventArgs e)
    {

        int index = Convert.ToInt32(e.CommandArgument);
        GridViewRow selectedRow = gvProductSales.Rows[index];

        int id_Producto = int.Parse(selectedRow.Cells[0].Text);

        switch (e.CommandName)
        {
            case "btnEditar":

                Response.Redirect("~/Administracion/EditarStockCanasta.aspx?id_Producto=" + id_Producto,false);
                
                break;

            case "btnEliminar":

            
                bool hasRowsToDelete = false;
                ProductoCanasta productoCanasta = new ProductoCanasta();

                foreach (ProductoCanasta itemCanastaProducto in CanastaProducto)
                {
                    if (itemCanastaProducto.Id == id_Producto)
                    {
                        productoCanasta = itemCanastaProducto;
                        hasRowsToDelete = true;
                    }
                }

                if (hasRowsToDelete)
                {
                    if(CanastaProducto.Remove(productoCanasta))
                    {
                        lblProdStatus.Text = "El producto se ha eliminado correctamente de la lista.";
                    
                        gvProductSales.DataSource = CanastaProducto;
                        gvProductSales.DataBind();
                    }
                    else
                    {
                        lblProdStatus.Text = "El producto no se ha podido eliminar.";
                    }
                }
                
                break;

            default:
                break;
        }
    }

    protected void ddlProducto_SelectedIndexChanged(object sender, EventArgs e)
    {

        this.ProductoSelectedIndex = int.Parse(ddlProducto.SelectedValue);

        this.CargarLblStock(this.ProductoSelectedIndex);

    }

    protected void gvProductSales_RowDeleting(object sender, GridViewDeleteEventArgs e) { }

    public ArrayList CargarObjProducto()
    {
        ArrayList arrProducto = new ArrayList();
        ProductoService productoService = new ProductoService();

        arrProducto.Add(productoService.getById(int.Parse(ddlProducto.SelectedValue)));
        arrProducto.Add(txtProductoQty.Text);

        return (arrProducto);
    }

    public void CargarProductos()
    {
        ProductoService productoService = new ProductoService();

        ddlProducto.DataValueField = "id_Producto";
        ddlProducto.DataTextField = "Nombre";

        ddlProducto.DataSource = productoService.getAllByCompanyId((int)Session["id_Empresa"]);

        ddlProducto.DataBind();

        this.CargarLblStock(int.Parse(ddlProducto.SelectedValue));

    }

    protected void btnAgregar_Click(object sender, EventArgs e)
    {
        try
        {
            ProductoService productoService = new ProductoService();
            Producto producto = new Producto();
            int qtyProducto = int.Parse(txtProductoQty.Text);
            bool isRepeated = false;

            if (qtyProducto > 0)
            {
                    producto = productoService.getById(int.Parse(ddlProducto.SelectedValue)); ;
                    if (qtyProducto <= producto.Cantidad_Stock)
                    {
                        for (int contador = 0; contador < CanastaProducto.Count; contador++)
                        {
                            if (CanastaProducto[contador].Id == producto.Id_Producto)
                            {

                                isRepeated = true;
                                CanastaProducto[contador].Cantidad += qtyProducto;
                            }
                        }
                        if (!isRepeated)
                        {
                            ProductoCanasta productoCanasta = new ProductoCanasta();

                            productoCanasta.Id = producto.Id_Producto;
                            productoCanasta.Nombre = producto.Nombre;
                            productoCanasta.Cantidad = qtyProducto;
                            productoCanasta.Marca = producto.Marca;
                            productoCanasta.Precio = producto.Precio;

                            this.CanastaProducto.Add(productoCanasta);
                        }
                    }
                    else
                    {
                        txtProductoQty.Text = 0.ToString();
                        lblProdStatus.Text = "El pedido que intenta realizar supera el stock.";
                    }
                        
                }

            gvProductSales.DataSource = this.CanastaProducto;
            gvProductSales.DataBind();

        }
        catch (Exception exception)
        {
            BusinessException businessException = new BusinessException(exception);
        }

    }

    public void CargarLblStock(int id_producto)
    {
        Producto producto = new Producto();
        ProductoService productoService = new ProductoService();

        producto = productoService.getById(id_producto);

        lblStockDesc.Text = producto.Cantidad_Stock.ToString();
    }

    public void EstablecerValorDefectoProducto()
    {
        ddlProducto.SelectedIndex = this.ProductoSelectedIndex;
    }

    protected void btnConfirmar_Click(object sender, EventArgs e)
    {
        /* Se tiene que recorrer la propiedad de sesion y buscar si existe algun producto cuya cantidad exceda 
         * el valor disponible en stock.
         */
        bool AllDataIsCorrect = true;
        ProductoService productoService = new ProductoService();
        Producto producto = new Producto();

        

        for (int contador = 0; contador < CanastaProducto.Count; contador++)
        {
            producto = productoService.getById(CanastaProducto[contador].Id);

            if (CanastaProducto[contador].Cantidad > producto.Cantidad_Stock)
            {
                AllDataIsCorrect = false;
            }
        }

        if (AllDataIsCorrect)
        {
            bool isCorrect = true;

            if (CanastaProducto.Count > 0)
            {
                for (int contador = 0; contador < CanastaProducto.Count; contador++)
                {

                    int ProdQty = 0;

                    producto = productoService.getById(CanastaProducto[contador].Id);
                    ProdQty = producto.Cantidad_Stock - CanastaProducto[contador].Cantidad;

                    if (ProdQty >= 0)
                    {
                        if (!productoService.UpdateStockById(CanastaProducto[contador].Id, ProdQty))
                        {
                            isCorrect = false;
                        }
                    }
                    else
                    {
                        isCorrect = false;
                    }
                }

                if (isCorrect)
                {
                    lblProdStatus.Text = "Su solicitud se ha procesado correctamente.";
                }
                else
                {
                    lblProdStatus.Text = "Su solicitud se ha completado con errores.";
                }

                CanastaProducto.Clear();
                CanastaProducto = null;

                this.CargarProductos();

                gvProductSales.DataBind();


            }
            else
            {
                lblProdStatus.Text = "No existen elementos en la lista para vender";
            }
        }
        else
        {
            lblProdStatus.Text = "Hay errores en el pedido, corríjalos e intente de nuevo.";
        }

    }
}