namespace CuidandoDoMeuCarro.Models
{
    public class Montadora
    {
        public int Id { get; set; }
        public string Marca { get; set; }
        public ICollection<Carro> Carros { get; } = new List<Carro>();
    }
}
