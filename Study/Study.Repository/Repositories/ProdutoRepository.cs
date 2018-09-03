using Study.Entities;
using Study.Repository.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Study.Repository.Repositories
{
    public class ProdutoRepository: BaseRepository<Produto>, IProdutoRepository
    {
    }
}
