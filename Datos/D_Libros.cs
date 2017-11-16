using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Threading.Tasks;

using Entidades;
namespace Datos
{
    class D_Libros
    {
        dbModelDataContext db = new dbModelDataContext();
        public string addLibro(libro l)
        {
            string res = "";
            try
            {
                db.libro.InsertOnSubmit(l);
                db.SubmitChanges();
                res = "Se adicionó correctamente...!";
            }
            catch (Exception ex) {
                res = ex.Message;
            }
            return res;
            

        }
      
    }
}
