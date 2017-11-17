using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Entidades;
using Datos;
namespace Negocio
{
    public class N_Autor
    {
        D_Autor dA = new D_Autor();
        public string addAutor(autor a) {
            return dA.addAutor(a);
        }
        public IEnumerable<autor> listAutores()
        {
            return dA.listAutores();
        }
        public IEnumerable<autor> addAutor(IEnumerable<autor> a) {
            return dA.addAutor(a);
        }
        public void updateAutor(IEnumerable<autor> a) {
            dA.updateAutor(a);
        }
    }
}
