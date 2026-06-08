using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
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

    [Table(name:"tbProducto")]
    public class Producto
    {
        //propiedades : variables que describen un objeto
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Nombre { get; set; }

        [Column(TypeName ="decimal(18,2)")]
        public decimal Precio { get; set; }
        public int Stock { get; set; }
        public string Descripcion { get; set; }
        public bool Estado { get; set; }

    }
}
