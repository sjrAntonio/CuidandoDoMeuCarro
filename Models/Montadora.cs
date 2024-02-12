namespace CuidandoDoMeuCarro.Models
{
    public class Montadora
    {
        public int Id { get; set; }
        public string Descricao { get; set; }
        public ICollection<Carro> Carros { get; } = new List<Carro>();
    }
}
