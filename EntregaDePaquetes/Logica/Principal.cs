using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades;
using Newtonsoft.Json;

namespace Logica
{
    public sealed class Principal
    {
        private static readonly Principal _instance = new Principal();
        private Principal() { }
        public static Principal Instance { get { return _instance; } }

        List<Envio> Envios = new List<Envio>();
        List<Persona> Destinatarios = new List<Persona>();
        List<Repartidor> Repartidores = new List<Repartidor>();

        public string DarAltaEnvio(int dniDestinatario, DateTime fechaEntrega, string descripcion)
        {
            if (Validar(dniDestinatario))
            {
                return new Envio(Envios.Last().NroEnvio + 1,
                                BuscarDestinatrio(dniDestinatario), 
                                AsignarRepartidor(), 
                                fechaEntrega, 
                                descripcion)
                                .RetornarNro();
            }

            return $"400: {JsonConvert.SerializeObject(" Destinatario o telefono no encontrados")}";
        }

        public void ActualiarEnvio(string codigo)
        {
            if (BuscarEnvio(codigo) != null)
            {
                int estadoNuevo = (int)BuscarEnvio(codigo).Estado + 1;

                try
                {
                    Validar(estadoNuevo);
                }
                catch (Exception)
                {

                    throw new Exception(" El estado no es validoS");
                }
            }
        }

        public Repartidor AsignarRepartidor()
        {
            return null;
        }

        public void RetornarRepartidores()
        {

        }

        private Persona BuscarDestinatrio(int dni)
        {
            return Destinatarios.FirstOrDefault(x => x.Dni == dni);
        }

        private bool Validar(int dni)
        {
            return BuscarDestinatrio(dni) != null && BuscarDestinatrio(dni).Telefono != null;
        }

        private bool Validar(Estados nuevoEstado)
        {
            return (int)nuevoEstado < 4;
        }

        private Envio BuscarEnvio(string cod)
        {
            return Envios.FirstOrDefault(x => x.NroEnvio == cod);
        }
    }
}
