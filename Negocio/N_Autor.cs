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
        public List<E_Autor> listAutores() {
            return dA.listAutores();
        }
    }
}
