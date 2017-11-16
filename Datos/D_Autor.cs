using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Entidades;
namespace Datos
{
    public class D_Autor
    {
        dbModelDataContext db = new dbModelDataContext();
        public string addAutor(autor a){
            string res = "";

            try
            {
                db.autor.InsertOnSubmit(a);
                db.SubmitChanges();
                res = "Se registro correctamente!";
            }
            catch (Exception ex) {
                res = ex.Message;
            }
            return res;
        }
        public List<E_Autor> listAutores() {
            var cn = from a in db.autor
                     select new E_Autor { 
                         idAutor=a.id_autor,
                         nombre=a.nombre
                     };
            return cn.ToList();
        }
    }
}
