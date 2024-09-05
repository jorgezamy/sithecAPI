namespace sithecAPI.Models.Requests
{
    public class OperacionRequest
    {
        public double Numero1 { get; set; }
        public double Numero2 { get; set; }
        public string Operacion { get; set; } = "suma";
    }
}
