using IMedicalTest.Model;

namespace IMedicalTest.Datos.ContratosRespuesta
{
    public class ResClima
    {
        public DateTime FechaObservacion { get; set; }

        public decimal Temperatura { get; set; }

        public string? Descripcion { get; set; }

        public decimal? VelocidadViento { get; set; }

        public decimal? Precipitacion { get; set; }

        public decimal? Humedad { get; set; }

        public decimal? Visibilidad { get; set; }

    }
}
