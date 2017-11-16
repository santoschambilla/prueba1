using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Threading.Tasks;

using Entidades;
namespace Datos
{
    public class D_Libros
    {
        dbModelDataContext db = new dbModelDataContext();
        public string addLibro(libro l,string lAutores)
        {
            string res = "";
            try
            {
                db.libro.InsertOnSubmit(l);
                db.SubmitChanges();
                int d = l.id_libro;
                string[] lA = lAutores.Split(',');
                foreach (string a in lA) {
                    if(a!=""){
                        autor_libro al = new autor_libro();
                        al.id_autor = Convert.ToInt16(a);
                        al.id_libro = d;
                        db.autor_libro.InsertOnSubmit(al);
                    }
                }
                db.SubmitChanges();
                res = "Se adicionó correctamente...!";
            }
            catch (Exception ex) {
                res = ex.Message;
            }
            return res;
            

        }
        public List<E_ListaLibro> listarLibro() { 
            var cn=from l in db.libro
                   //join al in db.autor_libro on l.id_libro equals al.id_libro
                   select new E_ListaLibro{
                       idLibro=l.id_libro,
                       titulo=l.titulo,
                       edicion=Convert.ToDateTime( l.fecha),
                       nroAutores=db.autor_libro.Where(w=>w.id_libro==l.id_libro).Count()
                   };
            return cn.ToList();
        }
        
      
    }
}
