using CuidandoDoMeuCarro.Data.IRepository;
using CuidandoDoMeuCarro.Data.Repository;
using CuidandoDoMeuCarro.Models;

namespace CuidandoDoMeuCarro.BusinessRules
{
    public class MotoristaRules: IMotoristaRepository
    {
        private readonly IMotoristaRepository motoristaRepository;

        public MotoristaRules(IMotoristaRepository MotoristaRepository)
        {
            motoristaRepository = MotoristaRepository;
        }

        public Task<List<Motorista>> BuscaTodosMotoristas(int? pageNumber, int? pageSize)
        {
            return motoristaRepository.BuscaTodosMotoristas(pageNumber, pageSize);
        }
    }
}
