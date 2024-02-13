using CuidandoDoMeuCarro.Models;

namespace CuidandoDoMeuCarro.Data.IRepository
{
    public interface IMotoristaRepository
    {
        public Task<List<Motorista>> BuscaTodosMotoristas(int? pageNumber, int? pageSize);
    }
}
