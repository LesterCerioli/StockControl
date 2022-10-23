using ControleEstoque.Infraestrutura.Apoio;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Xml.Linq;
using JsonSerializer = Newtonsoft.Json.JsonSerializer;

namespace ControleEstoque.Infraestrutura.Modulos
{
    public static class ExtensoesDeObjetosExtensiveis
    {
        public static T GetData<T>(this IObjetoExtensivel objetoExtensivel, string nome, bool handleType = false)
        {
            CheckNotNull(objetoExtensivel, nome);

            if (objetoExtensivel == null)
            {
                throw new ArgumentNullException(nameof(objetoExtensivel));
            }

            if (nome == null)
            {
                throw new ArgumentNullException(nameof(nome)); 
            }

            return objetoExtensivel.GetData<T>(
                nome,
                handleType
                    ? new JsonSerializer { TypeNameHandling = TypeNameHandling.All }
                    : JsonSerializer.CreateDefault()
            );
        }

        public static T GetData<T>(this IObjetoExtensivel objetoExtensivel, string nome, JsonSerializer jsonSerializer)
        {
            CheckNotNull(objetoExtensivel, nome);

            if (objetoExtensivel.ExtensaoDado == null)
            {
                return default(T);
            }

            var json = JObject.Parse(objetoExtensivel.ExtensaoDado);

            var prop = json[nome];

            if (prop == null)
            {
                return default(T);
            }

            if (TypeHelper.IsPrimitiveExtendedIncludingNullable(typeof(T)))
            {
                return prop.Value<T>();
            }

            else
            {
                return (T)prop.ToObject(typeof(T), jsonSerializer ?? JsonSerializer.CreateDefault());
            }
        }
        
        
        public static void SetData<T>(this IObjetoExtensivel objetoExtensivel, string nome, T value, bool handleType = false)
        {
            objetoExtensivel.SetData(
                nome,
                value,
                handleType
                    ? new JsonSerializer { TypeNameHandling = TypeNameHandling.All }
                    : JsonSerializer.CreateDefault()
            );
        }

        public static void SetData<T>(this IObjetoExtensivel objetoExtensivel, string name, T value, JsonSerializer jsonSerializer)
        {
            CheckNotNull(objetoExtensivel, name);

            if (jsonSerializer == null)
            {
                jsonSerializer = JsonSerializer.CreateDefault();
            }

            if (objetoExtensivel.ExtensaoDado == null)
            {
                if (EqualityComparer<T>.Default.Equals(value, default(T)))
                {
                    return;
                }

                objetoExtensivel.ExtensaoDado = "{}";
            }

            var json = JObject.Parse(objetoExtensivel.ExtensaoDado);

            if (value == null || EqualityComparer<T>.Default.Equals(value, default(T)))
            {
                if (json[name] != null)
                {
                    json.Remove(name);
                }
            }
            else if (TypeHelper.IsPrimitiveExtendedIncludingNullable(value.GetType()))
            {
                json[name] = new JValue(value);
            }
            else
            {
                json[name] = JToken.FromObject(value, jsonSerializer);
            }

            var data = json.ToString(Formatting.None);
            if (data == "{}")
            {
                data = null;
            }

            objetoExtensivel.ExtensaoDado = data;
        }

        public static bool RemoveData(this IObjetoExtensivel objetoExtensivel, string nome)
        {
            CheckNotNull(objetoExtensivel, nome);

            if (objetoExtensivel.ExtensaoDado == null)
            {
                return false;
            }

            var json = JObject.Parse(objetoExtensivel.ExtensaoDado);

            var token = json[nome];
            if (token == null)
            {
                return false;
            }

            json.Remove(nome);

            var data = json.ToString(Formatting.None);
            if (data == "{}")
            {
                data = null;
            }

            objetoExtensivel.ExtensaoDado = data;

            return true;
        }

        private static void CheckNotNull(params object[] values)
        {
            foreach (var value in values)
            {
                if (value == null)
                {
                    throw new ArgumentNullException();
                }
            }
        }
    }
}
