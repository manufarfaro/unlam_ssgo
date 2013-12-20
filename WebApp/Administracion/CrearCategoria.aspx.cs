using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class CrearCategoria : System.Web.UI.Page
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

        

    }
    protected void btnCrear_Click(object sender, EventArgs e)
    {

        try
        {
            Categoria cat = new Categoria();
            Categoria cat_srch = new Categoria();


            cat.Codigo = txtCodigoCategoria.Text;
            cat.Nombre = txtNombreCategoria.Text;
            cat.Descripcion = txtDescripcion.Text;
            cat.ID_Empresa = (int)Session["id_Empresa"];
            CategoriaService categoriaService = new CategoriaService();

            cat_srch = categoriaService.getById(cat.id_Categoria);

            //if ( cat_srch.id_Categoria == 0 )
            //{
            if (categoriaService.insert(cat))
            {
                lblResultado.Text = "Se creo la categoria con exito";
                txtCodigoCategoria.Text = "";
                txtDescripcion.Text = "";
                txtNombreCategoria.Text = "";
            }
            else
            {

            }

            //}

        }
        catch (Exception exception)
        {
           lblResultado.Text = "Ha ocurrido un error interno. Vuelva a intentar en unos momentos.";
            
            BusinessException businessException = new BusinessException(exception);
        }


        //if(cat.insert_Categoria(cat))
        //{

        //}
    }
}