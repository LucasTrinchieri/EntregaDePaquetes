using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Envio
    {
        public string NroEnvio { get; set; }
        public Persona Destinatario { get; set; }
        public Repartidor Repartidor { get; set; }
        public Estados Estado { get; set; }
        public DateTime FechaEstimada { get; set; }
        public DateTime FechaEntrega { get; set; }
        public string Descripcion { get; set; }

        public decimal Precio { get; set; }

        public Envio() { }
        public Envio(string nroEnvio, Persona destinatario, Repartidor repartidor, DateTime fechaEntrega, string descripcion)
        {
            NroEnvio = nroEnvio;
            Destinatario = destinatario;
            Estado = Estados.PENDIENTE;
            FechaEstimada = fechaEntrega;
            Descripcion = descripcion;
            Repartidor = repartidor;
        }

        public string RetornarNro()
        {
            return $"201: {NroEnvio}";
        }

        public void ActualizarEstado(Estados estado)
        {
            Estado = estado;

            if (Estado == Estados.ENTREGADO)
            {
                Repartidor.CalcularComision();

                FechaEntrega = DateTime.Now;
            }
        }
    }
}
