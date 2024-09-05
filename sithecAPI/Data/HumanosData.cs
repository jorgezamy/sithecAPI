using sithecAPI.Models.Entities;

namespace sithecAPI.Data
{
    public class HumanosData
    {
        public static List<Humano> GetHumanos()
        {
            return new List<Humano>()
            {
                new Humano { Id = 1, Nombre = "Juan", Sexo = "Masculino", Edad = 30, Altura = 1.75, Peso = 70 },
                new Humano { Id = 2, Nombre = "María", Sexo = "Femenino", Edad = 25, Altura = 1.65, Peso = 60 },
                new Humano { Id = 3, Nombre = "Pedro", Sexo = "Masculino", Edad = 40, Altura = 1.80, Peso = 85 },
                new Humano { Id = 4, Nombre = "Jorge", Sexo = "Masculino", Edad = 32, Altura = 1.85, Peso = 82 }
            };
        }
    }
}
