using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public static class Utilidades
    {
        public static double CalculoDistancia(this Persona repartidor, Persona destinatario)
        {
            double distance = 0;
            double Lat = (repartidor.Latitud - repartidor.Latitud) * (Math.PI / 180);
            double Lon = (repartidor.Longitud - destinatario.Longitud) * (Math.PI / 180);
            double a = Math.Sin(Lat / 2) * Math.Sin(Lat / 2) + Math.Cos(destinatario.Latitud * (Math.PI / 180)) * Math.Cos(repartidor.Latitud * (Math.PI / 180)) * Math.Sin(Lon / 2) * Math.Sin(Lon / 2);
            double c = 2 * Math.Atan2(Math.Sqrt(a), Math.Sqrt(1 - a));
            distance = EarthRadius * c;
            return distance;
        }
    }

    public enum Estados
    {
        PENDIENTE,
        ASIGNADO_REPARTIDOR,
        EN_CAMINO,
        ENTREGADO

    }
}
