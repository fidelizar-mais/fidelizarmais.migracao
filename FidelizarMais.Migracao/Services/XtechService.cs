using FidelizarMais.Migracao.Models;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;

namespace FidelizarMais.Migracao.Services
{
    public class XtechService
    {
        public List<PedidoXtechViewModel> Pedidos(string chaveAPIXtech, string subdominioAPIXtech)
        {
            List<PedidoXtechViewModel> peididos = new List<PedidoXtechViewModel>();
            bool fim = false;
            int page = 1;
            do
            {
                List<PedidoXtechViewModel> peidido = BuscarPedido<List<PedidoXtechViewModel>>(chaveAPIXtech, subdominioAPIXtech, page);
                peididos.AddRange(peidido);
                fim = peidido.Any();
                page++;
            } while (fim);

            return peididos;
        }

        public List<ClienteXtechViewModel> Clientes(string chaveAPIXtech, string subdominioAPIXtech)
        {
            List<ClienteXtechViewModel> clientes = new List<ClienteXtechViewModel>();
            bool fim = false;
            int page = 1;
            do
            {
                List<ClienteXtechViewModel> cliente = BuscarCliente<List<ClienteXtechViewModel>>(chaveAPIXtech, subdominioAPIXtech, page);
                clientes.AddRange(cliente);
                fim = cliente.Any();
                page++;
            } while (fim);

            return clientes;
        }

        private T BuscarPedido<T>(string apiKey, string subdominio, int page = 1) where T : class
        {
            ServicePointManager.Expect100Continue = false;
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12 | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls;

            RestClient client = new RestClient(new Uri($"{subdominio?.TrimStart('/')}/api-v1/orders?format=json&page={page}&per_page=100"));
            var request = new RestRequest(Method.GET);
            request.AddHeader("X-API-KEY", $"{apiKey}");
            request.AddHeader("X-APP-KEY", "pAcRUPhEChef5JuhezEw8ubRe5hecE");
            request.AddHeader("Content-Type", "application/json");
            IRestResponse response = client.Execute(request);
            string content = response.Content;

            if ((int)response.StatusCode == 429)
            {
                TimeSpan headerAfter = this.ApiRetryAfter(response);

                Thread.Sleep(headerAfter);
                return this.BuscarCliente<T>(apiKey, subdominio, page);
            }

            if (response.StatusCode == HttpStatusCode.Unauthorized)
            {
                TimeSpan headerAfter = this.ApiRetryAfter(response);

                Thread.Sleep(headerAfter);
                try
                {
                    return this.BuscarCliente<T>(apiKey, subdominio, page);
                }
                catch
                {
                    throw new Exception("Error");
                }
            }

            if (!response.IsSuccessful)
                throw new Exception("Error");

            if (response.StatusCode != HttpStatusCode.OK)
                throw new Exception("Error");

            if (!string.IsNullOrWhiteSpace(content))
            {
                content = content.Replace("[false,false]", "[]");
                content = content.Replace("[false]", "[]");
            }

            return JsonConvert.DeserializeObject<T>(content);
        }

        private T BuscarCliente<T>(string apiKey, string subdominio, int page = 1) where T : class
        {
            ServicePointManager.Expect100Continue = false;
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12 | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls;

            RestClient client = new RestClient(new Uri($"{subdominio?.TrimStart('/')}/api-v1/customers?format=json&page={page}&per_page=100"));
            var request = new RestRequest(Method.GET);
            request.AddHeader("X-API-KEY", $"{apiKey}");
            request.AddHeader("X-APP-KEY", "pAcRUPhEChef5JuhezEw8ubRe5hecE");
            request.AddHeader("Content-Type", "application/json");
            IRestResponse response = client.Execute(request);
            string content = response.Content;

            if ((int)response.StatusCode == 429)
            {
                TimeSpan headerAfter = this.ApiRetryAfter(response);

                Thread.Sleep(headerAfter);
                return this.BuscarCliente<T>(apiKey, subdominio, page);
            }

            if (response.StatusCode == HttpStatusCode.Unauthorized)
            {
                TimeSpan headerAfter = this.ApiRetryAfter(response);

                Thread.Sleep(headerAfter);
                try
                {
                    return this.BuscarCliente<T>(apiKey, subdominio, page);
                }
                catch
                {
                    throw new Exception("Error");
                }
            }

            if (!response.IsSuccessful)
                throw new Exception("Error");

            if (response.StatusCode != HttpStatusCode.OK)
                throw new Exception("Error");

            if (!string.IsNullOrWhiteSpace(content))
            {
                content = content.Replace("[false,false]", "[]");
                content = content.Replace("[false]", "[]");
            }

            return JsonConvert.DeserializeObject<T>(content);
        }

        private TimeSpan ApiRetryAfter(IRestResponse response, string key = "Api-Retry-After")
        {
            TimeSpan interval = TimeSpan.FromSeconds(300);
            var result = JsonConvert.DeserializeObject<IList<HeadersModel>>(JsonConvert.SerializeObject(response.Headers));
            if (result.Any(x => x.Name == key) && result.FirstOrDefault(x => x.Name == key).Value.Any())
            {
                var seconds = int.Parse(result?.FirstOrDefault(x => x.Name == key).Value);
                interval = TimeSpan.FromSeconds(seconds);
                return interval;
            }

            return interval;
        }
    }
}
