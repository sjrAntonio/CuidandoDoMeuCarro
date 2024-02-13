using CuidandoDoMeuCarro.Data.IRepository;
using CuidandoDoMeuCarro.Extensoes;
using CuidandoDoMeuCarro.Models;
using Dapper;
using Microsoft.EntityFrameworkCore;
using System.Data.Common;

namespace CuidandoDoMeuCarro.Data.Repository
{
    public class MotoristaRepository : IMotoristaRepository
    {
        private readonly DataContext context;
        private readonly DbConnection connection;

        public MotoristaRepository(DataContext Context)
        {
            context = Context;
            connection = context.Database.GetDbConnection();
        }

        private string sqlBuscaTodosMotoristas(bool Paginacao)
        { 
            string sRetorno = @"SELECT Id, " +
                               "       Nome, " +
                               "       Cnh, " +
                               "       CASE TipoCNH WHEN 1 THEN 'A' " +
                               "                    WHEN 2 THEN 'B' " +
                               "                    WHEN 3 THEN 'C' " +
                               "                    WHEN 4 THEN 'D' " +
                               "                    WHEN 5 THEN 'E' " +
                               "       END As [Tipo_CNH]  " +
                               "FROM Motoristas  " +
                               "ORDER BY ID";
            if (Paginacao)
            {
                sRetorno += " LIMIT @Skip OFFSET @Take ";
            }

            return sRetorno.clearString(); //evita mandar "bobagem" para o BD
        }
        public async Task<List<Motorista>> BuscaTodosMotoristas(int? pageNumber, int? pageSize)
        {
            bool Paginacao = true;

            if ((pageNumber == null) || (pageSize == null)) { Paginacao = false;  }

            string sSQL = sqlBuscaTodosMotoristas(Paginacao);
            
            var retorno = await connection.QueryAsync<Motorista>(sSQL, new {@Skip = pageSize,
                                                                            @Take = pageNumber});

            return retorno.ToList();
        }
    }
}
