namespace CuidandoDoMeuCarro.Models
{
    public class Manutencao
    {
        public int Id { get; set; }
        public int CarroId { get; set; }
        public string Descricao { get; set; }
        public decimal Valor { get; set; }
        public long Quilometragem { get; set; }
        public DateTime Data { get; set; }
        public bool ManutencaoCorretiva { get; set; }
        public Carro Carro { get; set; } = null!;
    }
}
