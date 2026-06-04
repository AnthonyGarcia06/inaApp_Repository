using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace inaApp.Entities

    //nivel acceso
    //public: cualquiera accede a la clase
    //private: solo las clases dentro del mismo archivo pueden acceder a la clase 
    //internal: solo pueden acceder clases dentro del mismo proyecto
    //protected: solo clases dentro del mismo proyecto o heredadas
{
    public class Producto
    {
        //propiedades : variables que describen un objeto

        private int Id { get; }
        private string Nombre { get; set; }
        private decimal Precio { get; set; }
        private int Stock { get; set; }
        private string Descripcion { get; set; }
        private string Estado { get; set; }

    }
}
