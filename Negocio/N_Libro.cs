using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Entidades;
using Datos;
namespace Negocio
{
    public class N_Libro
    {
        D_Libros dL = new D_Libros();
        public string addLibro(libro l, string lAutores) {
            return dL.addLibro(l, lAutores);
        }
        public List<E_ListaLibro> listarLibro() {
            return dL.listarLibro();
        }

    }
}
