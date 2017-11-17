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
        public IEnumerable<autor> listAutores() {
            List<autor> lPer = new List<autor>();
            var cn = from a in db.autor
                     select a;
            foreach (autor dA in cn){
                autor mA=new autor();
                mA.id_autor=dA.id_autor;
                mA.nombre = dA.nombre;
                lPer.Add(mA);
            }
            return lPer.ToList();
        }
        public IEnumerable<autor> addAutor(IEnumerable<autor> a) {
            var res = new List<autor>();
            using (var db = new dbModelDataContext()) {
                foreach (var aVM in a) {
                    var mA = new autor
                    {
                        nombre = aVM.nombre
                    };
                    res.Add(mA);
                    db.autor.InsertOnSubmit(mA);
                }
                db.SubmitChanges();
            }
            return res.ToList();

        }
        public void updateAutor(IEnumerable<autor> a) {
            using (var db = new dbModelDataContext()) {
                foreach (var aVM in a) {
                    var mAutor = new autor
                    {
                        id_autor=aVM.id_autor,
                        nombre = aVM.nombre
                    };
                    db.autor.Attach(mAutor);
                    db.Refresh(System.Data.Linq.RefreshMode.KeepCurrentValues, mAutor);
                }
                db.SubmitChanges();
            }
        }
    }
}
