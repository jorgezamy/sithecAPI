using sithecAPI.Models.Entities;

namespace sithecAPI.Data
{
    public class HumanosData
    {
        public static List<Humano> GetHumanos()
        {
            return new List<Humano>()
            {
                new Humano { Id = Guid.Parse("b764f884-d7a2-4ade-9374-f2037588bb17"), Nombre = "Juan", Sexo = "Masculino", Edad = 30, Altura = 1.75, Peso = 70 },
                new Humano { Id = Guid.Parse("1e1ad1b9-06b9-4107-baea-d9dcdd0e66ea"), Nombre = "María", Sexo = "Femenino", Edad = 25, Altura = 1.65, Peso = 60 },
                new Humano { Id = Guid.Parse("9dcc41f2-2d17-43b6-93d5-88e9e9a8397b"), Nombre = "Pedro", Sexo = "Masculino", Edad = 40, Altura = 1.80, Peso = 85 },
                new Humano { Id = Guid.Parse("c94d8cd0-98ac-44f4-9600-9638e96b9668"), Nombre = "Jorge", Sexo = "Masculino", Edad = 32, Altura = 1.85, Peso = 82 }
            };
        }
    }
}
