using Microsoft.Extensions.Hosting;

namespace CuidandoDoMeuCarro.Models
{
    public class Motorista
    {
        public enum enTipoCnh
        {
            A = 1,
            B = 2,
            C = 3,
            D = 4,
            E = 5
        }
        public int Id { get; set; }
        public string Nome { get; set; }
        public long Cnh { get; set; }
        public int TipoCNH { get; set; }
        public DateTime ValidadeCnh { get; set; }
        public ICollection<Carro> Carros { get; } = new List<Carro>();
    }
}
