using IMedicalTest.Datos.ContratosRespuesta;
using IMedicalTest.Model;

namespace IMedicalTest.Datos
{
    public class InfoCiudades
    {
        private readonly TestImedicalContext Contexto;

        public InfoCiudades(TestImedicalContext contexto)
        {
            Contexto = contexto;
        }


        public Ciudad? GetCiudadByName(string nombre)
        {
            Ciudad? city = Contexto.Ciudads.Where(w => w.Nombre == nombre).FirstOrDefault();

            return city;
        }

        public IEnumerable<ResNoticias> GetNoticiasCiudad(string nombre) 
        {
            Ciudad? ciudad = GetCiudadByName(nombre);
            
            if(ciudad == null)
            {
                throw new Exception("Lo sentimos, no poseemos noticias de esa ciudad");
            }

            IEnumerable<ResNoticias> noticiasRes = Contexto.Noticia.Where(w => w.CiudadId == ciudad.Id).Select(s => new ResNoticias 
            {
                IdNoticia = s.Id,
                NombreCiudad = nombre,
                Autor = s.Autor,
                Titulo = s.Titulo,
                fecha = s.Fecha,
                IdCiudad = ciudad.Id
            }).ToList();

            return noticiasRes;
        }

        public ResClima? GetUltimoRegistroClimaByCiudadNombre(string nombre)
        {
            Ciudad? ciudad = GetCiudadByName(nombre);

            if (ciudad == null)
            {
                throw new Exception("Lo sentimos, no poseemos informacion climatológica de esa ciudad");
            }

            ResClima? clima = Contexto.Climas.Where(w => w.CiudadId == ciudad.Id).OrderByDescending(w => w.FechaActualizacion).Select(s => new ResClima
            {
                FechaObservacion = s.FechaActualizacion,
                Temperatura = s.Temperatura,
                VelocidadViento = s.VelocidadViento,
                Descripcion = s.Descripcion,
                Precipitacion = s.Precipitacion,
                Humedad = s.Humedad,
                Visibilidad = s.Visibilidad,
            }).FirstOrDefault();

            return clima;

        }

        public ResNoticiasClima GetNoticiasClima(string nombre)
        {
            IEnumerable<ResNoticias> news = GetNoticiasCiudad(nombre);

            ResClima? clima = GetUltimoRegistroClimaByCiudadNombre(nombre);


            //// Tipo 3 correspondiente a clase ambos meter en constantes
            RegistrarConsulta(news.First().IdCiudad, 3);

            return new ResNoticiasClima()
            {
                Noticias = news,
                UltimoClima = clima
            };
        }

        public void RegistrarConsulta(int idCiudad, int idTipo)
        {   
            Historico historico = new Historico()
            {
                Hora = DateTime.Now,
                TipoBusquedaId = idTipo,
                CiudadId = idCiudad,
            };
            Contexto.Historicos.Add(historico);
            Contexto.SaveChanges();
        }

        public IEnumerable<ResConsultas> GetConsultas()
        {
            IEnumerable<ResConsultas> resultados = Contexto.Historicos.OrderByDescending(o => o.Hora).Select(s => new ResConsultas()
            {
                Ciudad = s.Ciudad.Nombre,
                Info = "Info",
                Fecha = s.Hora
            });
          return resultados;
        }
    }
}
