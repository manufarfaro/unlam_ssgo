using System;
using System.Web.UI;

public partial class Administracion_EditarCategoria : System.Web.UI.Page
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
            if (!Page.IsPostBack)
            {
                int GetId = int.Parse(Request.QueryString["id_Categoria"]);
                this.CargarCategorias(GetId);
            }
        }
        catch(Exception exception)
        {
            BusinessException businessException = new BusinessException(exception);
            Response.Redirect("~/Administracion/VerCategoria.aspx",false);
        }
        
    }

    protected void btnActualizar_Click(object sender, EventArgs e)
    {
        try
        { 
            Categoria categoria = new Categoria();
            CategoriaService categoriaService = new CategoriaService();

            categoria.ID_Empresa = (int)Session["id_Empresa"];
            categoria.id_Categoria = int.Parse(Request.QueryString["id_Categoria"]);
            categoria.Nombre = txtNombre.Text;
            categoria.Codigo = txtCodigo.Text;
            categoria.Descripcion = txtDescripcion.Text;

            if(categoriaService.update(categoria))
            {
                lblCategorias.Text = "Se ha actualizado corrrectamente la categoria.";
            }
            else
            {
                lblCategorias.Text = "La categoria no ha podido ser actualizada.";
                throw new Exception("No se pudo actualizar la categoria");
            }

        }
        catch (Exception exception)
        {
            lblCategorias.Text = "Ha ocurrido un error interno. Intente despues.";
            BusinessException bussinessException = new BusinessException(exception);
        }
    }

    public void CargarCategorias(int id_Categoria)
    {
        CategoriaService categoriaService = new CategoriaService();
        Categoria categoria = new Categoria();

        categoria = categoriaService.getById(id_Categoria);

        txtNombre.Text = categoria.Nombre;
        txtCodigo.Text = categoria.Codigo;
        txtDescripcion.Text = categoria.Descripcion;

    }

}