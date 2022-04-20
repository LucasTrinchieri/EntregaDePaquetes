using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Detalle
    {
        public bool ValidacionTelefono { get; set; }
        public bool ValidacionDestinatario { get; set; }

        public Detalle()
        {

        }

        public Detalle(bool telefono, bool destinatario)
        {
            ValidacionDestinatario = destinatario;
            ValidacionTelefono = telefono;
        }
    }
}
