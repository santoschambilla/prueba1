using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;

using Entidades;
using Negocio;
namespace WebApp
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        [WebMethod]
        public static List<E_Autor> listAutores() {
            N_Autor nA = new N_Autor();
            return nA.listAutores();
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string lAut = "",titulo="",edicion="";
            titulo = Page.Request.Form["titulo"];
            edicion = Page.Request.Form["edicion"];
            lAut = Page.Request.Form["laut"];

            libro eLibro = new libro();
            eLibro.fecha = Convert.ToDateTime(edicion);
            eLibro.titulo = titulo.Trim().ToUpper();
            N_Libro nL = new N_Libro();

            Label1.Text = nL.addLibro(eLibro, lAut);
        }
    }
}