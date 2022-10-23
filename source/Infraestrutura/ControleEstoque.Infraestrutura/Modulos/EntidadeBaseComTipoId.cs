using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleEstoque.Infraestrutura.Modulos
{
    public abstract class EntidadeBaseComTipoId<TId> : ObjetoValidavel, IEntidadeBaseComTipoId<TId>
    {
        public TId Id { get; protected set; }
    }
}
