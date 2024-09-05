using Microsoft.AspNetCore.Mvc;
using sithecAPI.Models.Requests;

namespace sithecAPI.utilities
{
    public static class OperationsUtilities
    {
        public static double GetOperaciones(OperacionRequest operaciones)
        {
            if (operaciones == null)
            {
                throw new ArgumentNullException("La solicitud no puede estar vacia");
            }

            double resultado = 0;

            switch (operaciones.Operacion.ToLower())
            {
                case "suma":
                    resultado = operaciones.Numero1 + operaciones.Numero2;
                    break;
                case "resta":
                    resultado = operaciones.Numero1 - operaciones.Numero2; ;
                    break;
                case "multiplicacion":
                    resultado = operaciones.Numero1 * operaciones.Numero2;
                    break;
                case "division":
                    if (operaciones.Numero2 == 0)
                    {
                        throw new InvalidOperationException("No se puede dividir por 0");
                    }
                    else
                    {
                        resultado = operaciones.Numero1 / operaciones.Numero2;
                    }
                    break;
                default:
                    throw new InvalidOperationException("Operacion no valida. Por favor usa (suma, resta, multiplicacion o division)");
            }

            return resultado;
        }
    }
}
