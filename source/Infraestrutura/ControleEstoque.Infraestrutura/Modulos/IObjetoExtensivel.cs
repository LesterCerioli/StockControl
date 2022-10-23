using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleEstoque.Infraestrutura.Modulos
{
    public interface IObjetoExtensivel
    {
        string ExtensaoDado { get; set; }

        T GetData<T>(string nome, JsonSerializer jsonSerializer);
        void SetData<T>(string nome, T? value, JsonSerializer jsonSerializer);
    }
}
