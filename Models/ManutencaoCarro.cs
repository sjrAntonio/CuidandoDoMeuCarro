namespace CuidandoDoMeuCarro.Models
{
    public class ManutencaoCarro
    {
        public int CarroId { get; set; }
        public int ManutencaoId { get; set; }
        public Carro Carro { get; set; }
        public IEnumerable<Manutencao> Manutencao { get; set; }
    }
}
