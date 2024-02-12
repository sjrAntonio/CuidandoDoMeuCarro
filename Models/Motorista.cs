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
        public Motorista(int xId, string xNome, long xCnh, enTipoCnh xTipoCnh, DateTime xValidadeCnh)
        {
            this.Id = xId;
            this.Nome = xNome;
            this.Cnh = xCnh;
            this.TipoCNH = (int)xTipoCnh;
            this.ValidadeCnh = xValidadeCnh;
        }

        public int Id { get; set; }
        public string Nome { get; set; }
        public long Cnh { get; set; }
        public int TipoCNH { get; set; }
        public DateTime ValidadeCnh { get; set; }
    }
}
