using System.Reflection.Metadata;

namespace CuidandoDoMeuCarro.Models
{
    public class Carro
    {
        public int Id { get; set; }
        public int MotoristaId { get; set; }
        public int MontadoraId { get; set; }
        public string Placa { get; set; }
        public string Modelo { get; set; }
        public string Cor { get; set; }
        public int AnoFabricacao { get; set; }
        public int AnoModelo { get; set; }
        public string CodigoFipe { get; set; }
        public Motorista Motorista { get; set; } = null!;
        public Montadora Montadora { get; set; } = null!;
        public ICollection<Manutencao> Manutencoes { get; } = new List<Manutencao>();
    }
}