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
    public partial class ListarLibros : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        [WebMethod]
        public static List<E_ListaLibro> listarLibro() 
        {
            N_Libro nL = new N_Libro();
            return nL.listarLibro();
        }
    }
}